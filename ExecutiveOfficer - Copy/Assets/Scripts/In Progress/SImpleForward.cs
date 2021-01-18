using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SImpleForward : MonoBehaviour
{
    public float thrust;
    //public Vector3 turnTorque = new Vector3(90f, 25f, 45f);
    public float forceMult = 1000f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddRelativeForce(Vector3.forward * thrust * forceMult, ForceMode.Force);
    }
}
