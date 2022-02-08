using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidBodyData : CelestialBodyData {
    [SerializeField]
    private SolidBodyType bodyType;

    public SolidBodyType BodyType {
        get {
            return bodyType;
        }

        set {
            bodyType = value;
        }
    }
}