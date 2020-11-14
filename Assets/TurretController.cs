using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour
{
    public Turret[] turretGroup;
    private GameObject turretControllerObject;
    public Camera cam;
    private float rayDrawDistance = 2000.0f;
    private bool targetingActive = false;   //This becomes active when the player selects the weapon group
    private Camera starboardCamera;
    private Camera portCamera;
    private Camera overviewCam;

    /// <summary>
    /// Purpose of script
    /// Acquires target for turret group
    /// 
    /// Player is able to swing camera freely around the ship
    /// Raycast line appears from camera point
    /// Camera point is slightly above the turret grouping
    /// Red = No Solution // Blue = Free fire in direction // Yellow = Fire with possible impact // Green = Fire with lock
    /// </summary>
    /// 
    private void Awake()
    {
        turretControllerObject = gameObject;
        cam = Camera.main;
    }

    public void m_ButtonActivation()
    {
        targetingActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit objectHit;
        if (targetingActive && Physics.Raycast(turretControllerObject.transform.position, -cam.transform.position, out objectHit))
        {
            if (gameObject.tag == "SelfCapitalShipPart" || gameObject.tag == "FriendlyObject")
            {
                Debug.DrawRay(turretControllerObject.transform.position, -cam.transform.position * rayDrawDistance, Color.red, Mathf.Infinity, true);
            }
            else if (gameObject.tag == "EnemyObject")
            {
                Debug.DrawRay(turretControllerObject.transform.position, -cam.transform.position * rayDrawDistance, Color.green, Mathf.Infinity, true);
                if (Input.GetMouseButtonDown(0))
                {
                    foreach (Turret t in turretGroup)
                    {
                        t.target = objectHit.transform.gameObject;
                    }
                }
            }
            else if (gameObject.tag == "TargetLead")
            {
                Debug.DrawRay(turretControllerObject.transform.position, -cam.transform.position * rayDrawDistance, Color.yellow, Mathf.Infinity, true);
                if (Input.GetMouseButtonDown(0))
                {
                    foreach (Turret t in turretGroup)
                    {
                        t.target = objectHit.transform.gameObject;
                    }
                }
            }
            else
            {
                Debug.DrawRay(turretControllerObject.transform.position, -cam.transform.position * rayDrawDistance, Color.blue, Mathf.Infinity, true);
                foreach (Turret t in turretGroup)
                {
                    t.target = null;
                }    
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            targetingActive = false;
        }
    }
}
