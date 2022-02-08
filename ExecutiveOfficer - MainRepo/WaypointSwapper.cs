using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSwapper : MonoBehaviour
{
    public AIShipControllerFinal npcController;
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    public Transform waypoint4;
    public Transform waypoint5;
    private bool swapLocked;

    public enum Waypoints
    {
        wp1,
        wp2,
        wp3,
        wp4,
        wp5
    }
    public Waypoints currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        npcController = GetComponent<AIShipControllerFinal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaypoint == Waypoints.wp5 + 1)
        {
            currentWaypoint = 0;
        }

        switch (currentWaypoint)
        {
            case Waypoints.wp1:
                {
                    npcController.destinationPoint = waypoint1;
                    break;
                }

            case Waypoints.wp2:
                {
                    npcController.destinationPoint = waypoint2;
                    break;
                }
            case Waypoints.wp3:
                {
                    npcController.destinationPoint = waypoint3;
                    break;
                }
            case Waypoints.wp4:
                {
                    npcController.destinationPoint = waypoint4;
                    break;
                }
            case Waypoints.wp5:
                {
                    npcController.destinationPoint = waypoint5;
                    break;
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == waypoint1 || other.transform == waypoint2 || other.transform == waypoint3 || other.transform == waypoint4 || other.transform == waypoint5 && !swapLocked)
        {
            currentWaypoint++;
            swapLocked = true;
            StartCoroutine(SwapLock());
        }
    }

    private IEnumerator SwapLock()
    {
        yield return new WaitForSeconds(30.0f);
        swapLocked = false;
    }
}
