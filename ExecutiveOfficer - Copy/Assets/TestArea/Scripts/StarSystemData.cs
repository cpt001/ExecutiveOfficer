using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StarSystemData {
    [SerializeField]
    private List<StarData> starDatas = new List<StarData>();
    [SerializeField]
    private List<CelestialBodyData> bodyDatas = new List<CelestialBodyData>();
    [SerializeField]
    private List<StarSystem> connectedStarSystems = new List<StarSystem>();
    [SerializeField]
    private float maximumConnectionDistance = 0.0f;

    public List<StarData> StarDatas {
        get {
            return starDatas;
        }

        set {
            starDatas = value;
        }
    }

    public List<CelestialBodyData> BodyDatas {
        get {
            return bodyDatas;
        }

        set {
            bodyDatas = value;
        }
    }

    public List<StarSystem> ConnectedStarSystems {
        get {
            return connectedStarSystems;
        }

        set {
            connectedStarSystems = value;
        }
    }

    public float MaximumConnectionDistance {
        get {
            return maximumConnectionDistance;
        }

        set {
            maximumConnectionDistance = value;
        }
    }
}