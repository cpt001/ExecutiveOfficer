using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    [SerializeField]
    private PlanetData data = null;

    public PlanetData Data {
        get {
            return data;
        }

        set {
            data = value;
        }
    }
}