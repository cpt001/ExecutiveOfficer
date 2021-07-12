using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipControllerFinal : ShipController {
    [Header("AI Pathing Variables")]
    [SerializeField]
    private int numOfPathingSteps = 0;
    private float pathingStepDist = 0.0f;
    private float pathingStepGap = 0.0f;
    [SerializeField]
    private float maxRaycastDist = 0.0f;
    [SerializeField]
    private Transform destinationPoint = null;
    [SerializeField]
    private Transform raycastOrigin = null;
    //private Vector3 destDir = Vector3.zero;
    private List<Vector3> tmpDirs = new List<Vector3>();
    private List<Vector3> tmpRots = new List<Vector3>();
    private Vector3 destinationDir = Vector3.zero;

    [Header("Thrust Modification Variables")]
    [SerializeField]
    private PID thrustController = null;
    [SerializeField]
    private float toThrustVel = 0.0f;
    [SerializeField]
    private float maxThrustVel = 0.0f;
    [SerializeField]
    private float thrustGain = 0.0f;
    [SerializeField]
    private float thrustArrivalThreshold = 0.0f;
    [SerializeField]
    private bool isThrusting = false;

    [Header("Pitch Modification Variables")]
    [SerializeField]
    private PID pitchController = null;
    [SerializeField]
    private float toPitchVel = 0.0f;
    [SerializeField]
    private float maxPitchVel = 0.0f;
    [SerializeField]
    private float pitchGain = 0.0f;
    [SerializeField]
    private float pitchDiffThreshold = 0.0f;
    [SerializeField]
    private float pitchArrivalThreshold = 0.0f;
    [SerializeField]
    private bool isPitching = false;

    [Header("Yaw Modification Variables")]
    [SerializeField]
    private PID yawController = null;
    [SerializeField]
    private float toYawVel = 0.0f;
    [SerializeField]
    private float maxYawVel = 0.0f;
    [SerializeField]
    private float yawGain = 0.0f;
    [SerializeField]
    private float yawDiffThreshold = 0.0f;
    [SerializeField]
    private float yawArrivalThreshold = 0.0f;
    [SerializeField]
    private bool isYawing = false;

    [Header("Roll Modification Variables")]
    [SerializeField]
    private PID rollController = null;
    [SerializeField]
    private float toRollVel = 0.0f;
    [SerializeField]
    private float maxRollVel = 0.0f;
    [SerializeField]
    private float rollGain = 0.0f;
    [SerializeField]
    private float rollArrivalThreshold = 0.0f;
    [SerializeField]
    private bool isRolling = false;

    [Header("Look Snap Variables")]
    [SerializeField]
    private float lookArrivalThreshold = 0.0f;
    //[SerializeField]
    //angle threshold to start snap to
    //private float lookStopThreshold = 0.0f;
    [SerializeField]
    private float snapLookErrorThreshold = 0.0f;

    [Header("Closeness Damping Variables")]
    [SerializeField]
    private float closenessLookDampeningDistThreshold = 0.0f;
    [SerializeField]
    private float dampeningModifier = 0.0f;

    public override void Awake() {
        Init();
        CalculateMaximumVelocities();
        base.Awake();
    }

    public override void Update() {
        base.Update();
    }

    public override void FixedUpdate() {
        HandleAIShipMovement();
        base.FixedUpdate();
    }

    private void Init() {
    }

    private void HandleAIShipMovement() {
        //print("Ship distance: " + Vector3.Distance(transform.position, destinationPoint.position).ToString("F10"));
        if (transform.position == destinationPoint.position) {
            HandleAIShipRolling();
            return;
        }
        CalculatePaths();
        DebugPaths();
        NavigatePathPID(GetNavigationDirection());
        ResetRaycastOrigin();
    }

    private void CalculateMaximumVelocities() {
        maxPitchVel = ((pitchSpeed / shipBody.angularDrag) - Time.fixedDeltaTime * pitchSpeed) / shipBody.inertiaTensor.x;
        maxRollVel = ((rollSpeed / shipBody.angularDrag) - Time.fixedDeltaTime * rollSpeed) / shipBody.inertiaTensor.z;
        maxThrustVel = ((thrustSpeed / shipBody.drag) - Time.fixedDeltaTime * thrustSpeed) / shipBody.mass;
        maxYawVel = ((yawSpeed / shipBody.angularDrag) - Time.fixedDeltaTime * yawSpeed) / shipBody.inertiaTensor.y;
    }

    #region Path Generation
    /* Rotation Notes
     * Yaw: Right positive, Left negative
     * Pitch: Down positive, Up negative
    */
    private void CalculatePaths() {
        tmpRots.Clear();
        tmpDirs.Clear();
        Vector3 destDir = destinationPoint.position - raycastOrigin.position;
        Quaternion destRotWorld = Quaternion.LookRotation(destDir, destinationPoint.up);
        Vector3 destRotLocal = (Quaternion.Inverse(shipBody.transform.root.rotation) * destRotWorld).eulerAngles;
        raycastOrigin.localEulerAngles = destRotLocal;
        //adds forward facing destination cast
        destinationDir = raycastOrigin.forward;
        AddPath(destRotLocal, Vector3.up, 0.0f);
        //set step dist and gap
        if (numOfPathingSteps % 2 == 0) {
            //even
            pathingStepDist = 180.0f / (numOfPathingSteps + 2.0f);
            pathingStepGap = pathingStepDist;
        }
        else {
            //odd
            pathingStepDist = 180.0f / (numOfPathingSteps + 1.0f);
            pathingStepGap = 0.0f;
        }
        //print("Pathing Step Distance: " + pathingStepDist);
        //print("Pathing Step Gap: " + pathingStepGap);
        AddAxesPaths(destRotLocal, pathingStepDist, pathingStepGap);
        //adds back facing cast
        AddPath(destRotLocal, Vector3.up, 180.0f);
    }

    private void AddAxesPaths(Vector3 startRot, float stepDistance, float gapDistance) {
        //left
        AddAxisPaths(startRot, Vector3.up, -stepDistance, -gapDistance);
        //right
        AddAxisPaths(startRot, Vector3.up, stepDistance, gapDistance);
        //up
        AddAxisPaths(startRot, Vector3.right, -stepDistance, -gapDistance);
        //down
        AddAxisPaths(startRot, Vector3.right, stepDistance, gapDistance);
        //up-left
        AddAxisPaths(startRot, Vector3.up, Vector3.right, -45.0f, -stepDistance, -gapDistance);
        //up-right
        AddAxisPaths(startRot, Vector3.up, Vector3.right, 45.0f, -stepDistance, -gapDistance);
        //down-left
        AddAxisPaths(startRot, Vector3.up, Vector3.right, -45.0f, stepDistance, gapDistance);
        //down-right
        AddAxisPaths(startRot, Vector3.up, Vector3.right, 45.0f, stepDistance, gapDistance);
    }

    private void AddAxisPaths(Vector3 startRot, Vector3 globalRotAxis, float stepDistance, float gapDistance) {
        for (int i = 0; i < numOfPathingSteps; i++) {
            if (i >= numOfPathingSteps / 2) {
                //add gap
                AddPath(startRot, globalRotAxis, (stepDistance * (i + 1)) + gapDistance);
            }
            else {
                AddPath(startRot, globalRotAxis, stepDistance * (i + 1));
            }
        }
    }

    //only rotate once on globalRotAxis1
    private void AddAxisPaths(Vector3 startRot, Vector3 globalRotAxis1, Vector3 globalRotAxis2, float stepDistance1, float stepDistance2, float gapDistance2) {
        for (int i = 0; i < numOfPathingSteps; i++) {
            if (i >= numOfPathingSteps / 2) {
                //add gap
                AddPath(startRot, globalRotAxis1, globalRotAxis2, stepDistance1, (stepDistance2 * (i + 1)) + gapDistance2);
            }
            else {
                AddPath(startRot, globalRotAxis1, globalRotAxis2, stepDistance1, stepDistance2 * (i + 1));
            }
        }
    }

    //used for single rotation changes
    private void AddPath(Vector3 startRot, Vector3 globalRotAxis, float rotAmount) {
        raycastOrigin.Rotate(globalRotAxis, rotAmount, Space.Self);
        if (!tmpRots.Contains(raycastOrigin.localEulerAngles)) {
            tmpRots.Add(raycastOrigin.localEulerAngles);
            tmpDirs.Add(raycastOrigin.forward);
        }
        raycastOrigin.localEulerAngles = startRot;
    }

    //used for multi rotation changes
    private void AddPath(Vector3 startRot, Vector3 globalRotAxis1, Vector3 globalRotAxis2, float rotAmount1, float rotAmount2) {
        raycastOrigin.Rotate(globalRotAxis1, rotAmount1, Space.Self);
        raycastOrigin.Rotate(globalRotAxis2, rotAmount2, Space.Self);
        if (!tmpRots.Contains(raycastOrigin.localEulerAngles)) {
            tmpRots.Add(raycastOrigin.localEulerAngles);
            tmpDirs.Add(raycastOrigin.forward);
        }
        raycastOrigin.localEulerAngles = startRot;
    }

    private void ResetRaycastOrigin() {
        raycastOrigin.localEulerAngles = Vector3.zero;
    }

    private void DebugPaths() {
        for (int i = 0; i < tmpRots.Count; i++) {
            DebugPath(tmpRots[i]);
        }
    }

    private void DebugPath(Vector3 originRotation) {
        raycastOrigin.localEulerAngles = originRotation;
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRaycastDist);
    }

    private void DebugPath(Vector3 originRotation, Color col) {
        raycastOrigin.localEulerAngles = originRotation;
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRaycastDist, col);
    }

    //ENSURE PATHS ARE ORDERED FROM CLOSEST TO FARTHEST
    private void OrderNavigationPaths() {

    }

    //returns first clear path or last obstructed path
    private Vector3 GetNavigationDirection() {
        for (int i = 0; i < tmpRots.Count; i++) {
            if (IsPathClear(tmpRots[i])) {
                DebugPath(tmpRots[i], Color.yellow);
                return tmpDirs[i];
            }
        }
        return tmpDirs[tmpDirs.Count - 1];
    }

    //raycast along rotation to determine if path is clear
    private bool IsPathClear(Vector3 originLocalEulers) {
        List<RaycastHit> rayHitInfos = new List<RaycastHit>();
        float destDist = Vector3.Distance(transform.position, destinationPoint.position);
        float rayDist = Mathf.Min(destDist, maxRaycastDist);
        raycastOrigin.localEulerAngles = originLocalEulers;
        //raycast
        rayHitInfos.AddRange(Physics.RaycastAll(raycastOrigin.position, raycastOrigin.forward, rayDist));
        //ORDER HITS BY DISTANCE!!!!!!!!!!!!!!!
        for (int i = 0; i < rayHitInfos.Count; i++) {
            if (rayHitInfos[i].transform == destinationPoint) {
                //print("Destination point is visible!");
                return true;
            }
            if (rayHitInfos[i].transform.root != transform.root) {
                return false;
            }
        }
        return true;
    }
    #endregion

    #region Helper Functions
    private Vector3 GetRotation360Remainder(Vector3 rotationEulerAngles) {
        return new Vector3(rotationEulerAngles.x % 360.0f, rotationEulerAngles.y % 360.0f, rotationEulerAngles.z % 360.0f);
    }

    private float ConvertRotationValue180(float axisValue) {
        if (axisValue > 180.0f) {
            return -1.0f * (360.0f - axisValue);
        }
        return axisValue;
    }

    private Vector3 ConvertRotation180(Vector3 localRotation) {
        return new Vector3(ConvertRotationValue180(localRotation.x), ConvertRotationValue180(localRotation.y), ConvertRotationValue180(localRotation.z));
    }

    private Vector3 ConvertLocalDirectionToGlobalDirection() {
        return Vector3.zero;
    }

    //uses dot and current velocity to better determine desired thrust
    private float ComputeModifiedDot(float dot, float thrustVelPercent) {
        if (Mathf.Sign(dot * thrustVelPercent) == -1) {
            return dot + thrustVelPercent;
        }
        return dot;
    }
    #endregion

    private void NavigatePathPID(Vector3 pathDir) {
        HandleAIShipLooking(pathDir);
        HandleAIShipRolling();
        HandleAIShipThrusting(pathDir);
    }

    private void HandleAIShipLooking(Vector3 pathDir) {
        if (!isRolling) {
            if (IsLookCloseEnoughToSnap(pathDir)) {
                LookAtPathDirection(pathDir);
            }
            else {
                if (IsPitchCloseEnoughToSnap(pathDir)) {
                    PitchToDesiredPosition(pathDir);
                }
                else {
                    ComputePitchPID(pathDir);
                }
                if (IsYawCloseEnoughToSnap(pathDir)) {
                    YawToDesiredPosition(pathDir);
                }
                else {
                    ComputeYawPID(pathDir);
                }
            }
        }
    }

    private void HandleAIShipRolling() {
        //replace 0.0f with an AI designated roll value
        if (!isPitching && !isYawing) {
            if (IsRollCloseEnoughToSnap(0.0f)) {
                RollToDesiredPosition(0.0f);
            }
            else {
                ComputeRollPID(0.0f);
            }
        }
    }

    private void HandleAIShipThrusting(Vector3 pathDir) {
        if (IsThrustCloseEnoughToSnap(destinationPoint.position)) {
            SnapThrustPositionToDesiredPosition(destinationPoint.position);
        }
        else {
            ComputeThrustPIDModified(pathDir);
        }
    }

    private bool IsLookCloseEnoughToSnap(Vector3 pathDir) {
        if (Vector3.Angle(transform.forward, pathDir) < lookArrivalThreshold) {
            return true;
        }
        return false;
    }

    private bool IsPitchCloseEnoughToSnap(Vector3 pathDir) {
        if (Mathf.Abs(GetPitchDifference(pathDir)) < pitchArrivalThreshold) {
            return true;
        }
        return false;
    }

    private bool IsYawCloseEnoughToSnap(Vector3 pathDir) {
        if (Mathf.Abs(GetYawDifference(pathDir)) < yawArrivalThreshold) {
            return true;
        }
        return false;
    }

    private bool IsRollCloseEnoughToSnap(float desiredZRot) {
        //print("Roll difference: " + GetRollDifference(pathDir, desiredZRot));
        if (Mathf.Abs(GetRollDifference(desiredZRot)) < rollArrivalThreshold) {
            return true;
        }
        return false;
    }

    private bool IsThrustCloseEnoughToSnap(Vector3 desiredPosition) {
        if (Vector3.Distance(transform.position, desiredPosition) < thrustArrivalThreshold) {
            return true;
        }
        return false;
    }

    private void LookAtPathDirection(Vector3 pathDir) {
        Quaternion desiredLookRotQuat = Quaternion.LookRotation(pathDir, transform.up);
        //Vector2 desiredLookRotV2 = new Vector2(desiredLookRotQuat.eulerAngles.x, desiredLookRotQuat.eulerAngles.y);
        //Vector2 currentLookRotV2 = new Vector2(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y);
        //print("Desired look rotation: " + desiredLookRotV2.ToString("F4"));
        //print("Current look rotation: " + currentLookRotV2.ToString("F4"));
        //print("Look difference: " + Vector3.Angle(pathDir, transform.forward).ToString("F10"));
        if (Vector3.Angle(pathDir, transform.forward) < snapLookErrorThreshold) {
            isPitching = false;
            isYawing = false;
            //print("Already looking at path direction!");
            return;
        }
        //if (currentLookRotV2 == desiredLookRotV2) {
        //    isPitching = false;
        //    isYawing = false;
        //    print("Already looking at path direction!");
        //    return;
        //}
        //print("Look at path direction!");
        transform.rotation = desiredLookRotQuat;
        //transform.rotation = Quaternion.LookRotation(pathDir, transform.up);
        ClearLookInputAxes();
        isPitching = true;
        isYawing = true;
    }

    private void PitchToDesiredPosition(Vector3 pathDir) {
        print("Snapping pitch!");
        transform.Rotate(transform.right, GetPitchDifference(pathDir));
        ClearPitchInputAxis();
        isPitching = true;
    }

    private void YawToDesiredPosition(Vector3 pathDir) {
        print("Snapping yaw!");
        transform.Rotate(transform.up, GetYawDifference(pathDir));
        ClearYawInputAxis();
        isYawing = true;
    }

    private void RollToDesiredPosition(float desiredZRot) {
        Vector3 desiredRot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, desiredZRot);
        if (transform.rotation == Quaternion.Euler(desiredRot)) {
            isRolling = false;
            return;
        }
        transform.rotation = Quaternion.Euler(desiredRot);
        ClearRollInputAxis();
        isRolling = true;
    }

    private void SnapThrustPositionToDesiredPosition(Vector3 desiredPosition) {
        ClearThrustInputAxis();
        ClearLookInputAxes();
        transform.position = desiredPosition;
    }

    private void ClearLookInputAxes() {
        shipBody.angularVelocity = new Vector3(0.0f, 0.0f, shipBody.angularVelocity.z);
        inputPitchAxis = 0.0f;
        inputYawAxis = 0.0f;
    }

    private void ClearPitchInputAxis() {
        shipBody.angularVelocity = new Vector3(0.0f, shipBody.angularVelocity.y, shipBody.angularVelocity.z);
        inputPitchAxis = 0.0f;
    }

    private void ClearYawInputAxis() {
        shipBody.angularVelocity = new Vector3(shipBody.angularVelocity.x, 0.0f, shipBody.angularVelocity.z);
        inputYawAxis = 0.0f;
    }

    private void ClearRollInputAxis() {
        shipBody.angularVelocity = new Vector3(shipBody.angularVelocity.x, shipBody.angularVelocity.y, 0.0f);
        inputRollAxis = 0.0f;
    }

    private void ClearThrustInputAxis() {
        shipBody.velocity = Vector3.zero;
        inputThrustAxis = 0.0f;
    }

    private float GetRollDifference(float desiredZRot) {
        Vector3 desiredRot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, desiredZRot);
        GameObject tmpGo = new GameObject();
        tmpGo.transform.position = transform.position;
        tmpGo.transform.rotation = Quaternion.Euler(desiredRot);
        float rollDiff = Vector3.SignedAngle(transform.up, tmpGo.transform.up, transform.forward);
        Destroy(tmpGo);
        return rollDiff;
    }

    private float GetPitchDifference(Vector3 targetDir) {
        Vector3 projected = Vector3.ProjectOnPlane(targetDir, transform.right);
        //Vector3 crossAxis = Vector3.Cross(targetDir, transform.forward);
        //Debug.DrawRay(transform.position, crossAxis * 10.0f, Color.magenta);
        //float angle = Vector3.Angle(transform.forward, projected);
        float angle = Vector3.SignedAngle(transform.forward, projected, transform.right);
        //print("Pitch projection: " + projected.ToString("F4") + "!");
        //print("Pitch angle diff: " + angle.ToString("F4") + "!");
        return angle;
    }

    private float GetYawDifference(Vector3 targetDir) {
        Vector3 projected = Vector3.ProjectOnPlane(targetDir, transform.up);
        float angle = Vector3.SignedAngle(transform.forward, projected, transform.up);
        //print("Yaw projection: " + projected.ToString("F4") + "!");
        //print("Yaw angle diff: " + angle.ToString("F4") + "!");
        return angle;
    }

    private void ComputeRollPID(float desiredZRot) {
        if (!isPitching && !isYawing) {
            //print("Is computing roll!");
            float rollDiff = GetRollDifference(desiredZRot);
            isRolling = true;
            float tgtVel = toRollVel * rollDiff;
            tgtVel = Mathf.Clamp(tgtVel, -maxRollVel, maxRollVel);
            //isolate x axis error
            float error = rollController.Update(tgtVel, localAngularVelocity.z, Time.deltaTime);
            //print("Pitch Error: " + error.ToString("F4"));
            //calc a target pitchVel proportional to pitchError (clamped to maxPitchVel)
            //calc a force proportional to the error (clamped to maxPitchForce)
            float force = rollGain * error * shipBody.inertiaTensor.z * (1.0f / (1.0f - shipBody.angularDrag));
            //print("Unclamped Pitch Force: " + force.ToString("F4"));
            force = Mathf.Clamp(force, -rollSpeed, rollSpeed);
            //print("Clamped Pitch Force: " + force.ToString("F4"));
            float forceFactor = force / rollSpeed;
            //print("Pitch Force Factor: " + forceFactor.ToString("F4"));
            //print("Target Velocity: " + tgtVel.ToString("F4") + ", Error: " + error.ToString("F4") + ", Ship Angular Velocity: " + shipBody.angularVelocity.x.ToString("F4") + ", Force: " + force.ToString("F4") + "!");
            inputRollAxis = forceFactor;
        }
    }

    private void ComputePitchPID(Vector3 pathDir) {
        if (!isRolling) {
            //print("Is computing pitch!");
            float pitchDiff = GetPitchDifference(pathDir);
            //if (Mathf.Abs(pitchDiff) < pitchDiffThreshold) {
            //    pitchDiff = 0.0f;
            //}
            isPitching = true;
            float tgtVel = toPitchVel * pitchDiff;
            tgtVel = Mathf.Clamp(tgtVel, -maxPitchVel, maxPitchVel);
            //isolate x axis error
            float error = pitchController.Update(tgtVel, localAngularVelocity.x, Time.deltaTime);
            //print("Pitch Error: " + error.ToString("F4"));
            //calc a target pitchVel proportional to pitchError (clamped to maxPitchVel)
            //calc a force proportional to the error (clamped to maxPitchForce)
            float force = pitchGain * error * shipBody.inertiaTensor.x * (1.0f / (1.0f - shipBody.angularDrag));
            //print("Unclamped Pitch Force: " + force.ToString("F4"));
            force = Mathf.Clamp(force, -pitchSpeed, pitchSpeed);
            //print("Clamped Pitch Force: " + force.ToString("F4"));
            float forceFactor = force / pitchSpeed;
            //print("Pitch Force Factor: " + forceFactor.ToString("F4"));
            //print("Target Velocity: " + tgtVel.ToString("F4") + ", Error: " + error.ToString("F4") + ", Ship Angular Velocity: " + shipBody.angularVelocity.x.ToString("F4") + ", Force: " + force.ToString("F4") + "!");
            inputPitchAxis = forceFactor;
        }
    }

    private void ComputeYawPID(Vector3 pathDir) {
        if (!isRolling) {
            //print("Is computing yaw!");
            float yawDiff = GetYawDifference(pathDir);
            //if (Mathf.Abs(yawDiff) < yawDiffThreshold) {
            //    ClearYawInputAxis();
            //    return;
            //}
            isYawing = true;
            float tgtVel = toYawVel * yawDiff;
            tgtVel = Mathf.Clamp(tgtVel, -maxYawVel, maxYawVel);
            //print("Yaw Difference: " + yawDiff.ToString("F4"));
            //print("Yaw tgt vel: " + tgtVel.ToString("F4"));
            //isolate y axis error
            //print("Local angular velocity Y: " + localAngularVelocity.y);
            float error = yawController.Update(tgtVel, localAngularVelocity.y, Time.deltaTime);
            //print("Yaw Error: " + error.ToString("F4"));
            //calc a target yawVel proportional to yawError (clamped to maxYawVel)
            //calc a force proportional to the error (clamped to maxYawForce)
            float force = yawGain * error * shipBody.inertiaTensor.y * (1.0f / (1.0f - shipBody.angularDrag));
            //print("Unclamped Yaw Force: " + force.ToString("F4"));
            force = Mathf.Clamp(force, -yawSpeed, yawSpeed);
            //print("Clamped Yaw Force: " + force.ToString("F4"));
            float forceFactor = force / yawSpeed;
            //print("Yaw Force Factor: " + forceFactor.ToString("F4"));
            //print("Target Velocity: " + tgtVel.ToString("F4") + ", Error: " + error.ToString("F4") + ", Ship Angular Velocity: " + shipBody.angularVelocity.y.ToString("F4") + ", Force: " + force.ToString("F4") + "!");
            inputYawAxis = forceFactor;
        }
    }

    private void ComputeThrustPIDModified(Vector3 pathDir) {
        //THIS WILL ENABLE REVERSE THRUST (may need to reverse rotation directions when moving backwards)
        //SWITCH DIST TO DIFFERENCE IN LOCAL Z AXIS, MAKING IT POSITIVE AND NEGATIVE
        float dist = Vector3.Distance(destinationPoint.position, transform.position);
        //print("Distance: " + dist + "!");
        //print("Closest thurst distance: " + closestThrustDist + "!");
        if (Mathf.Abs(dist) < thrustArrivalThreshold) {
            ClearThrustInputAxis();
            return;
        }
        float dot = Vector3.Dot(transform.forward, (destinationPoint.position - transform.position).normalized);
        dot = ComputeModifiedDot(dot, localVelocity.z / maxThrustVel);
        //calc a target vel proportional to distance (clamped to maxVel)
        //print("toThrustVel: " + toThrustVel + ", Distance: " + dist + "!");
        float tgtVel = toThrustVel * (dist * dot);
        tgtVel = Mathf.Clamp(tgtVel, -maxThrustVel, maxThrustVel);
        //calculate the velocity error
        float error = thrustController.Update(tgtVel, localVelocity.z, Time.deltaTime);
        //if (Mathf.Abs(error) < thrustErrorThreshold) {
        //    error = 0.0f;
        //    //print("Stopping Thrust!");
        //}
        //calc a force proportional to the error (clamped to maxForce)
        float force = thrustGain * error * shipBody.mass * (1.0f / (1.0f - shipBody.drag));
        force = Mathf.Clamp(force, -thrustSpeed, thrustSpeed);
        float dampForce = ComputeClosenessDampingForce(pathDir);
        dampForce = Mathf.Clamp(dampForce, -thrustSpeed, thrustSpeed);
        //print("Damp force: " + dampForce);
        if (Mathf.Abs(dampForce) > force) {
            force = 0.0f;
        }
        else {
            force += dampForce;
        }
        //print("Force + dampening = " + force + "!");
        //print("Target Velocity: " + tgtVel.ToString("F4") + ", Error: " + error.ToString("F4") + ", Ship Velocity: " + shipBody.velocity.z.ToString("F4") + ", Force: " + force.ToString("F4") + "!");
        float forceFactor = force / thrustSpeed;
        inputThrustAxis = forceFactor;
    }

    private float ComputeClosenessDampingForce(Vector3 pathDir) {
        if (pathDir != destinationDir) {
            //print("No dampening: not on dest path!");
            return 0.0f;
        }
        float dist = Vector3.Distance(transform.position, destinationPoint.position);
        if (dist > closenessLookDampeningDistThreshold) {
            //print("No dampening: out of range!");
            return 0.0f;
        }
        //compute dampening force
        float dotProd = Vector3.Dot(transform.forward, (destinationPoint.position - transform.position).normalized);
        if (dotProd == 1.0f) {
            return 0.0f;
        }
        float dotModifier = 0.0f;
        float dampForce = dampeningModifier / dist;
        if (Mathf.Sign(dotProd) == 1) {
            dotModifier = 1.0f - dotProd;
            dampForce *= -dotModifier;
        }
        //negative dot
        else {
            dotModifier = 1.0f + dotProd;
            dampForce *= -dotModifier;
        }
        return dampForce;
    }
}