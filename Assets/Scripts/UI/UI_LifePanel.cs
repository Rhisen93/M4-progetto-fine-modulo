using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifePanel : MonoBehaviour
{
    [SerializeField] private Image _lifeFillable;
    [SerializeField] private TextMeshProUGUI _lifeText;
    
    public void UpdateGraphics(int currentHp, int maxHp)
    {
        _lifeText.text = "HP " + currentHp + "/" + maxHp;
        _lifeFillable.fillAmount = (float)currentHp / maxHp;
    }
}
