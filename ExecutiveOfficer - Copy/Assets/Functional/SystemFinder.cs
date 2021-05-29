using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SystemFinder : MonoBehaviour
{
    /// <summary>
    /// Graph system...?
    /// Graph keeps track of node and vertice
    /// -To autopop, foreach, limit num vertices
    /// 
    /// primary optimization is reducing search space
    /// 
    /// </summary>
    public Collider[] nearbySystems;
    public SystemBehaviour gmb;
    private float detectionRange = 12.0f;
    //public bool FindSystems;
    public List<Collider> connectedSystems = new List<Collider>();
    private LayerMask starVisualMask;
    /*[Range(2, 6)]
    public int numSystemsConnected;*/
    //create a new variable for max num systems connected
    //May still need to introduce some way to limit #executions at once
    /// <summary>
    /// Detection still isnt being properly limited by the system count
    /// </summary>
    /// 
    public void FindSystems()
    {
        starVisualMask = LayerMask.GetMask("StarVisual");
        //numSystemsConnected = Random.Range(2, 6);
        gmb = gameObject.GetComponent<SystemBehaviour>();
        if (gmb != null)
        {
            //Create a new spherecast system that tiers upward until connected systems list is populated or maxnumsystems is saturated
            nearbySystems = Physics.OverlapSphere(transform.position, detectionRange, ~starVisualMask);

            nearbySystems.OrderBy((star) => (star.gameObject.transform.position - transform.position).sqrMagnitude).ToArray();

            //Need to remove excess systems here
            int tmpConnectionCount = 0;
            for (int v = 0; v < nearbySystems.Length; v++)
            {
                if (tmpConnectionCount < gmb.numSystemsConnected)   //tmp isnt initializing?    Numsyscon isnt working correctly, number isnt matching up to retrieved script somehow.
                {
                    if (nearbySystems[v].gameObject != gameObject) //%% ignore based on layer)
                    {
                        connectedSystems.Add(nearbySystems[v]);
                        tmpConnectionCount++;
                    }
                    /*else
                    {
                        continue;   //continues with for loop regardless of finding self
                    }*/
                }
            }
        }

        foreach (Collider star in nearbySystems)
        {
            Debug.DrawLine(transform.position, star.gameObject.transform.position, Color.blue, Mathf.Infinity);
        }

    }
}
