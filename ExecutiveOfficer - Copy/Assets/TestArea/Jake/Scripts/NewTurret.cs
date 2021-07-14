 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NewTurret : MonoBehaviour {
    [SerializeField]
    [Tooltip("Unimplemented variable to allow for multiple barrels on a turret later down the line")]
    private bool turretHasMultipleBarrels = false;
    [SerializeField]
    private bool isHeavyTurret;
    public CinemachineImpulseDefinition impulseDefinition = null;
    [SerializeField]
    private Transform barrelBase = null;
    [SerializeField]
    private Transform barrelEnd = null;
    [SerializeField]
    private GameObject projectilePrefab = null;
    [SerializeField]
    private float fireRateMin = 0.0f;
    [SerializeField]
    private float fireRateMax = 0.0f;
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

    private Rigidbody shipRigidbody;
    private float projectileSpeed;
    private Vector3 projectileSize;

    private ShipModule turretTarget;

    public ShipModule TurretTarget {
        get {
            return turretTarget;
        }

        set {
            turretTarget = value;
        }
    }

    public Rigidbody ShipRigidbody {
        get {
            return shipRigidbody;
        }

        set {
            shipRigidbody = value;
        }
    }

    private void OnEnable() {
        AddEventListeners();
    }

    private void OnDisable() {
        RemoveEventListeners();
    }

    private void Awake() {
        Init();
    }

    private void Init() {
        isLoaded = true;
        shipRigidbody = GameFunctionHelper.GetRootRigidBody(transform);
        projectileSpeed = projectilePrefab.GetComponent<Projectile>().MovementSpeed;
        projectileSize = projectilePrefab.GetComponent<BoxCollider>().size / 2.0f;
        //impulseDefinition = GetComponent<CinemachineImpulseSource>();   //Impulse source is component on object
    }

    private void Update() {
        if (turretTarget != null) {
            RotateTurret();
            Fire();
        }
    }

    private void AddEventListeners() {
        Events.instance.AddListener<ModuleDestroyedEvent>(OnTargetModuleDestroyed);
    }

    private void RemoveEventListeners() {
        Events.instance.RemoveListener<ModuleDestroyedEvent>(OnTargetModuleDestroyed);
    }

    private bool IsOwnShipInSight() {
        Ray aimRay = new Ray(barrelEnd.position, barrelEnd.forward);
        RaycastHit hit = new RaycastHit();
        //GameFunctionHelper.DebugDrawCubePoints(GameFunctionHelper.DebugCubePoints(barrelEnd.position + barrelEnd.forward * projectileSize.z, projectileSize, barrelBase.rotation));
        if (Physics.BoxCast(barrelEnd.position + barrelEnd.forward * projectileSize.z, projectileSize, barrelEnd.forward, out hit, barrelBase.rotation, Mathf.Infinity)) {
            Transform hitRoot = hit.transform.root;
            if (transform.root == hitRoot) {
                //own ship in sight
                //print("Raycast hit own ship!");
                return true;
            }
            return false;
        }
        return false;
    }

    private void Fire() {
        if (isLoaded) {
            if (isAimed) {
                if (isHeavyTurret)
                {
                    impulseDefinition.CreateEvent(transform.position, Vector3.forward); //Accordingly, the impulse fires at pos, then fires in 'direction?'
                }
                LaunchProjectile();
                isLoaded = false;
                StartCoroutine(ReloadTurret());
            }
        }
    }

    private void RotateTurret() {
        //print("Starting Rotation: " + barrelBase.localRotation.eulerAngles + "!");
        //print("Barrel base position: " + barrelBase.position + ", " + "Shooting ship velocity: " + shipRigidbody.velocity + ", " + "Projectile speed: " + projectileSpeed + ", " + "Target position: " + turretTarget.transform.position + ", " + "Target ship velocity: " + GameFunctionHelper.GetRootRigidBody(turretTarget.transform).velocity + "!");
        Vector3 relativePos = PredictiveAim.FirstOrderIntercept(barrelBase.position, shipRigidbody.velocity, projectileSpeed, turretTarget.transform.position, GameFunctionHelper.GetRootRigidBody(turretTarget.transform).velocity) - barrelBase.position;
        //print("Relative position: " + relativePos + "!");
        Quaternion tgtRot = Quaternion.LookRotation(relativePos, barrelBase.transform.up);
        //print("Target rotation: " + tgtRot + "!");
        //barrelBase.transform.rotation = tgtRot;
        barrelBase.transform.rotation = Quaternion.RotateTowards(barrelBase.rotation, tgtRot, swivelSpeed * Time.deltaTime);
        HardClampTurretRotation();
        //print("Target Rotation = " + tgtRot + "!");
        //print("Current Rotation = " + barrelBase.transform.rotation.eulerAngles);
        if (barrelBase.transform.rotation == tgtRot && !IsOwnShipInSight()) {
            isAimed = true;
        }
        else {
            isAimed = false;
        }
        Debug.DrawRay(barrelBase.position, barrelEnd.forward * 100.0f, Color.cyan);
    }

    private void HardClampTurretRotation() {
        Vector3 clampedRotation = barrelBase.transform.localRotation.eulerAngles;
        //clamp x
        if (barrelBase.transform.localRotation.eulerAngles.x > swivelXDownwardsDegrees && barrelBase.transform.localRotation.eulerAngles.x < 90.0f) {
            clampedRotation = new Vector3(swivelXDownwardsDegrees, clampedRotation.y, clampedRotation.z);
        }
        else if (barrelBase.transform.localRotation.eulerAngles.x >= 90.0f && barrelBase.transform.localRotation.eulerAngles.x < 180.0f - swivelXDownwardsDegrees) {
            clampedRotation = new Vector3(180.0f - swivelXDownwardsDegrees, clampedRotation.y, clampedRotation.z);
        }
        //clamp z
        clampedRotation = new Vector3(clampedRotation.x, clampedRotation.y, 0.0f);
        barrelBase.transform.localRotation = Quaternion.Euler(clampedRotation);
    }

    private IEnumerator ReloadTurret() {
        yield return new WaitForSeconds(Random.Range(fireRateMin, fireRateMax));
        isLoaded = true;
        yield break;
    }

    private void LaunchProjectile() {
        //spawn at end
        //GameObject projObj = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation);
        //spawn at base
        GameObject projObj = Instantiate(projectilePrefab, barrelBase.position, barrelBase.rotation);
        projObj.GetComponent<Projectile>().InitializeProjectileVelocity(shipRigidbody.velocity);
    }

    #region EventListeners
    private void OnTargetModuleDestroyed(ModuleDestroyedEvent moduleEvent) {
        if (moduleEvent.destroyedModule == turretTarget) {
            turretTarget = null;
            isAimed = false;
        }
    }
    #endregion
}