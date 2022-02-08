using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializedVector3 {
    [SerializeField]
    private float x = 0.0f;
    [SerializeField]
    private float y = 0.0f;
    [SerializeField]
    private float z = 0.0f;

    public float X {
        get {
            return x;
        }

        set {
            x = value;
        }
    }

    public float Y {
        get {
            return y;
        }

        set {
            y = value;
        }
    }

    public float Z {
        get {
            return z;
        }

        set {
            z = value;
        }
    }

    public SerializedVector3(Vector3 vectorThree) {
        x = vectorThree.x;
        y = vectorThree.y;
        z = vectorThree.z;
    }

    public SerializedVector3(float xValue, float yValue, float zValue) {
        x = xValue;
        y = yValue;
        z = zValue;
    }
}
