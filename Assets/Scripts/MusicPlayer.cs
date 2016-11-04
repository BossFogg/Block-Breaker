using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public static MusicPlayer instance = null;

    void Awake ()
    {
        Debug.Log("MusicPlayer instance awake " + GetInstanceID());
        if (instance != null)
        {
            Debug.Log("MusicPlayer instance self-destruct " + GetInstanceID());
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        Debug.Log("MusicPlayer instance start " + GetInstanceID());
        
	}
	
}
