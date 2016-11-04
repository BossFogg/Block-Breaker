using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;
    private BallsRemaining ballsRemaining;

    void Start ()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        ballsRemaining = GameObject.FindObjectOfType<BallsRemaining>();
        ballsRemaining.DisplayBallCount();
    }

    void OnTriggerEnter2D (Collider2D triggerBall)
    {
        if (Ball.ballsInPlay>=2)
        {
            Ball.ballsInPlay--;
            Destroy(triggerBall.gameObject);
        } else
        {
            Ball.hasStarted = false;
            levelManager.BallLost();
            ballsRemaining.DisplayBallCount();
        }
    } 

}
