using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneAssetData {
    [SerializeField]
    private string assetPath = "";
    //[SerializeField]
    //private int assetIndex = 0;
    [SerializeField]
    private string assetName = "";
    [SerializeField]
    private SerializedVector3 objectPosition = null;
    [SerializeField]
    private SerializedVector3 objectRotation = null;
    [SerializeField]
    private float objectSize = 0.0f;
    [SerializeField]
    private SerializedVector3 angularVelocity = null;

    public string AssetPath {
        get {
            return assetPath;
        }

        set {
            assetPath = value;
        }
    }

    //public int AssetIndex {
    //    get {
    //        return assetIndex;
    //    }

    //    set {
    //        assetIndex = value;
    //    }
    //}

    public string BodyName {
        get {
            return assetName;
        }

        set {
            assetName = value;
        }
    }

    public SerializedVector3 ObjectPosition {
        get {
            return objectPosition;
        }

        set {
            objectPosition = value;
        }
    }

    public SerializedVector3 ObjectRotation {
        get {
            return objectRotation;
        }

        set {
            objectRotation = value;
        }
    }

    public float ObjectSize {
        get {
            return objectSize;
        }

        set {
            objectSize = value;
        }
    }

    public SerializedVector3 AngularVelocity {
        get {
            return angularVelocity;
        }

        set {
            angularVelocity = value;
        }
    }
}