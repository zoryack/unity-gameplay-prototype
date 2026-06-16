using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet3 : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 30f;
    [SerializeField] int life = 10;

    private Vector2 direction;


    public void Shoot(Vector2 direction)
    {
        this.direction = direction;
        rb.velocity = this.direction * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        life--;
        if (life < 0)
        {
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(2);
        }


        var firstContact = collision.contacts[0];
        Vector2 newVelocity = Vector2.Reflect(direction.normalized, firstContact.normal);
        Shoot(newVelocity.normalized);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        life--;
        if (life < 0)
        {
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(2);
        }

    }

}
