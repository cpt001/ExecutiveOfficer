using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public float coneOfVision;
    public float visionRange;
    
    void Update()
    {
        RaycastHit LeftEdgeRay;
        RaycastHit RightEdgeRay;
        RaycastHit CenterRay;

        if (Physics.Raycast(transform.position, new Vector3(0, 0, coneOfVision), out LeftEdgeRay, visionRange))
        {

        }
        if (Physics.Raycast(transform.position, new Vector3(0, 0, -coneOfVision), out RightEdgeRay, visionRange))
        {

        }
        if (Physics.Raycast(transform.position, Vector3.forward, out CenterRay, visionRange))
        {

        }

        Debug.DrawRay(transform.position, new Vector3(0, 0, coneOfVision), Color.green, visionRange);
        Debug.DrawRay(transform.position, new Vector3(0, 0, -coneOfVision), Color.green, visionRange);
        Debug.DrawRay(transform.position, Vector3.forward, Color.green, visionRange);
    }
}
