using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text experienceText;

    public void SetExperience(float experience)
    {
        slider.value = experience;
        SetExperienceText();
    }

    public void SetMaxExperience(float maxExperience)
    {
        slider.maxValue = maxExperience;
        SetExperienceText();
    }

    public void SetExperienceText()
    {
        experienceText.text = $"{slider.value}/{slider.maxValue}";
    }
}
