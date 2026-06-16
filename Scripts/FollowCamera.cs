using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject PosPY;
    public float X_PosPY;
    public float Y_posPY;
    public float Z_posPY;

    // Start is called before the first frame update
    void Start()
    {
        PosPY = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(
            PosPY.transform.position.x + X_PosPY,
            PosPY.transform.position.y + Y_posPY,
            PosPY.transform.position.z + Z_posPY);
    }
}
