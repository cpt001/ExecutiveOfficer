using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GalaxyData {
    private float armCount = 0;
    [SerializeField]
    private List<StarSystem> starSystems = new List<StarSystem>();

    public float ArmCount {
        get {
            return armCount;
        }

        set {
            armCount = value;
        }
    }

    public List<StarSystem> StarSystems {
        get {
            return starSystems;
        }

        set {
            starSystems = value;
        }
    }
}