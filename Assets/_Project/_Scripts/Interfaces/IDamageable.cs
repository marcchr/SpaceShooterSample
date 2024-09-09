public interface IDamageable
{
    Health Health { get; }
    bool IsDestroyed { get; }
    Health InitializeHealth(float maxHealth);
    abstract void TakeDamage(float damageAmount);
}