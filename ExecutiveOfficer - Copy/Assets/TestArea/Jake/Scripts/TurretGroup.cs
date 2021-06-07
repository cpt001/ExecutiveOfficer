using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[System.Serializable]
public class TurretGroup {
    private CinemachineVirtualCamera groupCamera;
    [SerializeField]
    private List<NewTurret> turretArray = new List<NewTurret>();
    private ShipModule highlightedModule;
    private ShipModule lockedOnModule;

    public CinemachineVirtualCamera GroupCamera {
        get {
            return groupCamera;
        }

        set {
            groupCamera = value;
        }
    }

    public List<NewTurret> TurretArray {
        get {
            return turretArray;
        }

        set {
            turretArray = value;
        }
    }

    public ShipModule HighlightedModule {
        get {
            return highlightedModule;
        }

        set {
            highlightedModule = value;
        }
    }

    public ShipModule LockedOnModule {
        get {
            return lockedOnModule;
        }

        set {
            lockedOnModule = value;
            AssignTurretTargets();
        }
    }

    private void AssignTurretTargets() {
        for (int i = 0; i < turretArray.Count; i++) {
            turretArray[i].TurretTarget = lockedOnModule;
        }
    }
}