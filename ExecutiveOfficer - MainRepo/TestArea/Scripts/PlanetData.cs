using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetData : SceneAssetData {
    [SerializeField]
    private PlanetType bodyType;

    public PlanetType BodyType {
        get {
            return bodyType;
        }

        set {
            bodyType = value;
        }
    }
}