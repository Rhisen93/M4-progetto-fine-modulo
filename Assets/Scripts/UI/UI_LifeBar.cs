using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeBar : MonoBehaviour
{
    [SerializeField] private LifeController lifeController;
    [SerializeField] private Slider healthSlider;

    void Start()
    {
        if (lifeController != null)
        {
            lifeController.onLifeChanged.AddListener(UpdateUI);
            UpdateUI(lifeController.GetLifePercent()); // inizializza
        }
    }

    private void UpdateUI(float percent)
    {
        if (healthSlider != null)
        {
            healthSlider.value = percent;
        }
    }
}
