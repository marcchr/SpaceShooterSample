public interface IDamageable
{
    Health Health { get; }
    bool IsDestroyed { get; }
    abstract void TakeDamage(float damageAmount);
}