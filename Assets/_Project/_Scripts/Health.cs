using System;
using UnityEngine;

[Serializable]
public class Health
{
    public bool IsDepleted { get; private set; }

    [field: SerializeField] public float MaxHealth { get; private set; }

    private float _currentHealth;
    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Mathf.Clamp(value, 0f, MaxHealth);
            IsDepleted = _currentHealth == 0f;
        }
    }
}