using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPosBullet;
    [SerializeField] private int _hp;
    private float _startTimeShot;
    public float TimeShot;
    
    void Start()
    {
        _startTimeShot = TimeShot;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        //малик только не пиши мне что можно же через rb.velocite("Horizontal"), тут так не получится тк 2д управление в 3д проекте

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed -= 2;
            Bullet.FindEnemy = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed += 2;
            Bullet.FindEnemy = false;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (_startTimeShot <= 0)
            {
                Instantiate(_bullet, _spawnPosBullet.position, Quaternion.identity);
                _startTimeShot = TimeShot;
            }
            else
            {
                _startTimeShot -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            _hp -= 1;
            Destroy(other.gameObject);

            if (_hp <= 0)
            {
                Debug.Log("Конец игры");
            }
        }
    }
}