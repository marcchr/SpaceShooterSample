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
        if (other.attachedRigidbody.CompareTag("Ship"))
        {
            Debug.Log("Power up picked up!");
            PickUp(other);
        }
        if (other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
        
    }

    public virtual void PickUp(Collider2D player)
    {

        if (player.attachedRigidbody.TryGetComponent<PlayerShip>(out var ship))
        {
            ship.Controller.SpeedMultiplier += 1;
            Debug.Log("Speed increased");
        }

        Destroy(gameObject);
    }
   
}
