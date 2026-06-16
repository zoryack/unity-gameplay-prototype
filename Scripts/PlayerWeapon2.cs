using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon2 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public new Camera camera;
    public Transform spawner;
    public GameObject habilidad1Prefab;

    bool canAtackk = true;
    bool isAtackingg;
    [SerializeField] float atackCooldownn = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        canAtackk = true;
    }
    void Update()
    {

        if (isAtackingg)
        {
            return;
        }

        RotateTowardsMouse();

        if (Input.GetKeyDown(KeyCode.E) && canAtackk)
        {
            StartCoroutine(Atacandoo());
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
        if (isAtackingg)
        {
            return;
        }
    }
    private IEnumerator Atacandoo()
    {
        canAtackk = false;
        isAtackingg = true;
        GameObject bullet1 = Instantiate(habilidad1Prefab);
        bullet1.transform.position = spawner.position;
        bullet1.transform.rotation = transform.rotation;
        Destroy(bullet1, 2f);
        yield return new WaitForSeconds(atackCooldownn);
        isAtackingg = false;

        canAtackk = true;
    }
}
