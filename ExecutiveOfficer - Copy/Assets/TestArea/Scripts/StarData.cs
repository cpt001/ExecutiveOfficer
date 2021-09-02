using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StarData : CelestialBodyData {
    [SerializeField]
    private StarType classType;
    [SerializeField]
    private Color mainColor;
    [SerializeField]
    private Color coronaColor;
    [SerializeField]
    private Color edgeColor;

    public StarType ClassType {
        get {
            return classType;
        }

        set {
            classType = value;
        }
    }

    public Color MainColor {
        get {
            return mainColor;
        }

        set {
            mainColor = value;
        }
    }

    public Color CoronaColor {
        get {
            return coronaColor;
        }

        set {
            coronaColor = value;
        }
    }

    public Color EdgeColor {
        get {
            return edgeColor;
        }

        set {
            edgeColor = value;
        }
    }
}