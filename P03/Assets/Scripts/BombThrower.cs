using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrower : MonoBehaviour
{
    public float throwForce = 10f;
    public GameObject bombPrefab;
    [SerializeField] Transform bombSpawn;

    

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButton(0))
        {
            ThrowBomb();
        }*/

        if (Input.GetKeyDown("space"))
        {
            ThrowBomb();
        }
    }

    void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
