using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallsRemaining : MonoBehaviour {

    private LevelManager levelManager;
    public Text ballsMessage;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        string ballsLeft = "Balls Left: " + (levelManager.ballsRemaining.ToString());
        ballsMessage.text = ballsLeft;
    }

    public void DisplayBallCount()
    {
        string ballsLeft = "Balls Left: " + (levelManager.ballsRemaining.ToString());
        ballsMessage.text = ballsLeft;
    }
}
