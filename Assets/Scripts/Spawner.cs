using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Portal[] _points;

    private float _cooldown = 2f;
    private int _currentPointNumber = 0;
    private Portal _currentPortal;
    private Coroutine _spawnEnemy;

    private void Awake()
    {
        _spawnEnemy = StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_currentPointNumber < _points.Length)
        {
            _currentPortal = _points[_currentPointNumber];
            Instantiate(_enemy, _currentPortal.transform.position, Quaternion.identity);
            _currentPointNumber++;
            yield return new WaitForSeconds(_cooldown);
        }
        
        if (_currentPointNumber == _points.Length)
        {
            StopCoroutine(_spawnEnemy);
        }
    }
}
