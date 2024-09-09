using UnityEngine;

public abstract class Bullet : MonoBehaviour, IPhysicsMovable
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    [SerializeField] float _movementSpeed;
    public float MovementSpeed => _movementSpeed;

    public virtual void Move(Vector2 upDirection)
    {
        transform.up = upDirection;
        _rigidbody2D.AddForce(upDirection * _movementSpeed, ForceMode2D.Impulse);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }
}