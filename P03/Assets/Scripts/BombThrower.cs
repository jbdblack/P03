using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrower : MonoBehaviour
{
    public float throwForce = 0.3f;
    public GameObject bombPrefab;
    [SerializeField] Transform bombSpawn;
    public bool bombCreated = false;
    public bool bombThrown = false;
    public Transform _transform;
    public GameObject currentBomb;
    

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown("space") && bombCreated != true)
        {
            CreateBomb();
        }
        else if(Input.GetKeyDown("space") && bombCreated == true)
        {
            ThrowBomb();
        }

        

        /*if (Input.GetKeyDown(KeyCode.C))
        {
            ThrowBomb(); 
        }*/

        MoveBomb();

    }

    public void CreateBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);
        Debug.Log(bomb + "is created");
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.useGravity = false;
        bombCreated = true;
        bombThrown = false;
        Debug.Log("Bomb created");

    }


    void ThrowBomb()
    {
        // Find the created bomb
        //GameObject bomb = GameObject.Find("bomb");
        Rigidbody rb = GameObject.FindWithTag("Bomb").GetComponent<Rigidbody>();

       if(bombThrown == false)
        {
            rb.useGravity = true;

            rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
            rb.AddForce(transform.up * (throwForce / 2), ForceMode.Impulse);
            bombThrown = true;
            Debug.Log("Bomb thrown");
        }
       
    }

    public void MoveBomb()
    {
        if (bombCreated == true && bombThrown == false)
        {
            currentBomb = GameObject.FindWithTag("Bomb");
            currentBomb.transform.position = bombSpawn.transform.position;
        }


    }


}
