using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipMovementNode : MonoBehaviour {
    [SerializeField]
    private List<ShipMovementForce> movementForces;
    [SerializeField]
    private bool isSteeringNode = false;

    public List<ShipMovementForce> MovementForces {
        get {
            return movementForces;
        }

        set {
            movementForces = value;
        }
    }

    public bool IsSteeringNode {
        get {
            return isSteeringNode;
        }

        set {
            isSteeringNode = value;
        }
    }
}