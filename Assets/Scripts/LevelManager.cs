using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public int currentLevel = 0;
    public int ballsRemaining;

    void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        currentLevel = 1;
        ballsRemaining = 3;
        Ball.ballsInPlay = 0;
        BrickControl.blocksRemaining = 0;
        SceneManager.LoadScene("Level_01");
    }
    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LevelComplete()
    {
        currentLevel++;
        if (currentLevel >= 6)
        {
            SceneManager.LoadScene("Win");
        } else
        {
            SceneManager.LoadScene("Level_Complete");
        }
    }

    public void NextLevel()
    {
        BrickControl.blocksRemaining = 0;
        ballsRemaining += (Ball.ballsInPlay-1);
        Ball.ballsInPlay = 0;
        Ball.hasStarted = false;
        SceneManager.LoadScene(currentLevel);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Start");
        Destroy(gameObject);
    }

    public void BlockCheck()
    {
        if(BrickControl.blocksRemaining <= 0)
        {
            LevelComplete();
        }
    }

    public void BallLost()
    {
        ballsRemaining--;
        if (ballsRemaining <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
