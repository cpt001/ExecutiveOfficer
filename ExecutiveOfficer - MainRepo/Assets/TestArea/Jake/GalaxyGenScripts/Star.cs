using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    [SerializeField]
    private StarData data = null;

    public StarData Data {
        get {
            return data;
        }

        set {
            data = value;
        }
    }
}