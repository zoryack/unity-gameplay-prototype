using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon1 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public new Camera camera;
    public Transform spawner;
    public GameObject habilidadPrefab;

    bool canAtack = true;
    bool isAtacking;
    [SerializeField] float atackCooldown = 1f;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        canAtack = true;
    }
    void Update()
    {

        if (isAtacking)
        {
            return;
        }

        RotateTowardsMouse();

        if (Input.GetKeyDown(KeyCode.Q) && canAtack)
        {
            StartCoroutine(Atacando());
        }

    }

    private void RotateTowardsMouse()
    {
        float angle = GetAngleTowardsMouse();

        transform.rotation = Quaternion.Euler(0, 0, angle);
        spriteRenderer.flipY = angle >= 90 && angle <= 270;
    }


    private float GetAngleTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;

        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;

        return angle;
    }


    void FixedUpdate()
    {
        
        if (isAtacking)
        {
            return;
        }
    }
    private IEnumerator Atacando()
    {
        canAtack = false;
        isAtacking = true;
        GameObject bullet1 = Instantiate(habilidadPrefab);
        bullet1.transform.position = spawner.position;
        bullet1.transform.rotation = transform.rotation;
        Destroy(bullet1, 2f);
        yield return new WaitForSeconds(atackCooldown);
        isAtacking = false;
        
        canAtack = true;
    }
}
