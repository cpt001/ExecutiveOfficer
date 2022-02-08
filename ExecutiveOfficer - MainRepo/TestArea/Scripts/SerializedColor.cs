using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializedColor {
    [SerializeField]
    private float redValue = 0.0f;
    [SerializeField]
    private float greenValue = 0.0f;
    [SerializeField]
    private float blueValue = 0.0f;
    [SerializeField]
    private float alphaValue = 0.0f;

    public float RedValue {
        get {
            return redValue;
        }

        set {
            redValue = value;
        }
    }

    public float GreenValue {
        get {
            return greenValue;
        }

        set {
            greenValue = value;
        }
    }

    public float BlueValue {
        get {
            return blueValue;
        }

        set {
            blueValue = value;
        }
    }

    public float AlphaValue {
        get {
            return alphaValue;
        }

        set {
            alphaValue = value;
        }
    }

    public SerializedColor(Color unityColor) {
        redValue = unityColor.r;
        greenValue = unityColor.g;
        blueValue = unityColor.b;
        alphaValue = unityColor.a;
    }

    public SerializedColor(float r, float g, float b, float a) {
        redValue = r;
        greenValue = g;
        blueValue = b;
        alphaValue = a;
    }
}