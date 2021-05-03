using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrower : MonoBehaviour
{
    public float throwForce = 0.3f;
    public GameObject bombPrefab;
    [SerializeField] Transform bombSpawn;
    public bool bombCreated = false;
    public Transform _transform;
    public GameObject currentBomb;
    

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButton(0))
        {
            ThrowBomb();
        }*/

        if (Input.GetKeyDown("space") && bombCreated != true)
        {
            //ThrowBomb();
            CreateBomb();
        }

        

        if (Input.GetKey(KeyCode.C))
        {
            ThrowBomb(); 
        }

        MoveBomb();

    }

    public void CreateBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);
        Debug.Log(bomb + "is created");
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.useGravity = false;
        bombCreated = true;

    }


    void ThrowBomb()
    {
        // Find the created bomb
        //GameObject bomb = GameObject.Find("bomb");
        Rigidbody rb = GameObject.FindWithTag("Bomb").GetComponent<Rigidbody>();

        // Turn on gravity and apply force
        //Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        bombCreated = false;
    }

    public void MoveBomb()
    {
        if (bombCreated == true)
        {
            currentBomb = GameObject.FindWithTag("Bomb");
            currentBomb.transform.position = bombSpawn.transform.position;
        }


    }


}
