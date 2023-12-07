using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static bool GameIsPaused = false;
    // Used to disable pause menu is specific moments like player level ups
    public static bool canPause = true;

    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    public void GameOver()
    {
        PauseGame();
        canPause = false;
        gameOverScreen.SetActive(true);
    }

    public void Victory()
    {
        PauseGame();
        canPause = false;
        victoryScreen.SetActive(true);
    }

    public void Restart()
    {
        ResumeGame();
        canPause = true;
        SceneManager.LoadScene("GameScene");
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }
}
