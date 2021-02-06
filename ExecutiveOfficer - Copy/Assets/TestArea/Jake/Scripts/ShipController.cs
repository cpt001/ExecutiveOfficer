using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour {
    PlayerInputActions inputActions;

    [SerializeField]
    private float thrustSpeed = 0.0f;
    [SerializeField]
    private float pitchSpeed = 0.0f;
    [SerializeField]
    private float yawSpeed = 0.0f;
    [SerializeField]
    private float rollSpeed = 0.0f;

    private float inputThrustAxis = 0.0f;
    private float inputPitchAxis = 0.0f;
    private float inputYawAxis = 0.0f;
    private float inputRollAxis = 0.0f;

    [SerializeField]
    private Rigidbody shipBody = null;

    private Camera gameCamera;

    private int shipModuleLayer;

    [SerializeField]
    private bool isTargeting = false;

    [SerializeField]
    private List<TurretGroup> turretGroups = new List<TurretGroup>();
    private int selectedTurretGroupIndex = 0;

    private void Awake() {
        Init();
    }

    private void Update() {
        DebugShipProperties();
    }

    private void FixedUpdate() {
        HandleShipThrust();
        HandleShipPitch();
        HandleShipYaw();
        HandleShipRoll();
        HandleTargeting();
    }

    private void Init() {
        gameCamera = Camera.main;
        shipModuleLayer = LayerMask.GetMask("ShipModules");
        BindInputActions();
    }

    private void BindInputActions() {
        inputActions = new PlayerInputActions();
        inputActions.ShipControl.Thrust.performed += ctx => inputThrustAxis = ctx.ReadValue<float>();
        inputActions.ShipControl.Pitch.performed += ctx => inputPitchAxis = ctx.ReadValue<float>();
        inputActions.ShipControl.Roll.performed += ctx => inputRollAxis = ctx.ReadValue<float>();
        inputActions.ShipControl.Yaw.performed += ctx => inputYawAxis = ctx.ReadValue<float>();
    }

    private void HandleShipThrust() {
        Debug.DrawRay(shipBody.transform.position, shipBody.transform.forward * 10, Color.cyan);
        shipBody.AddForce(shipBody.transform.forward * (inputThrustAxis * thrustSpeed), ForceMode.Force);

    }

    private void HandleShipYaw() {
        shipBody.AddTorque(shipBody.transform.up * (inputYawAxis * yawSpeed), ForceMode.Force);
    }

    private void HandleShipPitch() {
        shipBody.AddTorque(shipBody.transform.right * (inputPitchAxis * pitchSpeed), ForceMode.Force);
    }

    private void HandleShipRoll() {
        shipBody.AddTorque(shipBody.transform.forward * (inputRollAxis * rollSpeed), ForceMode.Force);
    }

    private void HandleTargeting() {
        if (isTargeting) {
            Ray aimRay = new Ray(gameCamera.transform.position, gameCamera.transform.forward);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(aimRay, out hit, Mathf.Infinity, shipModuleLayer)) {
                ShipModule module = hit.collider.GetComponent<ShipModule>();
                if (module != null && !module.transform.IsChildOf(transform)) {
                    //this is an enemy module
                    print("Raycast hit an enemy module!");
                    //highlight module if not highlighted or locked on
                    if (turretGroups[selectedTurretGroupIndex].HighlightedModule != module && turretGroups[selectedTurretGroupIndex].LockedOnModule != module) {
                        turretGroups[selectedTurretGroupIndex].HighlightedModule = module;
                        print("Highlighted an enemy module!");
                    }
                }
            }
        }
    }

    private void ToggleTargetingMode() {
        if (isTargeting) {
            isTargeting = false;
            //remove crosshair
            //switch to flight camera
        }
        else {
            //create crosshair
            //switch to turret camera based on index
        }
    }

    private void SwitchTurretGroup() {
        selectedTurretGroupIndex++;
        if (selectedTurretGroupIndex >= turretGroups.Count) {
            selectedTurretGroupIndex = 0;
        }
        //handle camera switching
    }

    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }

    private void DebugShipProperties() {
        //print(shipBody.velocity);
    }
}