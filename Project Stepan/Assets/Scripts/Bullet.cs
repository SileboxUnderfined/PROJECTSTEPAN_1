using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speedWhenShift;
    private Transform _enemy;
    public static bool FindEnemy;
    
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void Update()
    {
        if (!Bullet.FindEnemy)
        {
            transform.Translate(Vector3.up * 18 * Time.deltaTime);
        }

        if (Bullet.FindEnemy)
        {
            _enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
            transform.position = Vector2.MoveTowards(transform.position, _enemy.position, _speedWhenShift * Time.deltaTime);
        }
    }
}
