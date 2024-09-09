using UnityEngine;

public interface IShooter
{
    Transform[] SpawnPoints { get; }
    Bullet Bullet { get; }
    abstract void Shoot(Vector2 upDirection);
}