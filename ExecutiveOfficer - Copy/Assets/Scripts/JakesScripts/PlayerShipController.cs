using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerShipController : ShipController {
    [SerializeField]
    private PlayerInputActions inputActions;

    //[SerializeField]
    //private ShipController ship;

    private Camera gameCamera;
    [SerializeField]
    private CinemachineVirtualCameraBase flightCamera;
    [SerializeField]
    private List<CinemachineVirtualCameraBase> targetingCameras = new List<CinemachineVirtualCameraBase>();

    private int shipModuleLayer;

    [Header("Weapon System Variables")]
    [SerializeField]
    private bool isTargeting = false;
    private int selectedTurretGroupIndex = 0;

    public override void Awake() {
        Init();
    }

    public override void Update() {
        HandleTargeting();
        base.Update();
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
    }

    private void Init() {
        gameCamera = Camera.main;
        shipModuleLayer = LayerMask.GetMask("ShipModules");
        BindInputActions();
        Events.instance.Raise(new EnterFlightEvent());
    }

    private void OnEnable() {
        AddListeners();
        inputActions.Enable();
    }

    private void OnDisable() {
        RemoveListeners();
        inputActions.Disable();
    }

    private void AddListeners() {
        Events.instance.AddListener<ChangeGameCameraEvent>(HandleCameraChange);
    }

    private void RemoveListeners() {
        Events.instance.RemoveListener<ChangeGameCameraEvent>(HandleCameraChange);
    }

    private void BindInputActions() {
        inputActions = new PlayerInputActions();
        inputActions.ShipControl.Thrust.performed += ctx => inputThrustAxis = ctx.ReadValue<float>();
        inputActions.ShipControl.Pitch.performed += ctx => inputPitchAxis = ctx.ReadValue<float>();
        inputActions.ShipControl.Roll.performed += ctx => inputRollAxis = ctx.ReadValue<float>();
        inputActions.ShipControl.Yaw.performed += ctx => inputYawAxis = ctx.ReadValue<float>();
    }

    #region TargetingMethods
    private void HandleTargeting() {
        if (isTargeting) {
            ShipModule tmpModule = GetModuleInSight();
            HandleHighlighting(turretGroups[selectedTurretGroupIndex], tmpModule);
        }
    }

    //raycast function in aiming mode
    private ShipModule GetModuleInSight() {
        Ray aimRay = new Ray(gameCamera.transform.position, gameCamera.transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(aimRay, out hit, Mathf.Infinity, shipModuleLayer)) {
            ShipModule module = hit.collider.GetComponent<ShipModule>();
            if (module != null && !module.transform.IsChildOf(transform)) {
                //this is an enemy module
                //print("Raycast hit an enemy module!");
                return module;
            }
        }
        return null;
    }

    private void HandleHighlighting(TurretGroup group, ShipModule target) {
        if (target == null) {
            if (group.HighlightedModule != null) {
                UnhighlightTarget(group);
                return;
            }
        }
        else {
            if (target == group.LockedOnModule) {
                if (target == group.HighlightedModule) {
                    UnhighlightTarget(group);
                    return;
                }
            }
            if (target != group.HighlightedModule) {
                if (group.HighlightedModule != null) {
                    UnhighlightTarget(group);
                }
                if (target != group.LockedOnModule) {
                    HighlightTarget(group, target);
                }
            }
        }
    }

    private void HandleTargetLocking(TurretGroup group, ShipModule target) {
        ShipModule tmpModule = null;
        if (group.LockedOnModule != null) {
            tmpModule = group.LockedOnModule;
            UnlockTarget(group);
        }
        if (target != null && target != tmpModule) {
            LockOnTarget(group, target);
            return;
        }
    }

    private void HighlightTarget(TurretGroup group, ShipModule target) {
        //print("Highlighted an enemy module!");
        group.HighlightedModule = target;
        //highlight event here
        Events.instance.Raise(new ShipTargetingEvent(target, TargetingMode.HIGHLIGHT));
    }

    private void UnhighlightTarget(TurretGroup group) {
        //print("Unhighlighted an enemy module!");
        //unhighlight event here
        Events.instance.Raise(new ShipTargetingEvent(group.HighlightedModule, TargetingMode.UNHIGHLIGHT));
        group.HighlightedModule = null;
    }

    private void UnhighlightModules() {
        for (int i = 0; i < turretGroups.Count; i++) {
            if (turretGroups[i].HighlightedModule != null) {
                UnhighlightTarget(turretGroups[i]);
            }
        }
    }

    public override void LockOnTarget(TurretGroup group, ShipModule target) {
        //print("Locked on to an enemy module!");
        group.LockedOnModule = target;
        //lock on event here
        Events.instance.Raise(new ShipTargetingEvent(target, TargetingMode.LOCK));
    }

    public override void UnlockTarget(TurretGroup group) {
        //print("Unlocked from an enemy module!");
        //unlock target event here
        Events.instance.Raise(new ShipTargetingEvent(group.LockedOnModule, TargetingMode.UNLOCK));
        group.LockedOnModule = null;
    }
    #endregion

    private void HandleCameraChange(ChangeGameCameraEvent cameraEvent) {
        if (cameraEvent.isBlendFinished == true) {
            if (cameraEvent.gameCamera == flightCamera) {
                EnterFlightMode();
                return;
            }
            for (int i = 0; i < targetingCameras.Count; i++) {
                if (cameraEvent.gameCamera == targetingCameras[i]) {
                    if (!isTargeting) {
                        EnterTargetMode();
                    }
                    return;
                }
            }
        }
    }

    private void EnterFlightMode() {
        Events.instance.Raise(new EnterFlightEvent());
        isTargeting = false;
    }

    private void EnterTargetMode() {
        Events.instance.Raise(new EnterTargetingEvent());
        isTargeting = true;
    }

    private void ToggleTargetingMode() {
        if (isTargeting) {
            UnhighlightModules();
            Events.instance.Raise(new ChangeGameCameraEvent(flightCamera, false));
        }
        else {
            Events.instance.Raise(new ChangeGameCameraEvent(targetingCameras[selectedTurretGroupIndex], false));
        }
    }

    private void SwitchTurretGroup() {
        selectedTurretGroupIndex++;
        if (selectedTurretGroupIndex >= turretGroups.Count) {
            selectedTurretGroupIndex = 0;
        }
        if (isTargeting) {
            UnhighlightModules();
            Events.instance.Raise(new ChangeGameCameraEvent(targetingCameras[selectedTurretGroupIndex], false));
        }
    }

    #region PlayerInputMethods
    public void OnCycleTurretGroups() {
        SwitchTurretGroup();
    }

    public void OnToggleTargetingMode() {
        ToggleTargetingMode();
    }

    public void OnLockTarget() {
        //print("TagetLock input action called!");
        if (isTargeting) {
            HandleTargetLocking(turretGroups[selectedTurretGroupIndex], GetModuleInSight());
        }
    }
    #endregion

    public void DebugSetAllTurretsTarget(ShipModule tgt) {
        for (int i = 0; i < turretGroups.Count; i++) {
            LockOnTarget(turretGroups[i], tgt);
        }
    }
}