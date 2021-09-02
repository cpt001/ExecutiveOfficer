using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxySector : MonoBehaviour {
    [SerializeField]
    private int sectorIndex = 0;
    [SerializeField]
    private int galaxyArmIndex = 0;
    [SerializeField]
    private Bounds sectorBounds;

    public int SectorIndex {
        get {
            return sectorIndex;
        }

        set {
            sectorIndex = value;
        }
    }

    public int GalaxyArmIndex {
        get {
            return galaxyArmIndex;
        }

        set {
            galaxyArmIndex = value;
        }
    }

    public Bounds SectorBounds {
        get {
            return sectorBounds;
        }

        set {
            sectorBounds = value;
        }
    }
}