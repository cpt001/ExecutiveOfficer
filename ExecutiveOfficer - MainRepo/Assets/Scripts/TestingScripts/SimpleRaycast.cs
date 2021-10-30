using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRaycast : MonoBehaviour
{
    public float castDistance = 2.0f;
    public float rayDuration = 1.0f;

    private GameObject damageObject;

    private LayerMask layerMask = 16;

    // Update is called once per frame
    void LateUpdate()
    {
        RaycastHit rayHit;
        Debug.DrawRay(transform.position, transform.forward, Color.red, rayDuration, depthTest: true);
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, castDistance, layerMask))
        {
            Debug.Log("Raycast Hit: " + rayHit);
            if (rayHit.transform.tag == "Player" || rayHit.transform.GetComponentInParent<Transform>().tag == "Player")
            {
                damageObject = FindClosestDamageable();
                Debug.Log("Impacted ship: " + rayHit.transform.name + " Damage applied to object: " + damageObject.name);
            }
            else
            {
                DamageTurret();
            }
        }
    }

    public void DamageTurret()
    {
        Debug.Log("Projectile Hit: " + gameObject.name);
    }

    /// <summary>
    /// This function is built as a stand in temp. Needs to applied to projectile - M
    /// </summary>

    public GameObject FindClosestDamageable()
    {
        GameObject ClosestTarget;
        float distanceToClosestDamageableObject = Mathf.Infinity;   //Distance definition
        GameObject closestDamageable = null;  //The closest object to the impact position
        GameObject[] allHealthItems = GameObject.FindGameObjectsWithTag("DamagePoint");  //Finds all objects that keep track damage

        foreach(GameObject damageableItem in allHealthItems)
        {
            float distanceToAllDamageableObject = (damageableItem.transform.position - transform.position).sqrMagnitude;    //Distance check conversion, damageable item compared to impact point.
            if (distanceToAllDamageableObject < distanceToClosestDamageableObject)  //If the nearest object isnt closer than the last to the impact pos
            {
                distanceToClosestDamageableObject = distanceToAllDamageableObject;  //Nearest obj is updated to be that
                closestDamageable = damageableItem; //Iterates until it finds the closest
            }
        }
        ClosestTarget = closestDamageable;
        return ClosestTarget;
        //itemToDamage = closestDamageable; //Applies damage to correct pos
    }
}
