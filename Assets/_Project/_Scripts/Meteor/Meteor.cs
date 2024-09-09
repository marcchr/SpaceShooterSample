using UnityEngine;

public class Meteor : Projectile, IDamageable
{
    [SerializeField] private float _maxHealth;
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

    public override void Move(Vector2 upDirection)
    {
        Rigidbody2D.AddForce(upDirection * MovementSpeed);
    }

    public void TakeDamage(float damageAmount)
    {
        _health.CurrentHealth -= damageAmount;
        print($"{name}: {_health.CurrentHealth}/{_health.MaxHealth}");
        if (IsDestroyed)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}