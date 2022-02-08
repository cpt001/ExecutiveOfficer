using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorList : MonoBehaviour
{
    public List<ShipModule> moduleList = new List<ShipModule>();

    // Start is called before the first frame update
    void Awake()
    {
        GetSubobjects();
    }

    void GetSubobjects()
    {
        foreach(Transform child in transform)
        {
            moduleList.Add(child.GetComponent<ShipModule>());
        }
    }
}
