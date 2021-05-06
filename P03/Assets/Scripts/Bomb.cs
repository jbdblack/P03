using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    private AudioSource source;
    [SerializeField] AudioClip explosion;

    BombThrower bombStatus;



    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        bombStatus = GameObject.FindWithTag("Player").GetComponent<BombThrower>();

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.F))
        {
            Explode();
            hasExploded = true;
        }


    }

    void Explode()
    {
        Debug.Log("BOOM");

        // Show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        // Get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            // Add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            
        }

        // Sound Effect
        AudioSource.PlayClipAtPoint(explosion, this.gameObject.transform.position);

        bombStatus.bombCreated = false;
        
        // Remove grenade
        Destroy(gameObject);
    }

}
