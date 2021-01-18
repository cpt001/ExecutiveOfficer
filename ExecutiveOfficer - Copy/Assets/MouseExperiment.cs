using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseExperiment : MonoBehaviour
{
    private CinemachineVirtualCameraBase cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            //Idea here: input axes will have no definition. When you click the rmb...
            //It defines the mouse input, allowing movement.
            //Else, it removes them.
        }
    }
}
