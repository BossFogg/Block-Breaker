using UnityEngine;
using System.Collections;

public class LevelCaller : MonoBehaviour {

    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    public void NextLevelCall()
    {
        levelManager.NextLevel();
    }

    public void MenuCall()
    {
        levelManager.BackToMenu();
    }

    public void RestartCall()
    {
        levelManager.StartGame();
    }
}
