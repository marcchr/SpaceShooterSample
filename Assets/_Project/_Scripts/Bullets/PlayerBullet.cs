using UnityEngine;

public class PlayerBullet : Projectile
{
    public ParticleSystem destructionEffect;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        ParticleSystem explosionEffect = Instantiate(destructionEffect) as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        explosionEffect.transform.rotation = transform.rotation;
        Destroy(explosionEffect.gameObject, explosionEffect.duration);

        base.OnCollisionEnter2D(other);
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