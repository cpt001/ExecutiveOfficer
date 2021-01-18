using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInstantiation : MonoBehaviour
{
    public GameObject itemToInstantiate;
    public float timeToWait;
    private bool canInstantiate;

    // Update is called once per frame
    void Update()
    {
        if (canInstantiate)
        {
            StartCoroutine(SpawnObject());
        }
    }

    private IEnumerator SpawnObject()
    {
        canInstantiate = false;
        Instantiate(itemToInstantiate, transform.position, transform.rotation);
        yield return new WaitForSeconds(timeToWait);
        canInstantiate = true;
    }
}
