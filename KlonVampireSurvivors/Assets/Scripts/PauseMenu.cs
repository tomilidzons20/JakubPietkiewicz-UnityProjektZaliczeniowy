using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool PlayerLevelUps = false;

    public GameObject pauseMenu;

    public PlayerStats playerStats;

    public TMP_Text playerStatsText;

    void Update()
    {
        if(PlayerLevelUps)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        UpdateStatsInfo();
    }

    void UpdateStatsInfo()
    {
        if (playerStats != null)
        {
            // One string cause I don't want to spend time alining every text object
            playerStatsText.text = 
                $"HP: {playerStats.health.currentHealth} / {playerStats.health.maxHealth}\n" +
                $"+1HP / {playerStats.healthRegen}s\n" +
                $"MoveSpeed: {playerStats.moveSpeed}\n" +
                $"\nProjectiles:\n" +
                $"Damage: {playerStats.projectileDamage}\n" +
                $"Speed: {playerStats.projectileSpeed}%\n" +
                $"Duration: {playerStats.projectileDuration}%\n" +
                $"Pierce: {playerStats.projectilePierce} \n";
        }
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("MenuScene");
    }
}
