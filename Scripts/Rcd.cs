using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rcd : MonoBehaviour
{
    public GameObject canvas; // Referencia al Canvas
    public Image cooldownBar; // Referencia a la barra de enfriamiento
    public float cooldownTime = 2f; // Tiempo de enfriamiento en segundos
    public KeyCode attackKey = KeyCode.R; // Tecla de ataque

    private float cooldownTimer = 0f;

    void Update()
    {
        // Actualizar el timer de enfriamiento
        cooldownTimer -= Time.deltaTime;
        cooldownTimer = Mathf.Clamp(cooldownTimer, 0, cooldownTime);

        // Actualizar la barra de enfriamiento
        cooldownBar.fillAmount = cooldownTimer / cooldownTime;

        // Si se presiona la tecla de ataque y no está en enfriamiento
        if (Input.GetKeyDown(attackKey) && cooldownTimer <= 0)
        {
            // Lógica de ataque (ejemplo)
            cooldownTimer = cooldownTime;
        }
    }
}