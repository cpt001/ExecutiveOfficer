using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StarSystem : MonoBehaviour {
    [SerializeField]
    private StarSystemData systemData;

    public StarSystemData SystemData {
        get {
            return systemData;
        }

        set {
            systemData = value;
        }
    }
}