using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyDebugger : MonoBehaviour {
    [SerializeField]
    private GameObject galaxyObj = null;
    [SerializeField]
    private int systemConnectionCount = 0;
    private List<StarSystem> starSystems = new List<StarSystem>();

    private void GetStarSystems() {
        starSystems.AddRange(galaxyObj.GetComponentsInChildren<StarSystem>());
    }

    public void DebugGalaxyInfo() {
        GetStarSystems();
        //GenerateAllSystemConnections();
        //print("Minimum star system distance: " + GetMinimumDistanceOfStarSystems() + "!");
        //print("Maximum star system distance: " + GetMaximumDistanceOfStarSystems() + "!");
        //print("Average star system distance: " + GetAverageDistanceOfStarSystems() + "!");
    }

    //private float GetMinimumStarSystemDistance() {
    //    float minDist = float.MaxValue;
    //    float tmpDist = 0.0f;
    //    for (int i = 0; i < starSystems.Count; i++) {
    //        for (int x = 0; x < starSystems.Count; x++) {
    //            if (starSystems[x] == starSystems[i]) {
    //                continue;
    //            }
    //            tmpDist = Vector3.Distance(starSystems[i].transform.position, starSystems[x].transform.position);
    //            if (tmpDist < minDist) {
    //                minDist = tmpDist;
    //            }
    //        }
    //    }
    //    return minDist;
    //}

    //private float GetMaximumStarSystemDistance() {
    //    float maxDist = 0.0f;
    //    float tmpDist = 0.0f;
    //    for (int i = 0; i < starSystems.Count; i++) {
    //        for (int x = 0; x < starSystems.Count; x++) {
    //            if (starSystems[x] == starSystems[i]) {
    //                continue;
    //            }
    //            tmpDist = Vector3.Distance(starSystems[i].transform.position, starSystems[x].transform.position);
    //            if (tmpDist > maxDist) {
    //                maxDist = tmpDist;
    //            }
    //        }
    //    }
    //    return maxDist;
    //}

    //private float GetAverageStarSystemDistance() {
    //    float totalDist = 0.0f;
    //    for (int i = 0; i < starSystems.Count; i++) {
    //        for (int x = 0; x < starSystems.Count; x++) {
    //            if (starSystems[x] == starSystems[i]) {
    //                continue;
    //            }
    //            totalDist += Vector3.Distance(starSystems[i].transform.position, starSystems[x].transform.position);
    //        }
    //    }
    //    return totalDist / starSystems.Count;
    //}

    private float GetMinimumDistanceOfStarSystems() {
        float minDist = float.MaxValue;
        float tmpDist = 0.0f;
        for (int i = 0; i < starSystems.Count; i++) {
            tmpDist = GetDistanceOfClosestStarSystem(starSystems[i]);
            if (tmpDist < minDist) {
                minDist = tmpDist;
            }
        }
        return minDist;
    }

    private float GetMaximumDistanceOfStarSystems() {
        float maxDist = 0.0f;
        float tmpDist = 0.0f;
        for (int i = 0; i < starSystems.Count; i++) {
            tmpDist = GetDistanceOfClosestStarSystem(starSystems[i]);
            if (tmpDist > maxDist) {
                maxDist = tmpDist;
            }
        }
        return maxDist;
    }

    private float GetAverageDistanceOfStarSystems() {
        float totalDist = 0.0f;
        for (int i = 0; i < starSystems.Count; i++) {
            totalDist += GetDistanceOfClosestStarSystem(starSystems[i]);
        }
        return totalDist / starSystems.Count;
    }

    private float GetDistanceOfClosestStarSystem(StarSystem system) {
        float minDist = float.MaxValue;
        float tmpDist = 0.0f;
        for (int i = 0; i < starSystems.Count; i++) {
            if (starSystems[i] == system) {
                continue;
            }
            tmpDist = Vector3.Distance(starSystems[i].transform.position, system.transform.position);
            if (tmpDist < minDist) {
                minDist = tmpDist;
            }
        }
        return minDist;
    }

    private List<StarSystem> GetClosestStarSystems(StarSystem system, int systemCount) {
        float tmpDist = 0.0f;
        List<KeyValuePair<StarSystem, float>> systemDistancePairs = new List<KeyValuePair<StarSystem, float>>();
        for (int i = 0; i < systemCount; i++) {
            systemDistancePairs.Add(new KeyValuePair<StarSystem, float>(null, float.MaxValue));
        }
        for (int x = 0; x < starSystems.Count; x++) {
            if (starSystems[x] == system) {
                continue;
            }
            tmpDist = Vector3.Distance(system.transform.position, starSystems[x].transform.position);
            for (int y = 0; y < systemDistancePairs.Count; y++) {
                if (tmpDist < systemDistancePairs[y].Value) {
                    int insertionIndex = y;
                    for (int z = systemDistancePairs.Count - 1; z > - 1 ; z--) {
                        if (z == insertionIndex) {
                            systemDistancePairs[z] = new KeyValuePair<StarSystem, float>(starSystems[x], tmpDist);
                            break;
                        }
                        systemDistancePairs[z] = new KeyValuePair<StarSystem, float>(systemDistancePairs[z - 1].Key, systemDistancePairs[z - 1].Value);
                    }
                }
            }
        }
        List<StarSystem> systems = new List<StarSystem>();
        for (int n = 0; n < systemDistancePairs.Count; n++) {
            if (systemDistancePairs[n].Key != null) {
                systems.Add(systemDistancePairs[n].Key);
            }
        }
        return systems;
    }

    void GenerateAllSystemConnections() {
        for (int i = 0; i < starSystems.Count; i++) {
            GenerateSystemConnections(starSystems[i]);
        }
    }

    void GenerateSystemConnections(StarSystem starSystem) {
        
    }

    void DrawSystemConnections() {

    }
}