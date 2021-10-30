using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipMovementForce {
    [SerializeField]
    private ShipMovementMode movementMode;
    [SerializeField]
    private float movementForce;

    public ShipMovementMode MovementMode {
        get {
            return movementMode;
        }

        set {
            movementMode = value;
        }
    }

    public float MovementForce {
        get {
            return movementForce;
        }

        set {
            movementForce = value;
        }
    }
}