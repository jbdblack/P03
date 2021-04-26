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
            //ThrowBomb();
            CreateBomb();
        }
    }

    public void CreateBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);
        Debug.Log(bomb + "is created");
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.useGravity = false;

    }


    void ThrowBomb()
    {
        // Find the created bomb
        GameObject bomb = GameObject.Find("bomb");

        // Turn on gravity and apply force
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }


}
