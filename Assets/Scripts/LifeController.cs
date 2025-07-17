using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxHP = 5;
    [SerializeField] private int _currentHP;

    public UnityEvent onDeath;
    public UnityEvent<float> onLifeChanged;

    void Start()
    {
        _currentHP = _maxHP;
        onLifeChanged?.Invoke(GetLifePercent());
    }

    public void ReduceLife(int amount)
    {
        _currentHP -= amount;
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);

        onLifeChanged?.Invoke(GetLifePercent());

        if (_currentHP <= 0)
        {
            Debug.Log("Player morto!");
            onDeath?.Invoke();
        }
    }

    public float GetLifePercent()
    {
        return (float)_currentHP / _maxHP;
    }
}
