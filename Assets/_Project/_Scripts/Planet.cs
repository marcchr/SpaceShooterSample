using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;
    private bool _isDestroyed;

    public float MaxHealth => _maxHealth;
    public Image HealthBar;

    private PlayerShip thisPlanet;

    private void Start()
    {
        thisPlanet.PlanetInit(this);
    }

    public float CurrentHealth
    {
        get
        {
            // Start from the MaxHealth if the default value is zero
            if (_currentHealth == 0 && !_isDestroyed)
            {
                return MaxHealth;
            }
            else
            {
                return _currentHealth;
            }
        }

        private set
        {
            _currentHealth = Mathf.Clamp(value, 0f, MaxHealth);
            _isDestroyed = _currentHealth == 0;
        }
    }

    public bool IsDestroyed => _isDestroyed;

    public void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
        print($"{name}: {CurrentHealth}/{MaxHealth}");
    }
}