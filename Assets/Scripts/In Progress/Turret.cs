using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Diagnostics;
using System.Linq;

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
    private Quaternion returnRotation; /*Quaternion.Euler(0, 0, 0)*/
    private Vector3 targetDirection;

    private float turnDelay;
    private bool turnDelayed;   //This bool prevents the turn delay from firing every time.

    public float fireDelay;
    private bool fireBoolLock;

    public GameObject shot;
    public GameObject firingPosition;
    public GameObject muzzleFlash;

    public Transform[] barrelList;
    private int numDetectedObjects;
    public int numBarrels;
    private TurretController controller;

    private float fireDelayMin = 2.5f;
    private float fireDelayMax = 3.3f;

    private GameObject barrelObject;

    private void Awake()
    {
        controller = GetComponentInParent<TurretController>();
        returnRotation = transform.rotation;
        //firingPosition = transform.GetChild(0).transform.GetChild(0).GetComponentInChildren<GameObject>();
        //Debug.Log("Gameobject get: "+transform.GetChild(0).transform.GetChild(0).GetComponentInChildren<GameObject>());
        numDetectedObjects = gameObject.transform.GetChild(0).childCount;
        //UnityEngine.Debug.Log("Detected obj: " + numDetectedObjects + " On: " + gameObject);
        if (numDetectedObjects > 1)
        {
            Transform[] tempList = transform.GetChild(0).GetComponentsInChildren<Transform>();
            barrelList = Array.FindAll(tempList, i => i != transform.gameObject.CompareTag("FiringPosition")).ToArray();  //This doesn't work??
            numBarrels = barrelList.Length;
            /*foreach (Transform b in tempList)
            {
                if (!b.gameObject.CompareTag("FiringPosition")) //If object doesn't have tag
                {
                    
                }
            }*/
        }
        if (barrelList.Length > 1)
        {
            numBarrels = barrelList.Length;
        }
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

    IEnumerator TurnDelay() //This is a visual thing for fun. It delays turret turning to emulate crews acquiring targets.
    {
        //Debug.Log("Turn Delay Called");
        turnDelay = Random.Range(1.5f, 3.5f);
        yield return new WaitForSeconds(turnDelay);
        turnDelayed = true;
        //Debug.Log("Delay Complete");
    }

    void TargetAcquired()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        //Debug.Log("Current Dot: " + Quaternion.Dot(transform.rotation, targetRotation));
        //if rotation is within a certain amount near the target rotation, fire
        if (Quaternion.Dot(transform.rotation, targetRotation) >= .99f 
            && Quaternion.Dot(transform.rotation, targetRotation) >= -.99f && !fireBoolLock)
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
        if (controller.firingMode == TurretController.FiringMode.Freefire)
        {
            fireBoolLock = true;
            fireDelay = Random.Range(fireDelayMin / numBarrels, fireDelayMax / numBarrels);
            yield return new WaitForSeconds(fireDelay);
            Fire();
        }
        if (controller.firingMode == TurretController.FiringMode.Linked)
        {
            fireBoolLock = true;
            fireDelay = Random.Range(fireDelayMin, fireDelayMax);
            yield return new WaitForSeconds(fireDelay);
            FireAll();
        }


    }

    void Fire()
    {
        for (int i = 2; i < barrelList.Length; i++) //2 fires one barrel, but doesn't fire both seperately as intended
        {
            Instantiate(shot, barrelList[i].transform.position, barrelList[i].transform.rotation);
            Instantiate(muzzleFlash, barrelList[i].transform.position, barrelList[i].transform.rotation);
        }

        //Instantiate(shot, firingPosition.transform.position, transform.rotation /*Quaternion.LookRotation(gameObject.transform.position)*/ /*firingPosition.transform.parent.parent.rotation*/);  //Rotation caused the issue, swapped firing position from transform to gameobject
        //Instantiate(muzzleFlash, firingPosition.transform.position, transform.rotation);
        //Add recoil function
        fireBoolLock = false;
    }
    void FireAll()
    {
        for (int i = 1; i < barrelList.Length; i++)
        {
            Instantiate(shot, barrelList[i].transform.position, barrelList[i].transform.rotation);
            Instantiate(muzzleFlash, barrelList[i].transform.position, barrelList[i].transform.rotation);
        }
        fireBoolLock = false;

    }
}
