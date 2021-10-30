using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSwapper : MonoBehaviour
{
    public AIShipControllerFinal npcController;
    public Transform wp1;
    public Transform wp2;
    public Transform wp3;
    public Transform wp4;
    public Transform wp5;

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
        RaycastHit rayhit;
        if (Physics.SphereCast(transform.position, 10.0f, Vector3.forward, out rayhit))
        {
            if (rayhit.transform.gameObject == wp1 || rayhit.transform.gameObject == wp2 || rayhit.transform.gameObject == wp3 || rayhit.transform.gameObject == wp4|| rayhit.transform.gameObject == wp5)
            {
                currentWaypoint += 1;
                if (currentWaypoint == Waypoints.wp5 + 1)
                {
                    currentWaypoint = 0;
                }
            }
        }

        switch (currentWaypoint)
        {
            case Waypoints.wp1:
                {
                    npcController.destinationPoint = wp1;
                    break;
                }

            case Waypoints.wp2:
                {
                    npcController.destinationPoint = wp2;
                    break;
                }
            case Waypoints.wp3:
                {
                    npcController.destinationPoint = wp3;
                    break;
                }
            case Waypoints.wp4:
                {
                    npcController.destinationPoint = wp4;
                    break;
                }
            case Waypoints.wp5:
                {
                    npcController.destinationPoint = wp5;
                    break;
                }
        }
    }
}
