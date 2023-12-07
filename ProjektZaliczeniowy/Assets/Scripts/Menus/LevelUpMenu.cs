using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject levelUpMenu;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
    }

    public void OpenLevelUpMenu()
    {
        audioManager.Play("LevelUp");
        levelUpMenu.SetActive(true);
        GameState.PauseGame();
        GameState.canPause = false;
    }

    public void CloseLevelUpMenu()
    {
        levelUpMenu.SetActive(false);
        GameState.ResumeGame();
        GameState.canPause = true;
    }
}
