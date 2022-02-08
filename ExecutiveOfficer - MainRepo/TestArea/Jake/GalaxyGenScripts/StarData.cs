using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StarData : SceneAssetData {
    [SerializeField]
    private StarType classType;
    [SerializeField]
    private SerializedColor mainColor;
    [SerializeField]
    private SerializedColor coronaColor;
    [SerializeField]
    private SerializedColor edgeColor;
    //[SerializeField]
    //private Material starMaterial;

    public StarType ClassType {
        get {
            return classType;
        }

        set {
            classType = value;
        }
    }

    public SerializedColor MainColor {
        get {
            return mainColor;
        }

        set {
            mainColor = value;
        }
    }

    public SerializedColor CoronaColor {
        get {
            return coronaColor;
        }

        set {
            coronaColor = value;
        }
    }

    public SerializedColor EdgeColor {
        get {
            return edgeColor;
        }

        set {
            edgeColor = value;
        }
    }

    //public Material StarMaterial {
    //    get {
    //        return starMaterial;
    //    }

    //    set {
    //        starMaterial = value;
    //    }
    //}
}