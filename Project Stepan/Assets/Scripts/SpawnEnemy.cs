using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private float _timeSpawn;
    private float _startSpawn;
    
    private float _move = 0.6f;
    private float _randX;
    private Vector2 _whereToSpawn;
    
    void Start()
    {
        _startSpawn = _timeSpawn;
    }

    void Update()
    {
        if (_move <= 0)
        {
            _randX = Random.Range(-11.5f, 11.5f);
            _whereToSpawn = new Vector2(_randX, transform.position.y);
            transform.position = _whereToSpawn;
            _move = 0.6f;
        }
        else
        {
            _move -= Time.deltaTime;
        }
        
        if (_startSpawn <= 0)
        {
            Instantiate(_enemy, _spawnPos.position, Quaternion.identity);
            _startSpawn = _timeSpawn;
        }
        else
        {
            _startSpawn -= Time.deltaTime;
        }
    }
}