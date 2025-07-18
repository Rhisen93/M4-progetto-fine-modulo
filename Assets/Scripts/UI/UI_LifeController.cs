using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{
    [SerializeField] private Image _lifeBar;
    [SerializeField] private Gradient _gradient;

    public void UpdateLifeBar(int hp, int hpMax)
    {
        _lifeBar.fillAmount = (float)hp / hpMax;

        _lifeBar.color = _gradient.Evaluate(_lifeBar.fillAmount);
    }
}