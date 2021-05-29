using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialPathfinder : MonoBehaviour
{
    /// <summary>
    /// things that must happen for pathfinding to work here.
    /// The AI needs to cast a volume around itself.
    /// -The volume is a series of points in 3d space
    /// -Each point has a bool for navigable based on culling intersection.
    /// When the AI is within 5 nodes of the edge, it generates another field.
    /// -False bools on nodes should stay in memory.
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
