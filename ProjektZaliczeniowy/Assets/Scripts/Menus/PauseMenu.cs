using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public PlayerStats playerStats;
    public PlayerWeaponStats playerWeaponStats;

    public TMP_Text playerStatsText;

    void Update()
    {
        if(!GameState.canPause)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameState.GameIsPaused)
            {
                ClosePauseMenu();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        GameState.PauseGame();
        UpdateStatsInfo();
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        GameState.ResumeGame();
    }

    void UpdateStatsInfo()
    {
        if (playerStats != null)
        {
            // One string cause I don't want to spend time aligning every text object
            playerStatsText.text = 
                $"HP: {playerStats.health.currentHealth} / {playerStats.health.maxHealth}\n" +
                $"+1HP / {playerStats.healthRegen}s\n" +
                $"LVL: {playerStats.level}\n" +
                $"EXP: {playerStats.experience}/{playerStats.experienceToLevel}\n" +
                $"MoveSpeed: {playerStats.moveSpeed:F2}\n\n" +
                $"Damage: {playerWeaponStats.projectileDamage:F2}\n" +
                $"Speed: {playerWeaponStats.projectileSpeed:F2}\n" +
                $"Pierce: {playerWeaponStats.projectilePierce}\n";
        }
    }

    public void LoadMainMenu()
    {
        ClosePauseMenu();
        GameState.canPause = true;
        SceneManager.LoadScene("MainMenuScene");
    }
}
