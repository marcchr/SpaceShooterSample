using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : Projectile
{
    [SerializeField] private Transform _planetTransform;


    public override void Move(Vector2 upDirection)
    {
        Rigidbody2D.AddForce(upDirection * MovementSpeed);

    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }

   
}
