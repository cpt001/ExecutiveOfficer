using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    public float timeToDestroy;
    void Update()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
