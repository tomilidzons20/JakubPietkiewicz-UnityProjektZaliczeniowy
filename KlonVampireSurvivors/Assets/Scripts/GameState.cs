using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    public PauseMenu pauseMenu;

    public void GameOver()
    {
        pauseMenu.StopTime();
        PauseMenu.canPause = false;
        gameOverScreen.SetActive(true);
    }

    public void Victory()
    {
        pauseMenu.StopTime();
        PauseMenu.canPause = false;
        victoryScreen.SetActive(true);
    }

    public void Restart()
    {
        pauseMenu.StartTime();
        PauseMenu.canPause = true;
        SceneManager.LoadScene("GameScene");
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }
}
