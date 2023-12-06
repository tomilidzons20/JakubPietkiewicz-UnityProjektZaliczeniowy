using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool canPause = true;

    public GameObject pauseMenu;

    public PlayerStats playerStats;

    public TMP_Text playerStatsText;

    void Update()
    {
        if(!canPause)
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
        StartTime();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        StopTime();
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
                $"EXP: {playerStats.experience}/{playerStats.experienceToLevel}\n" +
                $"MoveSpeed: {playerStats.moveSpeed}\n\n" +
                $"Damage: {playerStats.projectileDamage}%\n" +
                $"Speed: {playerStats.projectileSpeed}%\n" +
                $"Duration: {playerStats.projectileDuration}%\n" +
                $"Pierce: {playerStats.projectilePierce} \n";
        }
    }

    public void StopTime()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        Resume();
        canPause = true;
        SceneManager.LoadScene("MenuScene");
    }
}
