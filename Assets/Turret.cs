using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Random = UnityEngine.Random;

public class Turret : MonoBehaviour
{
    /// <summary>
    /// This is being setup wrong. The script has strayed into territory of being a controller.
    /// Test the rotation seperately, then start creating a controller.
    /// Turret script should handle rotation of barrel, body, then firing.
    /// See if it can be tied into predictive aim script?
    /// </summary>

    public float rotationSpeed;
    public GameObject target;

    private Quaternion targetRotation;
    private Quaternion returnRotation = Quaternion.identity /*Quaternion.Euler(0, 0, 0)*/;
    private Vector3 targetDirection;

    private float turnDelay;
    private bool turnDelayed;   //This bool prevents the turn delay from firing every time.

    public float fireDelay;
    private bool fireBoolLock;

    public GameObject shot;
    public GameObject firingPosition;
    //public ParticleSystem muzzleFlash;

    private void Awake()
    {
        //firingPosition = transform.GetChild(0).transform.GetChild(0).GetComponentInChildren<GameObject>();
        //Debug.Log("Gameobject get: "+transform.GetChild(0).transform.GetChild(0).GetComponentInChildren<GameObject>());
    }

    private void Update()
    {
        if (target) //If there's a target
        {
            //Debug.Log("Target Found");
            if (!turnDelayed)
            {
                StartCoroutine(TurnDelay());
            }
            else if (turnDelayed)
            {
                //Debug.Log("Turning to Target");
                targetDirection = (target.transform.position - transform.position).normalized;
                targetRotation = Quaternion.LookRotation(targetDirection);
                TargetAcquired();
            }
        }
        if (!target)
        {
            TargetLost();
            turnDelayed = false;
        }
    }

    IEnumerator TurnDelay() //This is a visual thing for fun. It delays turret turning to emulate crews.
    {
        //Debug.Log("Turn Delay Called");
        turnDelay = Random.Range(0.5f, 2.5f);
        yield return new WaitForSeconds(turnDelay);
        turnDelayed = true;
        //Debug.Log("Delay Complete");
    }

    void TargetAcquired()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        //Debug.Log("Current Dot: " + Quaternion.Dot(transform.rotation, targetRotation));
        //if rotation is within a certain amount near the target rotation, fire
        if (Quaternion.Dot(transform.rotation, targetRotation) >= .98f 
            && Quaternion.Dot(transform.rotation, targetRotation) >= -.98f && !fireBoolLock)
        {
            //Debug.Log("Firing Called, bool" + fireBoolLock);
            StartCoroutine(Firing());
        }
    }

    void TargetLost()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, returnRotation, Time.deltaTime * rotationSpeed);
    }

    IEnumerator Firing()
    {
        fireBoolLock = true;
        fireDelay = Random.Range(2.5f, 3.3f);
        yield return new WaitForSeconds(fireDelay);
        Fire();


    }

    void Fire()
    {
        //Debug.Log("ShotFired");
        //Instantiate(shot, firingPosition.forward, Quaternion.identity); //Instantiates at world 0? -- instantiates it correctly, at position, but in world values instead of on correct child?
        //muzzleFlash.Play();
        Instantiate(shot, firingPosition.transform.position, transform.rotation /*Quaternion.LookRotation(gameObject.transform.position)*/ /*firingPosition.transform.parent.parent.rotation*/);  //Rotation caused the issue, swapped firing position from transform to gameobject
        //Add recoil function
        fireBoolLock = false;
    }
}
