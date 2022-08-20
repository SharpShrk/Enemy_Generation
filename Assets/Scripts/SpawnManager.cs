using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Portal[] _spawnPoints;

    private float _spawnTime;
    private float _spawnCooldown = 2f;
    private Queue<Portal> _spawnQueue;
    private Portal _currentSpawnPoint;

    private void Awake()
    {
        _spawnTime = _spawnCooldown;
        Queue<Portal> _spawnQueue = new Queue<Portal>();

        foreach(var point in _spawnPoints)
        {
            _spawnQueue.Enqueue(point);
        }
    }

    private void Update()
    {
        if (_spawnTime <= 0)
        {
            _currentSpawnPoint = _spawnQueue.Dequeue();
            Instantiate(_enemy, _currentSpawnPoint.transform.position, Quaternion.identity);
            _spawnTime = _spawnCooldown;
        }
        else
        {
            _spawnTime -= Time.deltaTime;
        }
    }
}
