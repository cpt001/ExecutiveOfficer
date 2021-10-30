using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneAsset : MonoBehaviour {
    [SerializeField]
    private SceneAssetData transformData = null;

    public SceneAssetData TransformData {
        get {
            return transformData;
        }

        set {
            transformData = value;
        }
    }
}