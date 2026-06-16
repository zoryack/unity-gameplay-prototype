using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : MonoBehaviour
{
    public string playerTag = "Player"; // Tag del jugador
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;

    private bool isDashing = false;
    private float dashTimer = 0f;

    void Update()
    {
        dashTimer += Time.deltaTime;

        if (dashTimer >= dashCooldown && !isDashing)
        {
            Dash();
        }
    }

    private void Dash()
    {
        isDashing = true;

        // Buscamos al jugador por su tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        // Si encontramos al jugador, calculamos la dirección y teletransportamos
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            transform.position += direction * dashSpeed;
        }

        StartCoroutine(EndDash());
    }

    private IEnumerator EndDash()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        dashTimer = 0f;
    }
}