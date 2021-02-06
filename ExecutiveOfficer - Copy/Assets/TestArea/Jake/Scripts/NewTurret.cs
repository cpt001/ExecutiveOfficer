using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTurret : MonoBehaviour {
    [SerializeField]
    private Transform barrelBase = null;
    [SerializeField]
    private Transform barrelEnd = null;
    [SerializeField]
    private GameObject projectilePrefab = null;
    [SerializeField]
    private float fireRate = 0.0f;
    private bool isLoaded = false;
    private bool isAimed = false;
    [SerializeField]
    private float swivelSpeed = 0.0f;
    //[SerializeField]
    //private float swivelYMin = 0.0f;
    //[SerializeField]
    //private float swivelYMax = 0.0f;
    [SerializeField]
    private float swivelXDownwardsDegrees = 0.0f;
    private float xAngle = 0.0f;
    //private float yAngle = 0.0f;


    private ShipModule turretTarget;

    public ShipModule TurretTarget {
        get {
            return turretTarget;
        }

        set {
            turretTarget = value;
        }
    }

    private void Awake() {
        turretTarget = GameObject.Find("DummyTarget").GetComponent<ShipModule>();
    }

    private void Update() {
        if (turretTarget != null) {
            RotateTurret();
        }
    }

    private void AimAtTarget() {
        //calculate point to aim at
        //aim at point
        //if point is desired final position, isAimed = true;
    }

    private void Fire() {
        if (isLoaded) {
            if (isAimed) {
                LaunchProjectile();
                isLoaded = false;
                StartCoroutine(ReloadTurret());
            }
        }
    }

    private void RotateTurret() {
        //print("Starting Rotation: " + barrelBase.localEulerAngles);
        Vector3 relativePos = turretTarget.transform.position - barrelBase.position;
        Vector3 tgtRot = Quaternion.LookRotation(relativePos, Vector3.up).eulerAngles;
        //print("Original Target Rotation: " + tgtRot);

        if (tgtRot.x < 170) {
            xAngle = Mathf.Clamp(tgtRot.x, 0.0f, swivelXDownwardsDegrees);
            tgtRot = new Vector3(xAngle, tgtRot.y, 0.0f);
            //print("New Clamped Rotation: " + tgtRot);
        }

        //barrelBase.rotation = Quaternion.Euler(tgtRot);
        barrelBase.transform.rotation = Quaternion.RotateTowards(barrelBase.rotation, Quaternion.Euler(tgtRot), swivelSpeed * Time.deltaTime);
        Debug.DrawRay(barrelBase.position, barrelEnd.forward * 100.0f, Color.cyan);
    }

    private IEnumerator ReloadTurret() {
        yield return new WaitForSeconds(fireRate);
        isLoaded = true;
        yield break;
    }

    private void LaunchProjectile() {
        Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation);
    }
}