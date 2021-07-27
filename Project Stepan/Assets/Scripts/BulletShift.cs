using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShift : MonoBehaviour
{
    [SerializeField] private float _speedWhenShift;
    private Transform _enemy;
    
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void Update()
    {
        _enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        transform.position = Vector2.MoveTowards(transform.position, _enemy.position, _speedWhenShift * Time.deltaTime);
        transform.LookAt(_enemy.transform);
    }
}
