using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject levelUpMenu;
    public PauseMenu pauseMenu;

    public void OpenLevelUpMenu()
    {
        levelUpMenu.SetActive(true);
        pauseMenu.StopTime();
        PauseMenu.canPause = false;
    }

    public void CloseLevelUpMenu()
    {
        levelUpMenu.SetActive(false);
        pauseMenu.StartTime();
        PauseMenu.canPause = true;
    }
}
