using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    public float speed = 3;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(6);
        }
    }
}

