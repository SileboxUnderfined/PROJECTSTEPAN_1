using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private bool already;
    private bool moving;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.5f);
    }

    private void Update()
    {
        if(Hero.isForward && already == false)
        {
            // transform.Translate(Vector3.up * 18 * Time.deltaTime);
            rb.AddForce(Vector2.up * 0.1f);
            already = true;
        }

        if(Hero.isRight && already == false )
        {
            // transform.Translate(Vector3.right * 18 * Time.deltaTime);
            rb.AddForce(Vector2.right * 0.1f);
            already = true;
        }

        if(Hero.isLeft && already == false)
        {
            // transform.Translate(Vector3.left * 18 * Time.deltaTime);
            rb.AddForce(Vector2.left * 0.1f);
            already = true;
        }
    }
}
