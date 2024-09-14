using Unity.VisualScripting;
using UnityEngine;

public class Meteor : Projectile, IDamageable
{
    [SerializeField] const float _dropChance = 10f / 10f;
    [SerializeField] private GameObject[] _powerupPrefab;

    public Transform _powerupAnchor;
    public ParticleSystem destructionEffect;
    private Vector2 directionToPlanet;

    #region Health
    [Header("Health")]
    [SerializeField] private float _maxHealth = 5f;
    private float _currentHealth;
    private bool _isDestroyed;

    public float MaxHealth => _maxHealth;

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

    public virtual void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (IsDestroyed)
        {
            DropPowerup();
            ParticleSystem explosionEffect = Instantiate(destructionEffect) as ParticleSystem;
            explosionEffect.transform.position = transform.position;
            Destroy(explosionEffect.gameObject, explosionEffect.duration);

            Destroy(gameObject);

        }
    }
    #endregion

    public override void Move(Vector2 upDirection)
    {
        Rigidbody2D.AddForce(upDirection * MovementSpeed);
        directionToPlanet = upDirection;
        
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        ParticleSystem explosionEffect = Instantiate(destructionEffect) as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        Destroy(explosionEffect.gameObject, explosionEffect.duration);

        // We only destroy the meteor in the bounds if it has been blown off-course by the player
        // This is because the meteors can spawn beyond the bounds based on our MeteorSpawner script
        if (CurrentHealth < MaxHealth && other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }

    [Header("Appearance")]
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] _sprites;

    private void Start()
    {
        _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
    }

    public void DropPowerup()
    {
            if (Random.Range(0f, 1f) <= _dropChance)
            {
                var powerup = Instantiate(_powerupPrefab[Random.Range(0, _powerupPrefab.Length)], _powerupAnchor.position, Quaternion.identity).GetComponent<Powerup>();
                powerup.Move(directionToPlanet);
            }
    }
}