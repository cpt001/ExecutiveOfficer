using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ProjectileFlight : MonoBehaviour
{
    private Rigidbody projectile;
    private float projectileSpeed = 5000;
    private float detectionDistance = 5;
    public GameObject explosive;
    private float expirationTimer = 10.0f;
    private float timeElapsed;

    private int barrelLayerMask;   //~ inverts it, meaning the projectile would hit everything BUT turretog -- other way around. Idiot.

    private void Awake()
    {
        barrelLayerMask = LayerMask.GetMask("TurretOrigins");
        projectile = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        projectile.AddForce(transform.forward * projectileSpeed);
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, transform.forward * detectionDistance, Color.red, Mathf.Infinity, true);

        if (Physics.Raycast(transform.position, transform.forward, detectionDistance, ~barrelLayerMask))
        {
            //Debug.Log("Collision Detected" + Physics.Raycast(transform.position, transform.forward, detectionDistance, barrelLayerMask));
            Instantiate(explosive, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        timeElapsed += Time.deltaTime;

        if (timeElapsed > expirationTimer)
        {
            Destroy(gameObject);
        }
    }
}
