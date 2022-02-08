using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipController : MonoBehaviour {
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

    protected Vector3 localAngularVelocity;
    protected Vector3 localVelocity;

    [Header("Direct Ref Variables")]
    [SerializeField]
    protected Rigidbody shipBody = null;

    [Header("Weapon System Variables")]
    [SerializeField]
    protected List<TurretGroup> turretGroups = new List<TurretGroup>();

    public virtual void Awake() {

    }

    public virtual void Update() {
        DebugShipProperties();
    }

    public virtual void FixedUpdate() {
        localAngularVelocity = transform.InverseTransformDirection(shipBody.angularVelocity);
        localVelocity = transform.InverseTransformDirection(shipBody.velocity);

        HandleShipThrust();
        HandleShipPitch();
        HandleShipYaw();
        HandleShipRoll();
    }

    #region FlightMethods
    protected void HandleShipThrust() {
        Debug.DrawRay(shipBody.transform.position, shipBody.transform.forward * 10, Color.cyan);
        shipBody.AddForce(shipBody.transform.forward * (inputThrustAxis * thrustSpeed), ForceMode.Force);
    }

    protected void HandleShipYaw() {
        shipBody.AddTorque(shipBody.transform.up * (inputYawAxis * yawSpeed), ForceMode.Force);
    }

    protected void HandleShipPitch() {
        shipBody.AddTorque(shipBody.transform.right * (inputPitchAxis * pitchSpeed), ForceMode.Force);
    }

    protected void HandleShipRoll() {
        shipBody.AddTorque(shipBody.transform.forward * (inputRollAxis * rollSpeed), ForceMode.Force);
    }

    protected void DebugShipProperties() {
        //print(shipBody.velocity);
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