using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipController : ShipController {
    [Header("AI Movement Variables")]
    [SerializeField]
    private Transform movementNodeContainer;
    private List<AIShipMovementNode> movementNodes = new List<AIShipMovementNode>();
    private List<AIShipMovementNode> orderedMovementNodes = new List<AIShipMovementNode>();
    [SerializeField]
    private float maxRaycastDist = 0.0f;
    [SerializeField]
    private Transform destinationPoint;
    [SerializeField]
    private float destinationArrivalThreshold;
    [SerializeField]
    private bool hasArrived;
    private float maxPitchVelocity = 0.0f;
    private float maxRollVelocity = 0.0f;
    private float maxThrustVelocity = 0.0f;
    private float maxYawVelocity = 0.0f;
    [SerializeField]
    private AIShipMovementNode debugNode;

    public override void Awake() {
        movementNodes.AddRange(movementNodeContainer.GetComponentsInChildren<AIShipMovementNode>());
        CalculateMaximumVelocities();
        base.Awake();
    }

    public override void Update() {
        base.Update();
    }

    public override void FixedUpdate() {
        //print("Optimal movement node: " + GetOptimalMovementNode().name + "!");
        print("Ship Angular Velocity: " + shipBody.angularVelocity);
        HandleAIShipMovement();
        base.FixedUpdate();
    }

    private void CalculateMaximumVelocities() {
        maxPitchVelocity = ((pitchSpeed / shipBody.angularDrag) - Time.fixedDeltaTime * pitchSpeed) / shipBody.mass;
        maxRollVelocity = ((rollSpeed / shipBody.drag) - Time.fixedDeltaTime * rollSpeed) / shipBody.mass;
        maxThrustVelocity = ((thrustSpeed / shipBody.angularDrag) - Time.fixedDeltaTime * thrustSpeed) / shipBody.mass;
        maxYawVelocity = ((yawSpeed / shipBody.angularDrag) - Time.fixedDeltaTime * yawSpeed) / shipBody.mass;
        print("Max Pitch: " + maxPitchVelocity);
        //print("Max Roll: " + maxRollVelocity);
        //print("Max Thrust: " + maxThrustVelocity);
        //print("Max Yaw: " + maxYawVelocity);
    }

    private void HandleAIShipMovement() {
        if (!hasArrived) {
            if (Vector3.Distance(transform.position, destinationPoint.position) > destinationArrivalThreshold) {
                //ApplyShipMovementForces(debugNode.MovementForces);
                ApplyShipMovementForces(GetOptimalMovementNode().MovementForces);
                return;
            }
            hasArrived = true;
        }
    }

    ////TEST-READY
    ////distance
    //private List<AIShipMovementNode> GetOrderedMovementNodes() {
    //    List<AIShipMovementNode> orderedNodes = movementNodes;
    //    //order movement nodes
    //    orderedNodes = orderedNodes.OrderBy(
    //        node => Vector3.Distance(node.transform.position, destinationPoint.position)
    //        ).ToList();
    //    for (int i = 0; i < orderedNodes.Count; i++) {
    //        print("Node " + i + ": " + orderedNodes[i].name + ", Dist: " + Vector3.Distance(orderedNodes[i].transform.position, destinationPoint.position) + "!");
    //    }
    //    return orderedNodes;
    //}

    //TEST-READY
    //sqr magnitude
    private List<AIShipMovementNode> GetOrderedMovementNodes() {
        List<AIShipMovementNode> orderedNodes = movementNodes;
        //order movement nodes
        orderedNodes = orderedNodes.OrderBy(
            node => (node.transform.position - destinationPoint.position).sqrMagnitude
            ).ToList();
        //for (int i = 0; i < orderedNodes.Count; i++) {
        //    print("Node " + i + ": " + orderedNodes[i].name + ", sqMag: " + (orderedNodes[i].transform.position - destinationPoint.position).sqrMagnitude + "!");
        //}
        return orderedNodes;
    }

    ////TEST-READY; May need tweaking depending on how destination targeting works (moving to ship position, but raycast hitting ship)
    ////raycast
    //private bool IsMovementNodeClear(AIShipMovementNode node) {
    //    //do raycast checking
    //    RaycastHit hitInfo;
    //    if (Physics.Raycast(node.transform.position, node.transform.forward, out hitInfo, maxRaycastDist)) {
    //        //check if object hit was not the target object
    //        //print(node.name + " hit " + hitInfo.collider.name + " at " + hitInfo.distance + "!");
    //        return false;
    //    }
    //    else {
    //        return true;
    //    }
    //}

    //TEST-READY; May need tweaking depending on how destination targeting works (moving to ship position, but raycast hitting ship)
    //boxcast
    private bool IsMovementNodeClear(AIShipMovementNode node) {
        //do boxcast checking
        RaycastHit hitInfo;
        Vector3 halfExtents = new Vector3(node.transform.lossyScale.x / 2.0f, node.transform.lossyScale.y / 2.0f, node.transform.lossyScale.z / 2.0f);
        if (Physics.BoxCast(node.transform.position, halfExtents, node.transform.forward, out hitInfo, node.transform.rotation, maxRaycastDist)) {
            //check if object hit was not the target object
            //print(node.name + " hit " + hitInfo.collider.name + " at " + hitInfo.distance + "!");
            return false;
        }
        Vector3 boxCastExtents = new Vector3(halfExtents.x, halfExtents.y, halfExtents.z + maxRaycastDist);
        Vector3 boxCastCenter = node.transform.position + node.transform.forward * maxRaycastDist;
        GameFunctionHelper.DebugDrawCubePoints(GameFunctionHelper.DebugCubePoints(boxCastCenter, boxCastExtents, node.transform.rotation));
        return true;
    }

    private AIShipMovementNode GetClosestOuterNode() {
        for (int i = 0; i < orderedMovementNodes.Count; i++) {
            if (orderedMovementNodes[i].IsSteeringNode) {
                return orderedMovementNodes[i];
            }
        }
        return null;
    }

    private AIShipMovementNode GetOptimalMovementNode() {
        orderedMovementNodes = GetOrderedMovementNodes();
        for (int i = 0; i < orderedMovementNodes.Count; i++) {
            if (IsMovementNodeClear(orderedMovementNodes[i])) {
                return orderedMovementNodes[i];
            }
        }
        return GetClosestOuterNode();
    }

    private void ApplyShipMovementForces(List<ShipMovementForce> forces) {
        for (int i = 0; i < forces.Count; i++) {
            ApplyShipMovementForce(forces[i]);
        }
    }

    private void ApplyShipMovementForce(ShipMovementForce force) {
        //modify force
        //apply force via ship controller
        switch (force.MovementMode) {
            case ShipMovementMode.PITCH:
            inputPitchAxis = force.MovementForce;
            break;
            case ShipMovementMode.ROLL:
            inputRollAxis = force.MovementForce;
            break;
            case ShipMovementMode.THRUST:
            inputThrustAxis = force.MovementForce;
            break;
            case ShipMovementMode.YAW:
            inputYawAxis = force.MovementForce;
            break;
        }
    }

    private float ModifyShipMovementForce(ShipMovementForce force) {
        float forceValue = 0.0f;
        //modify force
        switch (force.MovementMode) {
            case ShipMovementMode.PITCH:
            //determine angle diff
            //scale value based on diff
            break;
            case ShipMovementMode.ROLL:
                //handle later
                //waiting until AI implementation of rolling
            break;
            case ShipMovementMode.THRUST:
            //determine distance
            float sqrMagnitude = (destinationPoint.position - transform.position).sqrMagnitude;
            //scale value based on distance

            break;
            case ShipMovementMode.YAW:
            //determine angle diff
            //scale value based on diff
            break;
        }
        return forceValue;
    }
}