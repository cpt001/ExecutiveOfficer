using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CelestialBodyData {
    [SerializeField]
    private int assetIndex;
    [SerializeField]
    private string bodyName;
    [SerializeField]
    private float bodyRadius;
    [SerializeField]
    private Vector3 bodyPosition;
    [SerializeField]
    private Vector3 bodyRotation;
    [SerializeField]
    private Vector3 bodyAngularVelocity;

    public int AssetIndex {
        get {
            return assetIndex;
        }

        set {
            assetIndex = value;
        }
    }

    public string BodyName {
        get {
            return bodyName;
        }

        set {
            bodyName = value;
        }
    }

    public float BodyRadius {
        get {
            return bodyRadius;
        }

        set {
            bodyRadius = value;
        }
    }

    public Vector3 BodyPosition {
        get {
            return bodyPosition;
        }

        set {
            bodyPosition = value;
        }
    }

    public Vector3 BodyRotation {
        get {
            return bodyRotation;
        }

        set {
            bodyRotation = value;
        }
    }

    public Vector3 BodyAngularVelocity {
        get {
            return bodyAngularVelocity;
        }

        set {
            bodyAngularVelocity = value;
        }
    }
}