using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabClose : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            gameObject.SetActive(false);
        }
    }
}
