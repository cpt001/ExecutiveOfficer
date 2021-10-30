using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEditor;

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
    private int planetCountMin = 0;
    [SerializeField]
    private int planetCountMax = 0;
    [SerializeField]
    private float systemSceneSize = 0.0f;
    [SerializeField]
    private float angularVelocityMin = 0.0f;
    [SerializeField]
    private float angularVelocityMax = 0.0f;

    [Header("Star Generation")]
    [SerializeField]
    private Material starMaterial = null;
    [SerializeField]
    private float maxColorShiftPercentage = 0.0f;

    //Star Type Values
    [SerializeField]
    //UV
    private Color classOMainColor;
    [SerializeField]
    private Color classOCoronaColor;
    [SerializeField]
    private Color classOEdgeColor;
    [SerializeField]
    private float classOMinSize = 0.0f;
    [SerializeField]
    private float classOMaxSize = 0.0f;
    [SerializeField]
    //Blue luminous
    private Color classBMainColor;
    [SerializeField]
    private Color classBCoronaColor;
    [SerializeField]
    private Color classBEdgeColor;
    [SerializeField]
    private float classBMinSize = 0.0f;
    [SerializeField]
    private float classBMaxSize = 0.0f;
    [SerializeField]
    //White/blue-white
    private Color classAMainColor;
    [SerializeField]
    private Color classACoronaColor;
    [SerializeField]
    private Color classAEdgeColor;
    [SerializeField]
    private float classAMinSize = 0.0f;
    [SerializeField]
    private float classAMaxSize = 0.0f;
    [SerializeField]
    //Yellow
    private Color classGMainColor;
    [SerializeField]
    private Color classGCoronaColor;
    [SerializeField]
    private Color classGEdgeColor;
    [SerializeField]
    private float classGMinSize = 0.0f;
    [SerializeField]
    private float classGMaxSize = 0.0f;
    [SerializeField]
    //Orange
    private Color classKMainColor;
    [SerializeField]
    private Color classKCoronaColor;
    [SerializeField]
    private Color classKEdgeColor;
    [SerializeField]
    private float classKMinSize = 0.0f;
    [SerializeField]
    private float classKMaxSize = 0.0f;
    [SerializeField]
    //Red
    private Color classMMainColor;
    [SerializeField]
    private Color classMCoronaColor;
    [SerializeField]
    private Color classMEdgeColor;
    [SerializeField]
    private float classMMinSize = 0.0f;
    [SerializeField]
    private float classMMaxSize = 0.0f;
    [SerializeField]
    //Brown
    private Color classLMainColor;
    [SerializeField]
    private Color classLCoronaColor;
    [SerializeField]
    private Color classLEdgeColor;
    [SerializeField]
    private float classLMinSize = 0.0f;
    [SerializeField]
    private float classLMaxSize = 0.0f;
    [SerializeField]
    //Carbon (Dark Brown)
    private Color classCMainColor;
    [SerializeField]
    private Color classCCoronaColor;
    [SerializeField]
    private Color classCEdgeColor;
    [SerializeField]
    private float classCMinSize = 0.0f;
    [SerializeField]
    private float classCMaxSize = 0.0f;
    [SerializeField]
    //Dark Blue
    private Color neutronMainColor;
    [SerializeField]
    private Color neutronCoronaColor;
    [SerializeField]
    private Color neutronEdgeColor;
    [SerializeField]
    private float neutronMinSize = 0.0f;
    [SerializeField]
    private float neutronMaxSize = 0.0f;

    [Header("Planet Generation")]
    //Planet Size Ranges
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

    private static int minSeedValue = -10000;
    private static int maxSeedValue = 10000;

    [Header("Bean Reference")]
    [SerializeField]
    private CelestialBodySettings beanCelestialSettings = null;
    [SerializeField]
    private MoonShape beanShapeSettings = null;
    [SerializeField]
    private MoonShading beanShadingSettings = null;
    [SerializeField]
    private OceanSettings beanOceanSettings = null;
    //[SerializeField]
    //private AtmosphereSettings beanAtmosphereSettings = null;

    [Header("Cyclops Reference")]
    [SerializeField]
    private CelestialBodySettings cyclopsCelestialSettings = null;
    [SerializeField]
    private AlienShape cyclopsShapeSettings = null;
    [SerializeField]
    private AlienShading cyclopsShadingSettings = null;
    [SerializeField]
    private OceanSettings cyclopsOceanSettings = null;
    [SerializeField]
    private AtmosphereSettings cyclopsAtmosphereSettings = null;

    [Header("Earth Reference")]
    [SerializeField]
    private CelestialBodySettings earthCelestialSettings = null;
    [SerializeField]
    private EarthShape earthShapeSettings = null;
    [SerializeField]
    private EarthShading earthShadingSettings = null;
    [SerializeField]
    private OceanSettings earthOceanSettings = null;
    [SerializeField]
    private AtmosphereSettings earthAtmosphereSettings = null;

    [Header("Eye Reference")]
    [SerializeField]
    private CelestialBodySettings eyeCelestialSettings = null;
    [SerializeField]
    private MoonShape eyeShapeSettings = null;
    [SerializeField]
    private MoonShading eyeShadingSettings = null;
    [SerializeField]
    private OceanSettings eyeOceanSettings = null;
    //[SerializeField]
    //private AtmosphereSettings eyeAtmosphereSettings = null;

    [Header("Fiery Reference")]
    [SerializeField]
    private CelestialBodySettings fieryCelestialSettings = null;
    [SerializeField]
    private MoatShape fieryShapeSettings = null;
    [SerializeField]
    private AlienShading fieryShadingSettings = null;
    [SerializeField]
    private OceanSettings fieryOceanSettings = null;
    //[SerializeField]
    //private AtmosphereSettings fieryAtmosphereSettings = null;

    [Header("Icy Reference")]
    [SerializeField]
    private CelestialBodySettings icyCelestialSettings = null;
    [SerializeField]
    private ShatteredShape icyShapeSettings = null;
    [SerializeField]
    private AlienShading icyShadingSettings = null;
    [SerializeField]
    private OceanSettings icyOceanSettings = null;
    //[SerializeField]
    //private AtmosphereSettings icyAtmosphereSettings = null;

    [Header("Moon Reference")]
    [SerializeField]
    private CelestialBodySettings moonCelestialSettings = null;
    [SerializeField]
    private MoonShape moonShapeSettings = null;
    [SerializeField]
    private MoonShading moonShadingSettings = null;
    [SerializeField]
    private OceanSettings moonOceanSettings = null;
    //[SerializeField]
    //private AtmosphereSettings moonAtmosphereSettings = null;


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
        print("Star System Count" + tmpGalaxyData.StarSystems.Count);
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
        List<SceneAssetData> sceneAssetDatas = new List<SceneAssetData>();
        for (int i = 0; i < allSystems.Count; i++) {
            sceneAssetDatas.AddRange(allSystems[i].SystemData.StarDatas);
            sceneAssetDatas.AddRange(allSystems[i].SystemData.PlanetDatas);
        }
        StarSystemData tmpSystemData = new StarSystemData();
        //randomize star system data;
        tmpSystemData.StarDatas.Add(GenerateStar(sceneAssetDatas));
        sceneAssetDatas.AddRange(tmpSystemData.StarDatas);
        //tmpSystemData.ConnectedStarSystems = GenerateSystemConnections(system, allSystems);
        //GenerateStarSystemConnections();
        system.GetComponent<MeshRenderer>().material.color = GameFunctionHelper.ConvertSerializedColorToUnityColor(tmpSystemData.StarDatas[0].MainColor);
        GenerateSystemPlanets(sceneAssetDatas);
        return tmpSystemData;
    }

    private StarData GenerateStar(List<SceneAssetData> assetDatas) {
        StarData tmpStarData = new StarData();
        tmpStarData.ClassType = GenerateStarType();
        tmpStarData = GenerateStarColors(tmpStarData);
        tmpStarData.ObjectSize = GenerateStarSize(tmpStarData.ClassType);
        tmpStarData.AngularVelocity = new SerializedVector3(GenerateBodyAngularVelocity());
        tmpStarData.ObjectPosition = new SerializedVector3(GenerateValidScenePosition(null, tmpStarData.ObjectSize));
        tmpStarData = GenerateStarAssets(tmpStarData);
        //switch (tmpStarData.ClassType) {
        //    case StarType.ClassO:
        //    //UV
        //    tmpStarData.MainColor = new Color(12.55f, 8.63f, 35.69f);
        //    break;
        //    case StarType.ClassB:
        //    //Blue luminous
        //    tmpStarData.MainColor = new Color(0.0f, 87.5f, 100.0f);
        //    break;
        //    case StarType.ClassA:
        //    //White/blue-white
        //    tmpStarData.MainColor = new Color(80.0f, 97.3f, 100.0f);
        //    break;
        //    case StarType.ClassG:
        //    //Yellow
        //    tmpStarData.MainColor = Color.yellow;
        //    break;
        //    case StarType.ClassK:
        //    //Orange
        //    tmpStarData.MainColor = new Color(100.0f, 76.1f, 7.8f);
        //    break;
        //    case StarType.ClassM:
        //    //Red
        //    tmpStarData.MainColor = Color.red;
        //    break;
        //    case StarType.ClassL:
        //    //Brown
        //    tmpStarData.MainColor = new Color(69.8f, 22.7f, 0.0f);
        //    break;
        //    case StarType.ClassC:
        //    //Carbon (dark brown)
        //    tmpStarData.MainColor = new Color(34.1f, 11.0f, 0.0f);
        //    break;
        //    case StarType.Neutron:
        //    //Dark blue
        //    tmpStarData.MainColor = Color.blue;
        //    break;
        //}
        return tmpStarData;
    }

    StarData GenerateStarAssets(StarData data) {
        //create asset path
        string starDir = "Assets/Assets/SaveData/Stars/" + ConvertEnumValueToTitleCase(data.ClassType.ToString());
        print("Star Directory: " + starDir);
        List<string> dirs = new List<string>(Directory.EnumerateDirectories(starDir));
        int assetIndex = dirs.Count;
        print("Asset Index: " + assetIndex);
        string guid = AssetDatabase.CreateFolder(starDir, assetIndex.ToString());
        print("GUID: " + guid);
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);
        print("Asset Path: " + assetPath);
        //create asset name
        string starName = ConvertEnumValueToTitleCase(data.ClassType.ToString()) + "-" + assetIndex;

        //create star material
        Material starMat = new Material(starMaterial);
        starMat.SetColor("MainColor", GameFunctionHelper.ConvertSerializedColorToUnityColor(data.MainColor));
        starMat.SetColor("CoronaColor", GameFunctionHelper.ConvertSerializedColorToUnityColor(data.CoronaColor));
        starMat.SetColor("EdgeEmphasis", GameFunctionHelper.ConvertSerializedColorToUnityColor(data.EdgeColor));
        AssetDatabase.CreateAsset(starMat, assetPath + "/Material.asset");

        data.AssetPath = assetPath;
        data.BodyName = starName;
        //save transform data as asset
        //using file stream binary method
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(assetPath + "/StarData.dat");
        bf.Serialize(file, data);
        file.Close();
        return data;
    }

    StarType GenerateStarType() {
        return (StarType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(StarType)).Length);
    }

    StarData GenerateStarColors(StarData data) {
        switch (data.ClassType) {
            case StarType.CLASS_O:
            data.MainColor = new SerializedColor(GenerateShiftedColor(classOMainColor));
            data.CoronaColor = new SerializedColor(GenerateShiftedColor(classOCoronaColor));
            data.EdgeColor = new SerializedColor(GenerateShiftedColor(classOEdgeColor));
            break;
            case StarType.CLASS_B:
            data.MainColor = new SerializedColor(GenerateShiftedColor(classBMainColor));
            data.CoronaColor = new SerializedColor(GenerateShiftedColor(classBCoronaColor));
            data.EdgeColor = new SerializedColor(GenerateShiftedColor(classBEdgeColor));
            break;
            case StarType.CLASS_A:
            data.MainColor = new SerializedColor(GenerateShiftedColor(classAMainColor));
            data.CoronaColor = new SerializedColor(GenerateShiftedColor(classACoronaColor));
            data.EdgeColor = new SerializedColor(GenerateShiftedColor(classAEdgeColor));
            break;
            case StarType.CLASS_G:
            data.MainColor = new SerializedColor(GenerateShiftedColor(classGMainColor));
            data.CoronaColor = new SerializedColor(GenerateShiftedColor(classGCoronaColor));
            data.EdgeColor = new SerializedColor(GenerateShiftedColor(classGEdgeColor));
            break;
            case StarType.CLASS_K:
            data.MainColor = new SerializedColor(GenerateShiftedColor(classKMainColor));
            data.CoronaColor = new SerializedColor(GenerateShiftedColor(classKCoronaColor));
            data.EdgeColor = new SerializedColor(GenerateShiftedColor(classKEdgeColor));
            break;
            case StarType.CLASS_M:
            data.MainColor = new SerializedColor(GenerateShiftedColor(classMMainColor));
            data.CoronaColor = new SerializedColor(GenerateShiftedColor(classMCoronaColor));
            data.EdgeColor = new SerializedColor(GenerateShiftedColor(classMEdgeColor));
            break;
            case StarType.CLASS_L:
            data.MainColor = new SerializedColor(GenerateShiftedColor(classLMainColor));
            data.CoronaColor = new SerializedColor(GenerateShiftedColor(classLCoronaColor));
            data.EdgeColor = new SerializedColor(GenerateShiftedColor(classLEdgeColor));
            break;
            case StarType.CLASS_C:
            data.MainColor = new SerializedColor(GenerateShiftedColor(classCMainColor));
            data.CoronaColor = new SerializedColor(GenerateShiftedColor(classCCoronaColor));
            data.EdgeColor = new SerializedColor(GenerateShiftedColor(classCEdgeColor));
            break;
            case StarType.NEUTRON:
            data.MainColor = new SerializedColor(GenerateShiftedColor(neutronMainColor));
            data.CoronaColor = new SerializedColor(GenerateShiftedColor(neutronCoronaColor));
            data.EdgeColor = new SerializedColor(GenerateShiftedColor(neutronEdgeColor));
            break;
            default:
            break;
        }
        return data;
    }

    private Color GenerateShiftedColor(Color starColor) {
        float colorHue;
        float colorSaturation;
        float colorBrightness;
        float colorValueMin = 0.0f;
        float colorValueMax = 1.0f;
        //Convert rgb color to hsv values
        Color.RGBToHSV(starColor, out colorHue, out colorSaturation, out colorBrightness);
        //modify color hue by percentage
        float colorModificationPercentage = UnityEngine.Random.Range(-maxColorShiftPercentage, maxColorShiftPercentage);
        colorModificationPercentage = (float)Math.Round(colorModificationPercentage, 2);
        colorHue += colorModificationPercentage;
        colorHue = Mathf.Clamp(colorHue, colorValueMin, colorValueMax);
        //convert color to rgb
        starColor = Color.HSVToRGB(colorHue, colorSaturation, colorBrightness);
        return starColor;
    }

    float GenerateStarSize(StarType type) {
        float starSize = 0.0f;
        switch (type) {
            case StarType.CLASS_O:
                starSize = UnityEngine.Random.Range(classOMinSize, classOMaxSize);
            break;
            case StarType.CLASS_B:
            starSize = UnityEngine.Random.Range(classBMinSize, classBMaxSize);
            break;
            case StarType.CLASS_A:
            starSize = UnityEngine.Random.Range(classAMinSize, classAMaxSize);
            break;
            case StarType.CLASS_G:
            starSize = UnityEngine.Random.Range(classGMinSize, classGMaxSize);
            break;
            case StarType.CLASS_K:
            starSize = UnityEngine.Random.Range(classKMinSize, classKMaxSize);
            break;
            case StarType.CLASS_M:
            starSize = UnityEngine.Random.Range(classMMinSize, classMMaxSize);
            break;
            case StarType.CLASS_L:
            starSize = UnityEngine.Random.Range(classLMinSize, classLMaxSize);
            break;
            case StarType.CLASS_C:
            starSize = UnityEngine.Random.Range(classCMinSize, classCMaxSize);
            break;
            case StarType.NEUTRON:
            starSize = UnityEngine.Random.Range(neutronMinSize, neutronMaxSize);
            break;
            default:
            break;
        }
        return starSize;
    }

    #region Planet Gen Methods
    List<PlanetData> GenerateSystemPlanets(List<SceneAssetData> assetDatas) {
        List<SceneAssetData> sceneAssetDatas = new List<SceneAssetData>();
        sceneAssetDatas.AddRange(assetDatas);
        List<PlanetData> planetDatas = new List<PlanetData>();
        PlanetData tmpPlanet = null;
        int planetCount = GeneratePlanetCount();
        for (int i = 0; i < planetCount; i++) {
            //Debug.Log("Number of scene objects: " + planetDatas.Count + "!");
            tmpPlanet = GenerateSystemPlanet(assetDatas);
            planetDatas.Add(tmpPlanet);
            sceneAssetDatas.Add(tmpPlanet);
        }
        return planetDatas;
    }

    PlanetData GenerateSystemPlanet(List<SceneAssetData> assetDatas) {
        PlanetData planetData = new PlanetData();
        planetData.BodyType = GeneratePlanetType();
        planetData.ObjectSize = GeneratePlanetSize(planetData.BodyType);
        planetData.AngularVelocity = new SerializedVector3(GenerateBodyAngularVelocity());
        planetData.ObjectPosition = new SerializedVector3(GenerateValidScenePosition(assetDatas, planetData.ObjectSize));
        planetData = GeneratePlanetAssets(planetData);
        return planetData;
        //planetDatas.Add(assetData);
    }

    int GeneratePlanetCount() {
        return UnityEngine.Random.Range(planetCountMin, planetCountMax);
    }

    int GeneratePlanetSeed() {
        return UnityEngine.Random.Range(minSeedValue, maxSeedValue);
    }

    PlanetType GeneratePlanetType() {
        int typeIndex = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PlanetType)).Length);
        return (PlanetType)typeIndex;
    }

    float GeneratePlanetSize(PlanetType bodyType) {
        float bodySize = 0.0f;
        switch (bodyType) {
            case PlanetType.BEAN:
            bodySize = UnityEngine.Random.Range(beanSizeMin, beanSizeMax);
            break;
            case PlanetType.CYCLOPS:
            bodySize = UnityEngine.Random.Range(cyclopsSizeMin, cyclopsSizeMax);
            break;
            case PlanetType.EARTH:
            bodySize = UnityEngine.Random.Range(earthSizeMin, earthSizeMax);
            break;
            case PlanetType.EYE:
            bodySize = UnityEngine.Random.Range(eyeSizeMin, eyeSizeMax);
            break;
            case PlanetType.FIERY:
            bodySize = UnityEngine.Random.Range(fierySizeMin, fierySizeMax);
            break;
            case PlanetType.ICY:
            bodySize = UnityEngine.Random.Range(icySizeMin, icySizeMax);
            break;
            case PlanetType.MOON:
            bodySize = UnityEngine.Random.Range(moonSizeMin, moonSizeMax);
            break;
        }
        return bodySize;
    }

    //creates planet files and saves to disk
    //generates asset path, name, and index
    PlanetData GeneratePlanetAssets(PlanetData objData) {
        switch (objData.BodyType) {
            case PlanetType.BEAN:
            objData = GenerateBeanData(objData);
            break;
            case PlanetType.CYCLOPS:
            objData = GenerateCyclopsData(objData);
            break;
            case PlanetType.EARTH:
            objData = GenerateEarthData(objData);
            break;
            case PlanetType.EYE:
            objData = GenerateEyeData(objData);
            break;
            case PlanetType.FIERY:
            objData = GenerateFieryData(objData);
            break;
            case PlanetType.ICY:
            objData = GenerateIcyData(objData);
            break;
            case PlanetType.MOON:
            objData = GenerateMoonData(objData);
            break;
        }
        return objData;
    }

    //generates randomized bean data and saves to disk
    PlanetData GenerateBeanData(PlanetData objData) {
        string planetDir = "/Assets/Assets/SaveData/Planets/" + ConvertEnumValueToTitleCase(objData.BodyType.ToString());
        List<string> dirs = new List<string>(Directory.EnumerateDirectories(planetDir));
        int assetIndex = dirs.Count;
        string planetName = ConvertEnumValueToTitleCase(objData.BodyType.ToString()) + "-" + assetIndex;

        //create data instance clones
        CelestialBodySettings bodySettings = beanCelestialSettings.Clone();
        OceanSettings oceanSettings = beanOceanSettings.Clone();
        MoonShape shapeSettings = beanShapeSettings.Clone();
        MoonShading shadingSettings = beanShadingSettings.Clone();

        //modify data
        shapeSettings.seed = GeneratePlanetSeed();
        bodySettings.shape = shapeSettings;
        shadingSettings.seed = GeneratePlanetSeed();
        shadingSettings.oceanSettings = oceanSettings;
        bodySettings.shading = shadingSettings;

        //save data
        string guid = AssetDatabase.CreateFolder(planetDir, assetIndex.ToString());
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);
        AssetDatabase.CreateAsset(oceanSettings, assetPath + "/Ocean.asset");
        AssetDatabase.CreateAsset(shapeSettings, assetPath + "/Shape.asset");
        AssetDatabase.CreateAsset(shadingSettings, assetPath + "/Shading.asset");
        AssetDatabase.CreateAsset(bodySettings, assetPath + "/Body.asset");
        //save transform data as asset
        //using file stream binary method
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + assetPath + "/PlanetData.dat");
        bf.Serialize(file, objData);
        file.Close();
        //AssetDatabase.CreateAsset(objData, assetPath + "/TransformData.asset");

        objData.AssetPath = assetPath;
        objData.BodyName = planetName;
        return objData;
    }

    //generates randomized cyclops data and saves to disk
    PlanetData GenerateCyclopsData(PlanetData objData) {
        string planetDir = "/Assets/Assets/SaveData/Planets/" + ConvertEnumValueToTitleCase(objData.BodyType.ToString());
        List<string> dirs = new List<string>(Directory.EnumerateDirectories(planetDir));
        int assetIndex = dirs.Count;
        string planetName = ConvertEnumValueToTitleCase(objData.BodyType.ToString()) + "-" + assetIndex;

        //create data instance clones
        CelestialBodySettings bodySettings = cyclopsCelestialSettings.Clone();
        OceanSettings oceanSettings = cyclopsOceanSettings.Clone();
        AtmosphereSettings atmosphereSettings = cyclopsAtmosphereSettings.Clone();
        AlienShape shapeSettings = cyclopsShapeSettings.Clone();
        AlienShading shadingSettings = cyclopsShadingSettings.Clone();

        //modify data
        shapeSettings.seed = GeneratePlanetSeed();
        bodySettings.shape = shapeSettings;
        shadingSettings.seed = GeneratePlanetSeed();
        shadingSettings.atmosphereSettings = atmosphereSettings;
        shadingSettings.oceanSettings = oceanSettings;
        bodySettings.shading = shadingSettings;

        //save data
        string guid = AssetDatabase.CreateFolder(planetDir, assetIndex.ToString());
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);
        AssetDatabase.CreateAsset(atmosphereSettings, assetPath + "/Atmosphere.asset");
        AssetDatabase.CreateAsset(oceanSettings, assetPath + "/Ocean.asset");
        AssetDatabase.CreateAsset(shapeSettings, assetPath + "/Shape.asset");
        AssetDatabase.CreateAsset(shadingSettings, assetPath + "/Shading.asset");
        AssetDatabase.CreateAsset(bodySettings, assetPath + "/Body.asset");
        //save transform data as asset
        //using file stream binary method
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + assetPath + "/PlanetData.dat");
        bf.Serialize(file, objData);
        file.Close();
        //AssetDatabase.CreateAsset(objData, assetPath + "/TransformData.asset");

        objData.AssetPath = assetPath;
        objData.BodyName = planetName;
        return objData;
    }

    //generates randomized earth data and saves to disk
    PlanetData GenerateEarthData(PlanetData objData) {
        string planetDir = "/Assets/Assets/SaveData/Planets/" + ConvertEnumValueToTitleCase(objData.BodyType.ToString());
        List<string> dirs = new List<string>(Directory.EnumerateDirectories(planetDir));
        int assetIndex = dirs.Count;
        string planetName = ConvertEnumValueToTitleCase(objData.BodyType.ToString()) + "-" + assetIndex;

        //create data instance clones
        CelestialBodySettings bodySettings = earthCelestialSettings.Clone();
        OceanSettings oceanSettings = earthOceanSettings.Clone();
        AtmosphereSettings atmosphereSettings = earthAtmosphereSettings.Clone();
        EarthShape shapeSettings = earthShapeSettings.Clone();
        EarthShading shadingSettings = earthShadingSettings.Clone();

        //modify data
        shapeSettings.seed = GeneratePlanetSeed();
        bodySettings.shape = shapeSettings;
        shadingSettings.seed = GeneratePlanetSeed();
        shadingSettings.atmosphereSettings = atmosphereSettings;
        shadingSettings.oceanSettings = oceanSettings;
        bodySettings.shading = shadingSettings;

        //save data
        string guid = AssetDatabase.CreateFolder(planetDir, assetIndex.ToString());
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);
        AssetDatabase.CreateAsset(atmosphereSettings, assetPath + "/Atmosphere.asset");
        AssetDatabase.CreateAsset(oceanSettings, assetPath + "/Ocean.asset");
        AssetDatabase.CreateAsset(shapeSettings, assetPath + "/Shape.asset");
        AssetDatabase.CreateAsset(shadingSettings, assetPath + "/Shading.asset");
        AssetDatabase.CreateAsset(bodySettings, assetPath + "/Body.asset");
        //save transform data as asset
        //using file stream binary method
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + assetPath + "/PlanetData.dat");
        bf.Serialize(file, objData);
        file.Close();
        //AssetDatabase.CreateAsset(objData, assetPath + "/TransformData.asset");

        objData.AssetPath = assetPath;
        objData.BodyName = planetName;
        return objData;
    }

    //generates randomized eye data and saves to disk
    PlanetData GenerateEyeData(PlanetData objData) {
        string planetDir = "/Assets/Assets/SaveData/Planets/" + ConvertEnumValueToTitleCase(objData.BodyType.ToString());
        List<string> dirs = new List<string>(Directory.EnumerateDirectories(planetDir));
        int assetIndex = dirs.Count;
        string planetName = ConvertEnumValueToTitleCase(objData.BodyType.ToString()) + "-" + assetIndex;

        //create data instance clones
        CelestialBodySettings bodySettings = eyeCelestialSettings.Clone();
        OceanSettings oceanSettings = eyeOceanSettings.Clone();
        //AtmosphereSettings atmosphereSettings = eyeAtmosphereSettings.Clone();
        MoonShape shapeSettings = eyeShapeSettings.Clone();
        MoonShading shadingSettings = eyeShadingSettings.Clone();

        //modify data
        shapeSettings.seed = GeneratePlanetSeed();
        bodySettings.shape = shapeSettings;
        shadingSettings.seed = GeneratePlanetSeed();
        //shadingSettings.atmosphereSettings = atmosphereSettings;
        shadingSettings.oceanSettings = oceanSettings;
        bodySettings.shading = shadingSettings;

        //save data
        string guid = AssetDatabase.CreateFolder(planetDir, assetIndex.ToString());
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);
        //AssetDatabase.CreateAsset(atmosphereSettings, assetPath + "/Atmosphere.asset");
        AssetDatabase.CreateAsset(oceanSettings, assetPath + "/Ocean.asset");
        AssetDatabase.CreateAsset(shapeSettings, assetPath + "/Shape.asset");
        AssetDatabase.CreateAsset(shadingSettings, assetPath + "/Shading.asset");
        AssetDatabase.CreateAsset(bodySettings, assetPath + "/Body.asset");
        //save transform data as asset
        //using file stream binary method
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + assetPath + "/PlanetData.dat");
        bf.Serialize(file, objData);
        file.Close();
        //AssetDatabase.CreateAsset(objData, assetPath + "/TransformData.asset");

        objData.AssetPath = assetPath;
        objData.BodyName = planetName;
        return objData;
    }

    //generates randomized fiery data and saves to disk
    PlanetData GenerateFieryData(PlanetData objData) {
        string planetDir = "/Assets/Assets/SaveData/Planets/" + ConvertEnumValueToTitleCase(objData.BodyType.ToString());
        List<string> dirs = new List<string>(Directory.EnumerateDirectories(planetDir));
        int assetIndex = dirs.Count;
        string planetName = ConvertEnumValueToTitleCase(objData.BodyType.ToString()) + "-" + assetIndex;

        //create data instance clones
        CelestialBodySettings bodySettings = fieryCelestialSettings.Clone();
        OceanSettings oceanSettings = fieryOceanSettings.Clone();
        //AtmosphereSettings atmosphereSettings = fieryAtmosphereSettings.Clone();
        MoatShape shapeSettings = fieryShapeSettings.Clone();
        AlienShading shadingSettings = fieryShadingSettings.Clone();

        //modify data
        shapeSettings.seed = GeneratePlanetSeed();
        bodySettings.shape = shapeSettings;
        shadingSettings.seed = GeneratePlanetSeed();
        //shadingSettings.atmosphereSettings = atmosphereSettings;
        shadingSettings.oceanSettings = oceanSettings;
        bodySettings.shading = shadingSettings;

        //save data
        string guid = AssetDatabase.CreateFolder(planetDir, assetIndex.ToString());
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);
        //AssetDatabase.CreateAsset(atmosphereSettings, assetPath + "/Atmosphere.asset");
        AssetDatabase.CreateAsset(oceanSettings, assetPath + "/Ocean.asset");
        AssetDatabase.CreateAsset(shapeSettings, assetPath + "/Shape.asset");
        AssetDatabase.CreateAsset(shadingSettings, assetPath + "/Shading.asset");
        AssetDatabase.CreateAsset(bodySettings, assetPath + "/Body.asset");
        //save transform data as asset
        //using file stream binary method
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + assetPath + "/PlanetData.dat");
        bf.Serialize(file, objData);
        file.Close();
        //AssetDatabase.CreateAsset(objData, assetPath + "/TransformData.asset");

        objData.AssetPath = assetPath;
        objData.BodyName = planetName;
        return objData;
    }

    //generates randomized fiery data and saves to disk
    PlanetData GenerateIcyData(PlanetData objData) {
        string planetDir = "/Assets/Assets/SaveData/Planets/" + ConvertEnumValueToTitleCase(objData.BodyType.ToString());
        List<string> dirs = new List<string>(Directory.EnumerateDirectories(planetDir));
        int assetIndex = dirs.Count;
        string planetName = ConvertEnumValueToTitleCase(objData.BodyType.ToString()) + "-" + assetIndex;

        //create data instance clones
        CelestialBodySettings bodySettings = icyCelestialSettings.Clone();
        OceanSettings oceanSettings = icyOceanSettings.Clone();
        //AtmosphereSettings atmosphereSettings = icyAtmosphereSettings.Clone();
        ShatteredShape shapeSettings = icyShapeSettings.Clone();
        AlienShading shadingSettings = icyShadingSettings.Clone();

        //modify data
        shapeSettings.seed = GeneratePlanetSeed();
        bodySettings.shape = shapeSettings;
        shadingSettings.seed = GeneratePlanetSeed();
        //shadingSettings.atmosphereSettings = atmosphereSettings;
        shadingSettings.oceanSettings = oceanSettings;
        bodySettings.shading = shadingSettings;

        //save data
        string guid = AssetDatabase.CreateFolder(planetDir, assetIndex.ToString());
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);
        //AssetDatabase.CreateAsset(atmosphereSettings, assetPath + "/Atmosphere.asset");
        AssetDatabase.CreateAsset(oceanSettings, assetPath + "/Ocean.asset");
        AssetDatabase.CreateAsset(shapeSettings, assetPath + "/Shape.asset");
        AssetDatabase.CreateAsset(shadingSettings, assetPath + "/Shading.asset");
        AssetDatabase.CreateAsset(bodySettings, assetPath + "/Body.asset");
        //save transform data as asset
        //using file stream binary method
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + assetPath + "/PlanetData.dat");
        bf.Serialize(file, objData);
        file.Close();
        //AssetDatabase.CreateAsset(objData, assetPath + "/TransformData.asset");

        objData.AssetPath = assetPath;
        objData.BodyName = planetName;
        return objData;
    }

    //generates randomized fiery data and saves to disk
    PlanetData GenerateMoonData(PlanetData objData) {
        string planetDir = "/Assets/Assets/SaveData/Planets/" + ConvertEnumValueToTitleCase(objData.BodyType.ToString());
        List<string> dirs = new List<string>(Directory.EnumerateDirectories(planetDir));
        int assetIndex = dirs.Count;
        string planetName = ConvertEnumValueToTitleCase(objData.BodyType.ToString()) + "-" + assetIndex;

        //create data instance clones
        CelestialBodySettings bodySettings = moonCelestialSettings.Clone();
        OceanSettings oceanSettings = moonOceanSettings.Clone();
        //AtmosphereSettings atmosphereSettings = moonAtmosphereSettings.Clone();
        MoonShape shapeSettings = moonShapeSettings.Clone();
        MoonShading shadingSettings = moonShadingSettings.Clone();

        //modify data
        shapeSettings.seed = GeneratePlanetSeed();
        bodySettings.shape = shapeSettings;
        shadingSettings.seed = GeneratePlanetSeed();
        //shadingSettings.atmosphereSettings = atmosphereSettings;
        shadingSettings.oceanSettings = oceanSettings;
        bodySettings.shading = shadingSettings;

        //save data
        string guid = AssetDatabase.CreateFolder(planetDir, assetIndex.ToString());
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);
        //AssetDatabase.CreateAsset(atmosphereSettings, assetPath + "/Atmosphere.asset");
        AssetDatabase.CreateAsset(oceanSettings, assetPath + "/Ocean.asset");
        AssetDatabase.CreateAsset(shapeSettings, assetPath + "/Shape.asset");
        AssetDatabase.CreateAsset(shadingSettings, assetPath + "/Shading.asset");
        AssetDatabase.CreateAsset(bodySettings, assetPath + "/Body.asset");
        //save transform data as asset
        //using file stream binary method
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + assetPath + "/PlanetData.dat");
        bf.Serialize(file, objData);
        file.Close();
        //AssetDatabase.CreateAsset(objData, assetPath + "/TransformData.asset");

        objData.AssetPath = assetPath;
        objData.BodyName = planetName;
        return objData;
    }
    #endregion

    Vector3 GenerateBodyAngularVelocity() {
        return new Vector3(UnityEngine.Random.Range(angularVelocityMin, angularVelocityMax), UnityEngine.Random.Range(angularVelocityMin, angularVelocityMax), UnityEngine.Random.Range(angularVelocityMin, angularVelocityMax));
    }

    Vector3 GenerateValidScenePosition(List<SceneAssetData> objDatas, float bodySize) {
        Vector3 scenePos = GenerateRandomScenePosition();
        if (objDatas == null) {
            return scenePos;
        }
        //validate pos
        while (!IsScenePositionValid(objDatas, scenePos, bodySize)) {
            scenePos = GenerateRandomScenePosition();
        }
        return scenePos;
    }

    Vector3 GenerateRandomScenePosition() {
        return new Vector3(UnityEngine.Random.Range(-systemSceneSize / 2.0f, systemSceneSize / 2.0f), UnityEngine.Random.Range(-systemSceneSize / 2.0f, systemSceneSize / 2.0f), UnityEngine.Random.Range(-systemSceneSize / 2.0f, systemSceneSize / 2.0f));
    }

    private bool IsScenePositionValid(List<SceneAssetData> objDatas, Vector3 scenePos, float bodySize) {
        for (int i = 0; i < objDatas.Count; i++) {
            //check for overlap
            if (IsAssetOverlapping(objDatas[i], scenePos, bodySize)) {
                return false;
            }
        }
        return true;
    }

    bool IsAssetOverlapping(SceneAssetData existingAssetData, Vector3 newAssetPos, float newAssetSize) {
        if (existingAssetData != null) {
            float r = newAssetSize / 2;
            float rOther = existingAssetData.ObjectSize / 2;
            float sumR = r + rOther;
            float amount = Vector3.Distance(newAssetPos, GameFunctionHelper.ConvertSerializedVector3ToUnityVector3(existingAssetData.ObjectPosition)) - sumR;
            if (amount <= 0) {
                return true;
            }
        }
        return false;
    }

    private string ConvertEnumValueToTitleCase(string enumValue) {
        string titleCasedEnum = "";
        char delimiter = '_';
        string[] enumWords = enumValue.Split(delimiter);
        for (int i = 0; i < enumWords.Length; i++) {
            titleCasedEnum += new CultureInfo("en-US", false).TextInfo.ToTitleCase(enumWords[i].ToLower());
        }
        return titleCasedEnum;
    }
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