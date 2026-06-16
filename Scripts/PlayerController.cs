using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
    private Animator animator;
    private new Rigidbody2D rigidbody;
    private Vector3 velocity;

    public float speed;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;
    bool canDash = true;

    void Start() {
        canDash = true;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing) 
        {
            return;
        }


        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if (hor != 0 || ver != 0)
        {
            animator.SetFloat("Horizontal", hor);
            animator.SetFloat("Vertical", ver);
            animator.SetFloat("Speed", 1);

            Vector3 direction = (Vector3.up * ver + Vector3.right * hor).normalized;
            velocity = direction * speed;
        }
        else
        {
            animator.SetFloat("Speed", 0);
            velocity = Vector3.zero;
        }


        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash) 
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate() 
    {
        if (isDashing)
        {
            return;
        }
        rigidbody.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rigidbody.velocity = new Vector2 (velocity.x * dashSpeed, velocity.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
