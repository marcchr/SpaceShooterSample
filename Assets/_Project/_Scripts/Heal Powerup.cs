using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerup : Powerup
{
    public override void PickUp(Collider2D player)
    {

        if (player.attachedRigidbody.TryGetComponent<PlayerShip>(out var ship))
        {
            // ship.Planet.CurrentHealth += 20;         
            Debug.Log("Planet Healed by 20");
        }

        Destroy(gameObject);
    }
}
