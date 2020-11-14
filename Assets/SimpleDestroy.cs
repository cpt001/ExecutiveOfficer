using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 4.0f);
    }
}
