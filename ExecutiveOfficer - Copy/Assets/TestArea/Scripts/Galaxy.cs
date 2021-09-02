using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Galaxy : MonoBehaviour {
    [SerializeField]
    private GalaxyData data;

    public GalaxyData Data {
        get {
            return data;
        }

        set {
            data = value;
        }
    }
}