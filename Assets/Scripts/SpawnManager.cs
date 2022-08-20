using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Portal[] _spawnPoints;

    private float _spawnTime;
    private float _spawnCooldown = 2f;
    private int _currentSpawnPointNumber = 0;
    private Portal _currentPortal;

    private void Awake()
    {
        _spawnTime = _spawnCooldown;
    }

    private void Update()
    {
        if (_spawnTime <= 0 && _currentSpawnPointNumber < _spawnPoints.Length)
        {
            _currentPortal = _spawnPoints[_currentSpawnPointNumber];
            Instantiate(_enemy, _currentPortal.transform.position, Quaternion.identity);
            _spawnTime = _spawnCooldown;
            _currentSpawnPointNumber++;
        }
        else
        {
            _spawnTime -= Time.deltaTime;
        }
    }
}
