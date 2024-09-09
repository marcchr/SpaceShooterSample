using UnityEngine;

public class Planet : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth = 100f;
    private Health _health;
    public Health Health => _health;

    public bool IsDestroyed => _health.IsDepleted;

    public Health InitializeHealth(float maxHealth)
    {
        return new(maxHealth);
    }
    private void Awake()
    {
        _health = InitializeHealth(_maxHealth);
    }
    public void TakeDamage(float damageAmount)
    {
        _health.CurrentHealth -= damageAmount;
        print($"{_health.CurrentHealth}/{_health.MaxHealth}");
    }
}