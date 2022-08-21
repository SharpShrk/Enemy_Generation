using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Portal[] _points;

    private float _cooldown = 2f;
    private Portal _currentPortal;
    private Coroutine _spawnEnemy;

    private void Awake()
    {
        _spawnEnemy = StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitTwoSeconds = new WaitForSeconds(2f);

        for (int i = 0; i < _points.Length; i++)
        {
            _currentPortal = _points[i];
            Instantiate(_enemy, _currentPortal.transform.position, Quaternion.identity);
            yield return waitTwoSeconds;
        }
    }
}
