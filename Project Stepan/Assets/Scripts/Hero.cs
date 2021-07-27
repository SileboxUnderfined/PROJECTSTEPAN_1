using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Hero : MonoBehaviour
{

    [SerializeField] private Animator _anim;



    [SerializeField] private GameObject _shootEffect;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletShift;
    [SerializeField] private Transform _spawnPosBullet;
    [SerializeField] private Transform _spawnPosBulletRight;
    [SerializeField] private Transform _spawnPosBulletLeft;
    [SerializeField] private int _hp;
    [SerializeField] private float _speed;

    private float _startTimeShot;
    public float TimeShot;
    private bool isFocus;



    public static bool isForward, isLeft, isRight;

    private void Start()
    {
        _startTimeShot = TimeShot;
    }

    private void Update()
    {
        Moving();
        FocusMode();
        Shooting();

    }



    private void Shooting()
    {
        if (Input.GetKey(KeyCode.Z))
        {

            if (_startTimeShot <= 0 && isFocus == false)
            {
                if(Hero.isForward)
                {
                    Instantiate(_bullet, _spawnPosBullet.position, _spawnPosBullet.rotation);
                    Instantiate(_shootEffect, _spawnPosBullet.position, _spawnPosBullet.rotation);                    
                }
                if(Hero.isLeft)
                {
                    Instantiate(_bullet, _spawnPosBulletLeft.position, _spawnPosBulletLeft.rotation);
                    Instantiate(_shootEffect, _spawnPosBulletLeft.position, _spawnPosBulletLeft.rotation);                        
                }
                if(Hero.isRight)
                {
                    Instantiate(_bullet, _spawnPosBulletRight.position, _spawnPosBulletRight.rotation);
                    Instantiate(_shootEffect, _spawnPosBulletRight.position, _spawnPosBulletRight.rotation);                        
                }
                _startTimeShot = TimeShot;
            }


            if (_startTimeShot <= 0 && isFocus == true)
            {
                if(Hero.isForward)
                {
                    Instantiate(_bulletShift, _spawnPosBullet.position, _spawnPosBullet.rotation);
                    Instantiate(_shootEffect, _spawnPosBullet.position, _spawnPosBullet.rotation);                    
                }
                if(Hero.isLeft)
                {
                    Instantiate(_bulletShift, _spawnPosBulletLeft.position, _spawnPosBulletLeft.rotation);
                    Instantiate(_shootEffect, _spawnPosBulletLeft.position, _spawnPosBulletLeft.rotation);                        
                }
                if(Hero.isRight)
                {
                    Instantiate(_bulletShift, _spawnPosBulletRight.position, _spawnPosBulletRight.rotation);
                    Instantiate(_shootEffect, _spawnPosBulletRight.position, _spawnPosBulletRight.rotation);                        
                }
                _startTimeShot = TimeShot;
            }
            else
            {
                _startTimeShot -= Time.deltaTime;
            }
        }
    }



    private void Moving()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _anim.SetBool("isLeft", false);
            _anim.SetBool("isRight", false);
            transform.Translate(Vector3.up * _speed * Time.deltaTime);

            Hero.isForward = true;
            Hero.isLeft = false;
            Hero.isRight = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _anim.SetBool("isLeft", true);
            _anim.SetBool("isRight", false);
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

            Hero.isForward = false;
            Hero.isLeft = true;
            Hero.isRight = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);

            Hero.isForward = true;
            Hero.isLeft = false;
            Hero.isRight = false;

        }
        if (Input.GetKey(KeyCode.D))
        {

            _anim.SetBool("isLeft", false);
            _anim.SetBool("isRight", true);
            transform.Translate(Vector3.right * _speed * Time.deltaTime);

            Hero.isForward = false;
            Hero.isLeft = false;
            Hero.isRight = true;
        }
    }



    private void FocusMode()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed -= 2;
            isFocus = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed += 2;
            isFocus = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
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