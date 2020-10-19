using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Navigation : MonoBehaviour
{
    public enum NavigationMethod
    {
        Automatic,
        PlayerInput,
    }
    public NavigationMethod navMethod;
    public List<Transform> navPoints = new List<Transform>();

    public Queue<Vector3> waypointNav; //public for purpose of testing


    public float curSpeed;
    public float shipAccelerationSpeed;
    float tempSpeedValue;
    float tempValueAscent;
    public float targetSpeed;   //Speed the player wants
    private float speedAdjustmentMultiplyer = 3f;
    public float maxSpeed = 80.0f;
    public float targetVerticalSpeed;
    public float ascentSpeed;   //Reduces max speed, and adds to ascent, strafe
    public float rollSpeed; //Independent of other speed variables
    public float rotationSpeed;

    public Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMethod == NavigationMethod.PlayerInput)
        {
            if (waypointNav != null)
            {
                waypointNav.Clear();
            }

            UpdateTargetSpeed();
            StartCoroutine(LerpSpeedUpdate());
            UpdateVerticalSpeed();
            StartCoroutine(LerpVerticalSpeedUpdate());
            RigidbodyAdjustments();
        }

        if (navMethod == NavigationMethod.Automatic)
        {
            if (Input.GetMouseButtonDown(1))
            {
                waypointNav.Clear();
                CreateNavPoint();
            }
            if (Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.Space))
            {
                CreateNavPoint();
                
            }
        }
    }

    float UpdateTargetSpeed()
    {
        while (targetSpeed <= maxSpeed) //Less than max speed
        {
            if (Input.GetKey(KeyCode.W))
            {
                targetSpeed += speedAdjustmentMultiplyer * Time.deltaTime;
            }
            break;
        }
        while (targetSpeed >= -maxSpeed)    //Greater than -maxspeed
        {
            if (Input.GetKey(KeyCode.S))
            {
                targetSpeed -= speedAdjustmentMultiplyer * Time.deltaTime;
            }
            break;
        }
        Mathf.RoundToInt(targetSpeed);

        return targetSpeed;
    }
    float UpdateVerticalSpeed()
    {
        while (targetVerticalSpeed <= maxSpeed / 4)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                targetVerticalSpeed += speedAdjustmentMultiplyer / 2 * Time.deltaTime;
            }
        }
        while (targetVerticalSpeed >= -maxSpeed / 4)
        {
            if (Input.GetKey(KeyCode.C))
            {
                targetVerticalSpeed -= speedAdjustmentMultiplyer / 2 * Time.deltaTime;
            }
        }
        Mathf.RoundToInt(targetVerticalSpeed);
        return targetVerticalSpeed;
    }

    IEnumerator LerpSpeedUpdate()
    {
        float time = 0;

        curSpeed = tempSpeedValue;
        while (time < shipAccelerationSpeed)
        {
            tempSpeedValue = Mathf.Lerp(tempSpeedValue, targetSpeed, time / shipAccelerationSpeed);
            time += Time.deltaTime;
            yield return null;
        }
        tempSpeedValue = targetSpeed;
    }
    IEnumerator LerpVerticalSpeedUpdate()
    {
        float time = 0;

        ascentSpeed = tempValueAscent;
        while (time < shipAccelerationSpeed)
        {
            tempValueAscent = Mathf.Lerp(tempValueAscent, targetSpeed, time / shipAccelerationSpeed);
            time += Time.deltaTime;
            yield return null;
        }
        tempValueAscent = targetSpeed;
    }

    void RigidbodyAdjustments()
    {
        _rb.AddForce(new Vector3(targetSpeed, ascentSpeed).normalized, ForceMode.Force);
    }



    /// <summary>
    /// If automatic method is selected
    /// Create navTransform at position right click, clears queue
    /// If shift is held, enqueue positions, add to list
    /// </summary>
    void CreateNavPoint()
    {
        Vector2 mousePos = new Vector2();
        mousePos.x = Event.current.mousePosition.x;
        mousePos.y = Camera.main.pixelHeight - Event.current.mousePosition.y;

        Vector3 navPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        waypointNav.Enqueue(navPoint);
    }
}
