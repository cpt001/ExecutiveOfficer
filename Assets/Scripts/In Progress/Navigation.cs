using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Need to invert autopilot function, only adjust position when player holds mouse
/// Need to remove autothrust, replace with player input
/// Force application seems constant?
/// |Doesn't like cinemachine interpolation
/// >Master object rotation isnt changing, may be result of cinemachine itself
/// 
/// 
/// 
/// overall things to fix:
/// Rotation insanity
/// x/y rotation lock
/// cam click and drag
/// turret undershooting?
/// what should be included in a settings tab?
/// json saving brush up
/// missile integration?
/// </summary>

namespace MFlight
{
    [RequireComponent(typeof(Rigidbody))]
    public class Navigation : MonoBehaviour
    {
        [Header("Components")]
        //[SerializeField] private MouseFlightController controller = null;
        [SerializeField] private Camera cam;

        [Header("Physics")]

        [Tooltip("Force to push plane forwards with")] public float thrust = 100f;
        [Tooltip("Pitch, Yaw, Roll")] public Vector3 turnTorque = new Vector3(90f, 25f, 45f);
        [Tooltip("Multiplier for all forces")] public float forceMult = 1000f;
        [Tooltip("Turn Torque multiplyer")] public float turnMult = 500f;

        [Header("Autopilot")]
        [Tooltip("Sensitivity for autopilot flight.")] public float sensitivity = 5f;
        [Tooltip("Angle at which airplane banks fully into target.")] public float aggressiveTurnAngle = 10f;

        [Header("Input")]
        [SerializeField] [Range(-1f, 1f)] private float pitch = 0f;
        [SerializeField] [Range(-1f, 1f)] private float yaw = 0f;
        [SerializeField] [Range(-1f, 1f)] private float roll = 0f;

        public float Pitch { set { pitch = Mathf.Clamp(value, -1f, 1f); } get { return pitch; } }
        public float Yaw { set { yaw = Mathf.Clamp(value, -1f, 1f); } get { return yaw; } }
        public float Roll { set { roll = Mathf.Clamp(value, -1f, 1f); } get { return roll; } }

        private Rigidbody rigid;

        private bool rollOverride = false;
        private bool pitchOverride = false;

        public float forceToAdd;

        public GameObject engineLightSet;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();

            cam = Camera.main;
            /*if (controller == null)
                Debug.LogError(name + ": Plane - Missing reference to MouseFlightController!");*/
        }

        /*private void Update()
        {
            // When the player commands their own stick input, it should override what the
            // autopilot is trying to do.
            rollOverride = false;
            pitchOverride = false;

            float keyboardRoll = Input.GetAxis("Horizontal");
            if (Mathf.Abs(keyboardRoll) > .25f)
            {
                rollOverride = true;
            }

            float keyboardPitch = Input.GetAxis("Vertical");
            if (Mathf.Abs(keyboardPitch) > .25f)
            {
                pitchOverride = true;
                rollOverride = true;
            }

            // Calculate the autopilot stick inputs.
            float autoYaw = 0f;
            float autoPitch = 0f;
            float autoRoll = 0f;
            if (cam != null)
                RunAutopilot(-cam.transform.position, out autoYaw, out autoPitch, out autoRoll);

            // Use either keyboard or autopilot input.
            yaw = autoYaw;
            pitch = (pitchOverride) ? keyboardPitch : autoPitch;
            roll = (rollOverride) ? keyboardRoll : autoRoll;
        }*/

        private void RunAutopilot(Vector3 flyTarget, out float yaw, out float pitch, out float roll)
        {
            // Freelook
            if (Input.GetMouseButton(0))
            {

                // This is my usual trick of converting the fly to position to local space.
                // You can derive a lot of information from where the target is relative to self.
                var localFlyTarget = transform.InverseTransformPoint(flyTarget).normalized * sensitivity;
                var angleOffTarget = Vector3.Angle(transform.forward, flyTarget - transform.position);

                // IMPORTANT!
                // These inputs are created proportionally. This means it can be prone to
                // overshooting. The physics in this example are tweaked so that it's not a big
                // issue, but in something with different or more realistic physics this might
                // not be the case. Use of a PID controller for each axis is highly recommended.

                // ====================
                // PITCH AND YAW
                // ====================

                // Yaw/Pitch into the target so as to put it directly in front of the aircraft.
                // A target is directly in front the aircraft if the relative X and Y are both
                // zero. Note this does not handle for the case where the target is directly behind.
                yaw = Mathf.Clamp(localFlyTarget.x, -1f, 1f);
                pitch = -Mathf.Clamp(localFlyTarget.y, -1f, 1f);

                // ====================
                // ROLL
                // ====================

                // Roll is a little special because there are two different roll commands depending
                // on the situation. When the target is off axis, then the plane should roll into it.
                // When the target is directly in front, the plane should fly wings level.

                // An "aggressive roll" is input such that the aircraft rolls into the target so
                // that pitching up (handled above) will put the nose onto the target. This is
                // done by rolling such that the X component of the target's position is zeroed.
                var agressiveRoll = Mathf.Clamp(localFlyTarget.x, -1f, 1f);

                // A "wings level roll" is a roll commands the aircraft to fly wings level.
                // This can be done by zeroing out the Y component of the aircraft's right.
                var wingsLevelRoll = transform.right.y;

                // Blend between auto level and banking into the target.
                var wingsLevelInfluence = Mathf.InverseLerp(0f, aggressiveTurnAngle, angleOffTarget);
                roll = Mathf.Lerp(wingsLevelRoll, agressiveRoll, wingsLevelInfluence);
            }
            else
            {
                yaw = 0;
                pitch = 0;
                roll = 0;
                return;
            }
        }

        private void FixedUpdate()
        {
            if (forceToAdd > 1)
            {
                engineLightSet.SetActive(true);
            }
            else
            {
                engineLightSet.SetActive(false);
            }

            if (Input.GetKey(KeyCode.W) && forceToAdd <= 120.0f)
            {
                forceToAdd++;
            }
            if (Input.GetKey(KeyCode.S) && forceToAdd >= 0)
            {
                forceToAdd--;
            }
            thrust = Mathf.Clamp(forceToAdd, 0, 120.0f);

            // Ultra simple flight where the plane just gets pushed forward and manipulated
            // with torques to turn.
            rigid.AddRelativeForce(Vector3.forward * thrust * forceMult, ForceMode.Force);
            rigid.AddRelativeTorque(new Vector3(turnTorque.x * pitch,
                                                turnTorque.y * yaw,
                                                -turnTorque.z * roll) * turnMult,
                                    ForceMode.Force);

            if (Input.GetKey(KeyCode.D) && roll <= 1)
            {
                roll++;
            }
            else if (Input.GetKey(KeyCode.A) && roll >= -1)
            {
                roll--;
            }
            else
            {
                roll = 0;
            }

            if (Input.GetKey(KeyCode.R) && pitch <= 1)
            {
                pitch++;
            }
            else if (Input.GetKey(KeyCode.C) && pitch >= -1)
            {
                pitch--;
            }
            else
            {
                pitch = 0;
            }
        }
    }
}
