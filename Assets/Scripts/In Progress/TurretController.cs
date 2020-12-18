using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Purpose of script
/// Acquires target for turret group
/// 
/// Player is able to swing camera freely around the turret control point
/// Raycast line appears from camera point
/// Camera point is slightly above the turret grouping
/// Red = No Solution // Blue = Free fire in direction // Yellow = Fire with possible impact // Green = Fire with lock
/// </summary>
/// 
public class TurretController : MonoBehaviour
{
    public enum TurretControllerLocation
    {
        undefined,
        PortMain,
        StarboardMain,
    }
    public TurretControllerLocation turretLocation = TurretControllerLocation.undefined;
    public Turret[] turretGroup;
    public GameObject turretGroupTarget;
    private GameObject turretControllerObject;
    public Camera cam;
    private float rayDrawDistance = 2000.0f;
    [SerializeField]
    private bool targetingActive = false;   //This becomes active when the player selects the weapon group
    public CinemachineVirtualCameraBase starboardCamera;
    public CinemachineVirtualCameraBase portCamera;
    public CinemachineVirtualCameraBase overviewCam;
    private int cameraPriorityBoostAmount = 2;
    public LayerMask targetingMask;

    public enum FiringMode  //Freefire NYI
    {
        Linked,
        Freefire,
    }
    public FiringMode firingMode;


    private void Awake()
    {
        turretControllerObject = gameObject;
        cam = Camera.main;
        targetingMask = LayerMask.GetMask("TurretColliders");
    }

    public void m_ButtonActivation()
    {
        targetingActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        #region Turret Fix Indicator
        if (turretLocation == TurretControllerLocation.undefined)
        {
            Debug.LogError("Turret location undefined at: " + gameObject.name);
        }
        #endregion

        CameraPriority();

        if (Input.GetKeyDown(KeyCode.Escape) && targetingActive)
        {
            targetingActive = false;
            CursorUnlock();
        }

        if (targetingActive)
        {
            CursorLock();

            RaycastHit objectHit;
            if (Physics.Raycast(turretControllerObject.transform.position, -cam.transform.position, out objectHit))
            {
                #region AnyFriendlyObject
                Debug.Log("Object Hit " + objectHit.transform.gameObject.name);
                if (objectHit.transform.gameObject.CompareTag("SelfCapitalShipPart") || objectHit.transform.gameObject.CompareTag("FriendlyObject"))
                {
                    Debug.DrawRay(turretControllerObject.transform.position, -cam.transform.position * rayDrawDistance, Color.red, 0.1f, true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        targetingActive = false;
                        CursorUnlock();
                    }
                }
                #endregion
                #region AnyShootableTag
                else if (objectHit.transform.gameObject.CompareTag("EnemyObject") || objectHit.transform.gameObject.CompareTag("Shootable"))
                {
                    Debug.DrawRay(turretControllerObject.transform.position, -cam.transform.position * rayDrawDistance, Color.green, 0.1f, true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        turretGroupTarget = objectHit.transform.gameObject;
                        foreach (Turret t in turretGroup)
                        {
                            t.target = objectHit.transform.gameObject;
                        }
                        targetingActive = false;
                        CursorUnlock();
                    }
                }
                #endregion
                #region TargetLeadMarkerHit
                else if (objectHit.transform.gameObject.CompareTag("TargetLead"))
                {
                    Debug.DrawRay(turretControllerObject.transform.position, -cam.transform.position * rayDrawDistance, Color.yellow, 0.1f, true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        turretGroupTarget = objectHit.transform.gameObject;
                        foreach (Turret t in turretGroup)
                        {
                            t.target = objectHit.transform.gameObject;
                        }
                        targetingActive = false;
                        CursorUnlock();
                    }
                }
                #endregion
                #region Detargeting
                else
                {
                    Debug.DrawRay(turretControllerObject.transform.position, -cam.transform.position * rayDrawDistance, Color.blue, 0.1f, true);
                    foreach (Turret t in turretGroup)
                    {
                        t.target = null;
                    }
                }
                #endregion
            }
        }
    }



    void CameraPriority()
    {
       
        if (targetingActive && turretLocation == TurretControllerLocation.StarboardMain)
        {
            Debug.Log("Conditions met, starboard active");
            if (starboardCamera.Priority < 11)
            {
                starboardCamera.Priority += cameraPriorityBoostAmount;
            }
        }
        else if (targetingActive && turretLocation == TurretControllerLocation.PortMain)
        {
            if (portCamera.Priority < 11)
            {
                portCamera.Priority += cameraPriorityBoostAmount;
            }
        }

        else
        {
            if (starboardCamera.Priority > 9)
            {
                starboardCamera.Priority -= cameraPriorityBoostAmount;
            }
            if (portCamera.Priority > 9)
            {
                portCamera.Priority -=cameraPriorityBoostAmount;
            }
        }
    }

    void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
