using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text healthText;

    public void SetHealth(float health)
    {
        slider.value = health;
        SetHealthText();
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        SetHealthText();
    }

    public void SetHealthText()
    {
        healthText.text = $"{slider.value}/{slider.maxValue}";
    }
}
