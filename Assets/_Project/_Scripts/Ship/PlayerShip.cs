using UnityEngine;

public class PlayerShip : Ship, IShooter
{
    [Header("Shooting")]
    [SerializeField] private Bullet _bullet;
    public Bullet Bullet => _bullet;
    [SerializeField] private Transform[] _spawnPoints;
    public Transform[] SpawnPoints => _spawnPoints;

    public void Shoot(Vector2 upDirection)
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            var bullet = Instantiate(_bullet, spawnPoint.position, Quaternion.identity);
            bullet.Move(upDirection);
        }
    }
}