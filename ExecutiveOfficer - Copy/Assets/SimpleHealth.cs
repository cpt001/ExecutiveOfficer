using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHealth : MonoBehaviour
{
    public float mainHP = 100.0f;
    public GameObject destroyedObject;
    public float damageTaken = 0;
    public bool damageApplied;

    private void Update()
    {
        if (!damageApplied)
        {
            TakeDamage(damageTaken);
        }

        if (mainHP <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Instantiate(destroyedObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void TakeDamage(float damageTaken)
    {
        mainHP -= damageTaken;
        damageApplied = true;
    }
}
