using UnityEngine;
using UnityEngine.Events;


public class LifeController : MonoBehaviour
{
    [SerializeField] private int _currentHp = 20;
    [SerializeField] private int _maxHp = 20;
    [SerializeField] private bool _fullHpOnAwake = true;

    [SerializeField] private UnityEvent<int, int> _onHpChanged;
    [SerializeField] private UnityEvent _onDeath;

    private void Awake()
    {
        if (_fullHpOnAwake)
        {
            SetHp(_maxHp);
        }
    }

    public void SetHp(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);

        _currentHp = hp;


        _onHpChanged?.Invoke(_currentHp, _maxHp);

        if (_currentHp == 0)
        {
            Debug.Log($"{gameObject.name} è deceduto.");
            _onDeath?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Player colpito!");

            SetHp(_currentHp - 5);
            _onHpChanged?.Invoke(_currentHp, _maxHp);
        }
    }

    public void AddHp(int amount) => SetHp(_currentHp + amount);


}