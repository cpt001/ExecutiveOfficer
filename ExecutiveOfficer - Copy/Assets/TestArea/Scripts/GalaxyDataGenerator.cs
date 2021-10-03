using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyDataGenerator : MonoBehaviour {
    [Header("Galaxy Generation")]
    //private List<StarSystem> starSystems = new List<StarSystem>();
    private Galaxy galaxyInstance = null;
    [SerializeField]
    private int desiredSystemCount = 0;
    private float maxConnectionDistance = 0.0f;
    //[SerializeField]
    //private int systemConnections = 0;
    //[SerializeField]
    //private int armSegregationSectorCutoff = 0;
    [Header("Star System Generation")]
    [SerializeField]
    private int systemBodyCountMin = 0;
    [SerializeField]
    private int systemBodyCountMax = 0;
    [SerializeField]
    private float systemSceneSize = 0.0f;
    [Header("Solid Body Size Limits")]
    [SerializeField]
    private float beanSizeMin = 0.0f;
    [SerializeField]
    private float beanSizeMax = 0.0f;
    [SerializeField]
    private float cyclopsSizeMin = 0.0f;
    [SerializeField]
    private float cyclopsSizeMax = 0.0f;
    [SerializeField]
    private float earthSizeMin = 0.0f;
    [SerializeField]
    private float earthSizeMax = 0.0f;
    [SerializeField]
    private float eyeSizeMin = 0.0f;
    [SerializeField]
    private float eyeSizeMax = 0.0f;
    [SerializeField]
    private float fierySizeMin = 0.0f;
    [SerializeField]
    private float fierySizeMax = 0.0f;
    [SerializeField]
    private float icySizeMin = 0.0f;
    [SerializeField]
    private float icySizeMax = 0.0f;
    [SerializeField]
    private float moonSizeMin = 0.0f;
    [SerializeField]
    private float moonSizeMax = 0.0f;


    private void Awake() {
        Init();
    }

    private void Init() {
        galaxyInstance = GetComponent<Galaxy>();
    }

    #region Galaxy Initialization Functions
    private void ReduceGalaxySize(GalaxyData galaxy, int desiredSize) {
        List<StarSystem> systemsToRemove = new List<StarSystem>();
        int numOfSystemsToRemove = galaxy.StarSystems.Count - desiredSize;
        StarSystem tmpSystem;
        //print("Galaxy size: " + galaxy.StarSystems.Count + "!");
        //print("Removal size: " + numOfSystemsToRemove + "!");
        while (numOfSystemsToRemove > 0) {
            for (int i = 0; i < galaxy.StarSystems.Count; i++) {
                if (galaxy.StarSystems[i] != null && !systemsToRemove.Contains(galaxy.StarSystems[i])) {
                    tmpSystem = GetClosestStarSystem(galaxy.StarSystems[i], galaxy.StarSystems);
                    if (!systemsToRemove.Contains(tmpSystem)) {
                        systemsToRemove.Add(tmpSystem);
                    }
                }
            }
            //print("SystemsToRemove: " + systemsToRemove.Count + "!");
            for (int x = 0; x < systemsToRemove.Count; x++) {
                if (numOfSystemsToRemove == 0) {
                    break;
                }
                galaxy.StarSystems.Remove(systemsToRemove[x]);
                Destroy(systemsToRemove[x].gameObject);
                numOfSystemsToRemove--;
            }
            systemsToRemove.Clear();
            //print("Removal size: " + numOfSystemsToRemove + "!");
            //print("Galaxy size: " + galaxy.StarSystems.Count + "!");
        }
        //print("Galaxy size: " + galaxy.StarSystems.Count + "!");
    }

    private void RemoveGalaxyGenerationComponents() {
        List<Type> componentsToRemove = new List<Type> { typeof(GalaxyGenerator), typeof(GenerationController), typeof(ParticleSystem), typeof(GalacticMapGenerator) };
        Component[] comps = GetComponentsInChildren<Component>();
        for (int i = 0; i < comps.Length; i++) {
            if (componentsToRemove.Contains(comps[i].GetType())) {
                Destroy(comps[i]);
            }
        }
    }

    private List<StarSystem> GetStarSystemObjects() {
        List<StarSystem> tmpSystems = new List<StarSystem>();
        tmpSystems.AddRange(GetComponentsInChildren<StarSystem>());
        return tmpSystems;
    }
    #endregion

    #region Data Generation Functions
    public void GenerateGalaxyData() {
        StartCoroutine(GenerateGalaxyDataCoroutine());
    }

    private IEnumerator GenerateGalaxyDataCoroutine() {
        GalaxyData tmpGalaxyData = new GalaxyData();
        RemoveGalaxyGenerationComponents();
        //GenerateSectorBounds();
        tmpGalaxyData.StarSystems = GetStarSystemObjects();
        ReduceGalaxySize(tmpGalaxyData, desiredSystemCount);
        yield return new WaitForSeconds(0);
        for (int i = 0; i < tmpGalaxyData.StarSystems.Count; i++) {
            tmpGalaxyData.StarSystems[i].SystemData = GenerateStarSystemData(tmpGalaxyData.StarSystems[i], tmpGalaxyData.StarSystems);
        }
        GenerateStarSystemConnections(tmpGalaxyData.StarSystems);
        galaxyInstance.Data = tmpGalaxyData;
        DrawSystemConnections(galaxyInstance.Data.StarSystems);
        DebugSystemConnections();
        yield return null;
    }

    private StarSystemData GenerateStarSystemData(StarSystem system, List<StarSystem> allSystems) {
        StarSystemData tmpSystemData = new StarSystemData();
        //randomize star system data;
        tmpSystemData.StarDatas.Add(GenerateStarData());
        //tmpSystemData.ConnectedStarSystems = GenerateSystemConnections(system, allSystems);
        //GenerateStarSystemConnections();
        system.GetComponent<MeshRenderer>().material.color = tmpSystemData.StarDatas[0].MainColor;
        return tmpSystemData;
    }

    private StarData GenerateStarData() {
        StarData tmpStarData = new StarData();
        tmpStarData.ClassType = (StarType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(StarType)).Length);
        switch (tmpStarData.ClassType) {
            case StarType.ClassO:
            //UV
            tmpStarData.MainColor = new Color(12.55f, 8.63f, 35.69f);
            break;
            case StarType.ClassB:
            //Blue luminous
            tmpStarData.MainColor = new Color(0.0f, 87.5f, 100.0f);
            break;
            case StarType.ClassA:
            //White/blue-white
            tmpStarData.MainColor = new Color(80.0f, 97.3f, 100.0f);
            break;
            case StarType.ClassG:
            //Yellow
            tmpStarData.MainColor = Color.yellow;
            break;
            case StarType.ClassK:
            //Orange
            tmpStarData.MainColor = new Color(100.0f, 76.1f, 7.8f);
            break;
            case StarType.ClassM:
            //Red
            tmpStarData.MainColor = Color.red;
            break;
            case StarType.ClassL:
            //Brown
            tmpStarData.MainColor = new Color(69.8f, 22.7f, 0.0f);
            break;
            case StarType.ClassC:
            //Carbon (dark brown)
            tmpStarData.MainColor = new Color(34.1f, 11.0f, 0.0f);
            break;
            case StarType.Neutron:
            //Dark blue
            tmpStarData.MainColor = Color.blue;
            break;
        }
        return tmpStarData;
    }

    int GenerateSystemBodyCount() {
        return UnityEngine.Random.Range(systemBodyCountMin, systemBodyCountMax);

    }

    void GenerateSystemBodies() {
        int bodyCount = GenerateSystemBodyCount();
        for (int i = 0; i < bodyCount; i++) {
            GenerateSystemBody();
        }
    }

    void GenerateSystemBody() {
        SolidBodyType bodyType = GenerateSolidBodyType();
    }

    SolidBodyType GenerateSolidBodyType() {
        int typeIndex = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(SolidBodyType)).Length);
        return (SolidBodyType)typeIndex;
    }

    float GenerateBodySize(SolidBodyType bodyType) {
        float bodySize = 0.0f;
        switch (bodyType) {
            case SolidBodyType.BEAN:
            bodySize = UnityEngine.Random.Range(beanSizeMin, beanSizeMax);
            break;
            case SolidBodyType.CYCLOPS:
            bodySize = UnityEngine.Random.Range(cyclopsSizeMin, cyclopsSizeMax);
            break;
            case SolidBodyType.EARTH:
            bodySize = UnityEngine.Random.Range(earthSizeMin, earthSizeMax);
            break;
            case SolidBodyType.EYE:
            bodySize = UnityEngine.Random.Range(eyeSizeMin, eyeSizeMax);
            break;
            case SolidBodyType.FIERY:
            bodySize = UnityEngine.Random.Range(fierySizeMin, fierySizeMax);
            break;
            case SolidBodyType.ICY:
            bodySize = UnityEngine.Random.Range(icySizeMin, icySizeMax);
            break;
            case SolidBodyType.MOON:
            bodySize = UnityEngine.Random.Range(moonSizeMin, moonSizeMax);
            break;
        }
        return bodySize;
    }

    Vector3 GenerateScenePosition() {
        Vector3 scenePos = Vector3.zero;
        //validate pos
        return scenePos;
    }

    //private bool IsScenePositionValid() {

    //}
    #endregion

    #region System Connection Functions
    void GenerateStarSystemConnections(List<StarSystem> allSystems) {
        List<StarSystem> sortedSystems = SortStarSystemsByDistanceFromCenter(allSystems);
        GenerateCenterConnections(sortedSystems);
        GenerateBasicConnections(sortedSystems);
        GenerateRemainingConnections(sortedSystems);
    }

    private List<StarSystem> SortStarSystemsByDistanceFromCenter(List<StarSystem> allSystems) {
        List<StarSystem> tmpSystems = allSystems;
        tmpSystems.OrderBy(x => (x.transform.position - galaxyInstance.transform.position).sqrMagnitude);
        return tmpSystems;
    }

    private StarSystem GetClosestStarSystem(StarSystem system, List<StarSystem> allSystems) {
        StarSystem tmpSystem = null;
        float minDist = float.MaxValue;
        float tmpDist = 0.0f;
        for (int i = 0; i < allSystems.Count; i++) {
            if (allSystems[i] == system) {
                continue;
            }
            tmpDist = Vector3.Distance(allSystems[i].transform.position, system.transform.position);
            if (tmpDist < minDist) {
                minDist = tmpDist;
                tmpSystem = allSystems[i];
            }
        }
        return tmpSystem;
    }

    private void GenerateCenterConnections(List<StarSystem> sortedSystems) {
        List<int> connectedIndices = new List<int>();
        GalaxySector tmpSector;
        //0 index is center system
        for (int i = 1; i < sortedSystems.Count; i++) {
            tmpSector = sortedSystems[i].GetComponentInParent<GalaxySector>();
            if (!connectedIndices.Contains(tmpSector.GalaxyArmIndex)) {
                CalculateMaxConnectionDistance(sortedSystems[0], sortedSystems[i]);
                sortedSystems[0].SystemData.ConnectedStarSystems.Add(sortedSystems[i]);
                connectedIndices.Add(tmpSector.GalaxyArmIndex);
            }
            if (connectedIndices.Count == galaxyInstance.Data.ArmCount) {
                return;
            }
        }
    }

    private void GenerateBasicConnections(List<StarSystem> sortedSystems) {
        for (int i = 1; i < sortedSystems.Count; i++) {
            GenerateCloserConnection(sortedSystems, i);
            GenerateFartherConnection(sortedSystems, i);
        }
    }

    ////used with a per system maximum range
    //private void GenerateRemainingConnections(List<StarSystem> sortedSystems) {
    //    for (int i = 0; i < sortedSystems.Count; i++) {
    //        CalculateMaxConnectionDistance(sortedSystems[i]);
    //        GenerateConnectionsInRange(sortedSystems[i]);
    //    }
    //}

    //used with a gloabl maximum range
    private void GenerateRemainingConnections(List<StarSystem> sortedSystems) {
        ConvertMaxConnectionDistance();
        for (int i = 0; i < sortedSystems.Count; i++) {
            GenerateConnectionsInRange(sortedSystems[i], maxConnectionDistance, sortedSystems);
        }
    }

    private void GenerateCloserConnection(List<StarSystem> sortedSystems, int systemIndex) {
        for (int i = systemIndex - 1; i > -1; i--) {
            if (IsViableSystemConnection(sortedSystems[systemIndex], sortedSystems[i], sortedSystems)) {
                CalculateMaxConnectionDistance(sortedSystems[systemIndex], sortedSystems[i]);
                sortedSystems[systemIndex].SystemData.ConnectedStarSystems.Add(sortedSystems[i]);
                return;
            }
        }
    }

    private void GenerateFartherConnection(List<StarSystem> sortedSystems, int systemIndex) {
        for (int i = systemIndex + 1; i < sortedSystems.Count; i++) {
            if (IsViableSystemConnection(sortedSystems[systemIndex], sortedSystems[i], sortedSystems)) {
                CalculateMaxConnectionDistance(sortedSystems[systemIndex], sortedSystems[i]);
                sortedSystems[systemIndex].SystemData.ConnectedStarSystems.Add(sortedSystems[i]);
                return;
            }
        }
    }

    ////used with a per system maximum range
    //private void GenerateConnectionsInRange(StarSystem system) {
    //    List<Collider> hitColliders = new List<Collider>();
    //    List<StarSystem> systemsInRange = new List<StarSystem>();
    //    StarSystem tmpSystem;
    //    hitColliders.AddRange(Physics.OverlapSphere(system.transform.position, system.SystemData.MaximumConnectionDistance));
    //    for (int i = 0; i < hitColliders.Count; i++) {
    //        tmpSystem = hitColliders[i].GetComponent<StarSystem>();
    //        if (tmpSystem != null && tmpSystem != system && !system.SystemData.ConnectedStarSystems.Contains(tmpSystem)) {
    //            system.SystemData.ConnectedStarSystems.Add(tmpSystem);
    //        }
    //    }
    //}

    //used with a global maximum range
    private void GenerateConnectionsInRange(StarSystem system, float range, List<StarSystem> sortedSystems) {
        List<Collider> hitColliders = new List<Collider>();
        List<StarSystem> systemsInRange = new List<StarSystem>();
        StarSystem tmpSystem;
        hitColliders.AddRange(Physics.OverlapSphere(system.transform.position, range));
        for (int i = 0; i < hitColliders.Count; i++) {
            tmpSystem = hitColliders[i].GetComponent<StarSystem>();
            if (tmpSystem != null && !system.SystemData.ConnectedStarSystems.Contains(tmpSystem) && IsViableSystemConnection(system, tmpSystem, sortedSystems)) {
                system.SystemData.ConnectedStarSystems.Add(tmpSystem);
            }
        }
    }

    ////used on a system by system basis
    //private float CalculateMaxConnectionDistance(StarSystem system) {
    //    float maxRange = 0.0f;
    //    float tmpRange = 0.0f;
    //    for (int i = 0; i < system.SystemData.ConnectedStarSystems.Count; i++) {
    //        tmpRange = (system.SystemData.ConnectedStarSystems[i].transform.position - system.transform.position).sqrMagnitude;
    //        if (tmpRange > maxRange) {
    //            maxRange = tmpRange;
    //        }
    //    }
    //    return Mathf.Sqrt(maxRange);
    //}

    //used for a single comprehensive max distance
    private void CalculateMaxConnectionDistance(StarSystem systema, StarSystem systemb) {
        float tmpdist = (systemb.transform.position - systema.transform.position).sqrMagnitude;
        if (tmpdist > maxConnectionDistance) {
            maxConnectionDistance = tmpdist;
        }
    }

    //used for a single comprehensive max distance
    private void ConvertMaxConnectionDistance() {
        maxConnectionDistance = Mathf.Sqrt(maxConnectionDistance);
    }

    //private List<StarSystem> GetClosestStarSystems(StarSystem system, int systemCount, List<StarSystem> allSystems) {
    //    float tmpDist = 0.0f;
    //    List<KeyValuePair<StarSystem, float>> systemDistancePairs = new List<KeyValuePair<StarSystem, float>>();
    //    for (int i = 0; i < systemCount; i++) {
    //        systemDistancePairs.Add(new KeyValuePair<StarSystem, float>(null, float.MaxValue));
    //    }
    //    for (int x = 0; x < allSystems.Count; x++) {
    //        if (allSystems[x] == system || !IsViableSystemConnection(system, allSystems[x])) {
    //            continue;
    //        }
    //        tmpDist = Vector3.Distance(system.transform.position, allSystems[x].transform.position);
    //        for (int y = 0; y < systemDistancePairs.Count; y++) {
    //            if (tmpDist < systemDistancePairs[y].Value && !SystemDistancePairListContainsSystem(systemDistancePairs, allSystems[x])) {
    //                int insertionIndex = y;
    //                for (int z = systemDistancePairs.Count - 1; z > -1; z--) {
    //                    if (z == insertionIndex) {
    //                        systemDistancePairs[z] = new KeyValuePair<StarSystem, float>(allSystems[x], tmpDist);
    //                        break;
    //                    }
    //                    systemDistancePairs[z] = new KeyValuePair<StarSystem, float>(systemDistancePairs[z - 1].Key, systemDistancePairs[z - 1].Value);
    //                }
    //            }
    //        }
    //    }
    //    List<StarSystem> systems = new List<StarSystem>();
    //    for (int n = 0; n < systemDistancePairs.Count; n++) {
    //        if (systemDistancePairs[n].Key != null) {
    //            systems.Add(systemDistancePairs[n].Key);
    //        }
    //    }
    //    return systems;
    //}

    private bool IsViableSystemConnection(StarSystem currentSystem, StarSystem connectionSystem, List<StarSystem> sortedSystems) {
        GalaxySector currentSector = currentSystem.GetComponentInParent<GalaxySector>();
        GalaxySector connectionSector = connectionSystem.GetComponentInParent<GalaxySector>();
        //GalaxySector centerSector = sortedSystems[0].GetComponentInParent<GalaxySector>();
        //if (connectionsector.galaxyarmindex == currentsector.galaxyarmindex || connectionsystem == sortedsystems[0]) {
        //    return true;
        //}
        if (sortedSystems[0].SystemData.ConnectedStarSystems.Contains(currentSystem)) {
            //if (connectionSector.SectorIndex == currentSector.SectorIndex || IsSectorOverlapping(currentSector, connectionSector) || connectionSector.GalaxyArmIndex == currentSector.GalaxyArmIndex || connectionSector.GalaxyArmIndex == 0) {
            //    return true;
            //}
            if (connectionSystem == sortedSystems[0]) {
                return true;
            }
        }
        if (connectionSector.GalaxyArmIndex == currentSector.GalaxyArmIndex) {
            return true;
        }
        //if (connectionSector.SectorIndex == currentSector.SectorIndex || IsSectorOverlapping(currentSector, connectionSector) || connectionSector.GalaxyArmIndex == currentSector.GalaxyArmIndex) {
        //    return true;
        //}
        return false;
    }

    //private void GenerateSectorBounds() {
    //    //Bounds tmpBounds = new Bounds();
    //    List<Renderer> tmpRenderers = new List<Renderer>();
    //    List<GalaxySector> tmpSectors = new List<GalaxySector>();
    //    tmpSectors.AddRange(GetComponentsInChildren<GalaxySector>());
    //    for (int i = 0; i < tmpSectors.Count; i++) {
    //        //calculate and assign bounds
    //        tmpRenderers.AddRange(tmpSectors[i].GetComponentsInChildren<Renderer>());
    //        Bounds tmpBounds = tmpRenderers[0].bounds;
    //        for (int x = 0; x < tmpRenderers.Count; x++) {
    //            tmpBounds.Encapsulate(tmpRenderers[x].bounds);
    //        }
    //        tmpSectors[i].SectorBounds = tmpBounds;
    //        tmpRenderers.Clear();
    //    }
    //}

    //private bool IsSectorOverlapping(GalaxySector currentSector, GalaxySector connectionSector) {
    //    if (currentSector.SectorBounds.Intersects(connectionSector.SectorBounds)) {
    //        return true;
    //    }
    //    return false;
    //}

    private bool SystemDistancePairListContainsSystem(List<KeyValuePair<StarSystem, float>> systemPairList, StarSystem system) {
        for (int i = 0; i < systemPairList.Count; i++) {
            if (systemPairList[i].Key == system) {
                return true;
            }
        }
        return false;
    }

    //void GenerateAllSystemConnections() {
    //    for (int i = 0; i < galaxyInstance.Data.StarSystemDatas.Count; i++) {
    //        GenerateSystemConnections(galaxyInstance.Data.StarSystemDatas[i]);
    //    }
    //}

    //List<StarSystem> GenerateSystemConnections(StarSystem starSystem, List<StarSystem> allSystems) {
    //    return GetClosestStarSystems(starSystem, systemConnections, allSystems);
    //}
    #endregion

    #region Draw/Debug Functions
    void DrawSystemConnections(List<StarSystem> allSystems) {
        for (int i = 0; i < allSystems.Count; i++) {
            LineRenderer lr = allSystems[i].gameObject.AddComponent<LineRenderer>();
            lr.startWidth = 0.5f;
            lr.endWidth = 0.5f;
            lr.positionCount = allSystems[i].SystemData.ConnectedStarSystems.Count * 2;
            for (int y = 0; y < lr.positionCount; y++) {
                if (y % 2 == 0) {
                    //print("index is even, setting position as main system: " + allSystems[i].transform.position + "!");
                    lr.SetPosition(y, allSystems[i].transform.position);
                    continue;
                }
                //print("index is odd, setting position as connected system: " + allSystems[i].SystemData.ConnectedStarSystems[y / 2].transform.position + "!");
                lr.SetPosition(y, allSystems[i].SystemData.ConnectedStarSystems[y / 2].transform.position);
            }
        }
    }

    void OnDrawGizmos() {
        DebugSectorBounds();
    }

    void DebugSectorBounds() {
        List<GalaxySector> tmpSectors = new List<GalaxySector>();
        tmpSectors.AddRange(GetComponentsInChildren<GalaxySector>());
        for (int i = 0; i < tmpSectors.Count; i++) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(tmpSectors[i].SectorBounds.center, tmpSectors[i].SectorBounds.size);
        }
    }

    void DebugSystemConnections() {
        for (int i = 0; i < galaxyInstance.Data.StarSystems.Count; i++) {
            print("Star system: " + i + " has " + galaxyInstance.Data.StarSystems[i].SystemData.ConnectedStarSystems.Count + " connections!");
        }
    }
    #endregion
}