using UnityEngine;

public class MeteorSpawner : MonoBehaviour, IIntervalSpawner
{
    [SerializeField] private Transform[] _spawnPoints;
    public Transform[] SpawnPoints => _spawnPoints;

    [SerializeField] private float _spawnInterval;
    public float Interval => _spawnInterval;

    [SerializeField] private GameObject _meteorPrefab;
    public GameObject SpawnObjectPrefab => _meteorPrefab;

    [SerializeField] private float _spawnRadius;
    [SerializeField] private Transform _planetTransform;

    private float _elapsedTime;

    private void Update()
    {
        if (_elapsedTime < _spawnInterval)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            var meteor = Instantiate(_meteorPrefab, spawnPoint.position + (Vector3)Random.insideUnitCircle * _spawnRadius, Quaternion.identity).GetComponent<Meteor>();
            meteor.Move(_planetTransform.position - meteor.transform.position);
            _elapsedTime = 0f;
        }
    }
}