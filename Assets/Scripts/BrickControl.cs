using UnityEngine;
using System.Collections;

public class BrickControl : MonoBehaviour {

    private int timesHit;
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    public static int blocksRemaining = 0;
    private bool isBreakable;
    public AudioClip crack;
    public GameObject brickBits;
    public float bonusChance; 

    // Use this for initialization
	void Start () {
        bool isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            blocksRemaining++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
    void Update ()
    {
        
    }
    
	void OnCollisionEnter2D (Collision2D hit) {
        bool isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            AdvanceHits();
            float rnd = Random.Range(0f, 1f);
            if (rnd<=bonusChance)
            {
                GameObject ball = hit.gameObject;
                Instantiate(ball, ball.transform.position, Quaternion.identity);
            }
        }
    }

    void AdvanceHits ()
    {
        timesHit++;
        if (timesHit >= hitSprites.Length + 1)
        {
            blocksRemaining--;
            levelManager.BlockCheck();
            GenerateBits();
            Destroy(gameObject);
        }
        else
        {
            int spriteIndex = timesHit - 1;
            if (hitSprites[spriteIndex])
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            }
            else
            {
                Debug.LogError("No sprite found!");
            }
        }
    }

    void GenerateBits ()
    {
        GameObject currentBits = Instantiate(brickBits, gameObject.transform.position, Quaternion.identity) as GameObject;
        currentBits.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

}
