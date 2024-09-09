using UnityEngine;

public abstract class Ship : MonoBehaviour, IPhysicsMovable, IDamageable
{
    #region Health
    [Header("Health")]
    [SerializeField] private Health _health;
    public Health Health => _health;
    public bool IsDestroyed => _health.IsDepleted;
    public virtual void TakeDamage(float damageAmount)
    {
        _health.CurrentHealth -= damageAmount;
    }
    #endregion

    #region Movement
    [Header("Movement")]
    [SerializeField] private float _movementSpeed;
    public float MovementSpeed => _movementSpeed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    #endregion
}
