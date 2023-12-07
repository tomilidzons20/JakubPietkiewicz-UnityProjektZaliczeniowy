using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveInfo : MonoBehaviour
{
    public TMP_Text waveInfoText;
    private int totalWaves;

    public void SetTotalWaves(int waves)
    {
        totalWaves = waves;
    }

    public void SetCurrentWave(int currentWave)
    {
        waveInfoText.text = $"Wave: {currentWave}/{totalWaves}";
    }
}
