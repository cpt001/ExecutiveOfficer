using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ProjectileFlight : MonoBehaviour
{
    private Rigidbody projectile;
    private float projectileSpeed = 8000;
    private float detectionDistance = 5;
    public GameObject explosive;
    private float expirationTimer = 10.0f;
    private float timeElapsed;

    private int barrelLayerMask;   //~ inverts it, meaning the projectile would hit everything BUT turretog -- other way around. Idiot.
    private float damageToDeal = 10;

    private void Awake()
    {
        barrelLayerMask = LayerMask.GetMask("SpawnPoint");
        projectile = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        projectile.AddForce(transform.forward * projectileSpeed);
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, transform.forward * detectionDistance, Color.red, Mathf.Infinity, true);
        RaycastHit rayHit;
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, detectionDistance, ~barrelLayerMask))
        {
            //Debug.Log("Collision Detected" + Physics.Raycast(transform.position, transform.forward, detectionDistance, barrelLayerMask));
            if (rayHit.transform.GetComponent<SimpleHealth>())
            {
                rayHit.transform.GetComponent<SimpleHealth>().damageTaken = damageToDeal;
                rayHit.transform.GetComponent<SimpleHealth>().damageApplied = false;
            }
            HitSomething();
        }

        timeElapsed += Time.deltaTime;

        if (timeElapsed > expirationTimer)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Shootable")
        {
            other.gameObject.GetComponent<SimpleHealth>().damageTaken = damageToDeal;
            other.gameObject.GetComponent<SimpleHealth>().damageApplied = false;
            HitSomething();
        }
    }

    private void HitSomething()
    {
        Instantiate(explosive, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
