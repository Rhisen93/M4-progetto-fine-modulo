using UnityEngine;
using UnityEngine.Events;


public class LifeController : MonoBehaviour
{
    [SerializeField] private int _hp = 10;
    public int Hp
    {
        get => _hp;
        private set => _hp = Mathf.Max(0, Mathf.Abs(value));
    }
    private int _hpMax = 10;
    [SerializeField] private bool _hpMaxOnAwake = true;

    [SerializeField] private UnityEvent<int, int> _onTakeDamage;

    void Awake()
    {
        if (_hp <= 0 || _hpMaxOnAwake)
        {
            _hp = _hpMax;
        }
    }

    void Start()
    {
        UIUpdate();
    }

    public void TakeDamage(int damage)
    {
        _hp -= Mathf.Abs(damage);
        UIUpdate();

        if (!IsAlive())
        {
            Hp = 0;
            DestroyCharacter();
        }
    }

    public bool IsAlive() => _hp > 0;

    private void DestroyCharacter()
    {
        Destroy(this.gameObject);
        Debug.Log($"Il character {this.gameObject.name} è stato distrutto");
    }

    public void Cure()
    {
        _hp += Mathf.Abs(2);
        UIUpdate();

        if (_hp > _hpMax)
        {
            _hp = _hpMax;
            Debug.Log($"Il character {this.gameObject.name} ha la vita al massimo");
        }
    }

    private void UIUpdate() => _onTakeDamage.Invoke(_hp, _hpMax);
}