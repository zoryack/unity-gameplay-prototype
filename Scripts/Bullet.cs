using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }

        Destroy(gameObject);
    }

}
