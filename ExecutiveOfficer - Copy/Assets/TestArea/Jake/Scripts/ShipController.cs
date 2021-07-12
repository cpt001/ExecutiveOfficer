using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipController : MonoBehaviour {
    protected Vector3 localVelocity;
    protected Vector3 localAngularVelocity;

    [Header("Flight Control Variables")]
    [SerializeField]
    protected float thrustSpeed = 0.0f;
    [SerializeField]
    protected float pitchSpeed = 0.0f;
    [SerializeField]
    protected float yawSpeed = 0.0f;
    //used by player/ai controller to influence flight
    [SerializeField]
    protected float rollSpeed = 0.0f;
    protected float inputThrustAxis = 0.0f;
    protected float inputPitchAxis = 0.0f;
    protected float inputYawAxis = 0.0f;
    protected float inputRollAxis = 0.0f;

    [Header("Direct Ref Variables")]
    [SerializeField]
    protected Rigidbody shipBody = null;

    [Header("Weapon System Variables")]
    [SerializeField]
    protected List<TurretGroup> turretGroups = new List<TurretGroup>();

    public virtual void Awake() {
        shipBody.centerOfMass = Vector3.zero;
    }

    public virtual void Update() {
        UpdateLocalVelocities();
        //DebugShipProperties();
    }

    public virtual void FixedUpdate() {
        HandleShipThrust();
        HandleShipPitch();
        HandleShipYaw();
        HandleShipRoll();
    }

    private void UpdateLocalVelocities() {
        localVelocity = transform.InverseTransformDirection(shipBody.velocity);
        localAngularVelocity = transform.InverseTransformDirection(shipBody.angularVelocity);
    }

    #region FlightMethods
    protected void HandleShipThrust() {
        Debug.DrawRay(shipBody.transform.position, shipBody.transform.forward * 10, Color.cyan);
        shipBody.AddForce((shipBody.transform.forward * (inputThrustAxis * thrustSpeed)) / shipBody.mass, ForceMode.Acceleration);
    }

    protected void HandleShipYaw() {
        shipBody.AddTorque((shipBody.transform.up * (inputYawAxis * yawSpeed) / shipBody.inertiaTensor.y), ForceMode.Acceleration);
    }

    protected void HandleShipPitch() {
        shipBody.AddTorque((shipBody.transform.right * (inputPitchAxis * pitchSpeed) / shipBody.inertiaTensor.x), ForceMode.Acceleration);
    }

    protected void HandleShipRoll() {
        shipBody.AddTorque((shipBody.transform.forward * (inputRollAxis * rollSpeed) / shipBody.inertiaTensor.z), ForceMode.Acceleration);
    }

    protected void DebugShipProperties() {
        print("Local linear velocity: " + localVelocity.ToString("F4"));
        //print("Globabl linear velocity: " + shipBody.velocity.ToString("F4"));
        print("Local angular velocity: " + localAngularVelocity.ToString("F4"));
        //print("Global angular velocity: " + shipBody.angularVelocity.ToString("F4"));
    }
    #endregion

    #region TargetingMethods
    public virtual void LockOnTarget(TurretGroup group, ShipModule target) {
        //print("Locked on to an enemy module!");
        group.LockedOnModule = target;
    }

    public virtual void UnlockTarget(TurretGroup group) {
        //print("Unlocked from an enemy module!");
        group.LockedOnModule = null;
    }
    #endregion
}