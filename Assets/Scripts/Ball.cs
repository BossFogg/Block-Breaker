using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    //get LevelManager here

    public static int ballsInPlay;
    private Paddle paddle;
    private static Vector3 paddleToBallVector;
    private static bool ballStartSet;
    public static bool hasStarted;
    private AudioSource bounce;

	// Use this for initialization
	void Start () {
        // Ball announces itself upon starting
        ballsInPlay++;
        // Get audio for bounce
        bounce = GetComponent<AudioSource>();
        // Find paddle
        paddle = GameObject.FindObjectOfType<Paddle>();
        // If this is the beginning of the scene, grab the paddle's relative position
        if (ballStartSet == false)
        {
            paddleToBallVector = this.transform.position - paddle.transform.position;
            ballStartSet = true;
        }
        // If this is not the first ball, assign velocity on start
        if (ballsInPlay>=2)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        // If play has not started...
        if (!hasStarted)
        {
            // ...Keep ball in place relative to paddle...
            this.transform.position = paddle.transform.position + paddleToBallVector;
            // ...Until the player presses left mouse
            if (Input.GetMouseButtonDown(0))
            {
                // ...Then start the game
                hasStarted = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        // If play has started...
        if (hasStarted) 
        {
            // ...Grab balls current vector.
            Vector2 currentVector = gameObject.GetComponent<Rigidbody2D>().velocity;
            // If ball is moving too slowly, reset velocity
            if (currentVector.magnitude <= 9)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                bounce.Play();
            }
            // Otherwise, tweak velocity by random amount
            else
            {
                Vector2 tweak = new Vector2(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));
                GetComponent<Rigidbody2D>().velocity += tweak;
                bounce.Play();
            }
        }
    }
}
