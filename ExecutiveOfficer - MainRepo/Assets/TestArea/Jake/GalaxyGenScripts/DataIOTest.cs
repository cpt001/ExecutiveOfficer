using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataIOTest : MonoBehaviour {
    //private static int minSeedValue = -10000;
    //private static int maxSeedValue = 10000;

    //[SerializeField]
    //private GameObject emptyPlanetPrefab = null;

    //[Header("Earth Reference")]
    //[SerializeField]
    //private CelestialBodySettings earthCelestialSettings = null;
    //[SerializeField]
    //private EarthShape earthShapeSettings = null;
    //[SerializeField]
    //private EarthShading earthShadingSettings = null;
    //[SerializeField]
    //private OceanSettings earthOceanSettings = null;
    //[SerializeField]
    //private AtmosphereSettings earthAtmosphereSettings = null;

    //// Start is called before the first frame update
    //void Start() {
    //    //GenerateEarth();
    //}

    //// Update is called once per frame
    //void Update() {
    //    if (Input.GetKeyDown(KeyCode.Space)) {
    //        //SaveBodyAssetsToDisk(testBody, 0);
    //        TestLoadEarth();
    //    }
    //}

    //int GenerateSeed() {
    //    return Random.Range(minSeedValue, maxSeedValue);
    //}

    //void TestLoadEarth() {
    //    LoadEarthData(0);
    //}

    //void GenerateSceneData() {
    //    //determine num of stars
    //    //determine num of planetoids
    //    //for loop, generate planet data
    //    //-attempt to find unobstructed position
    //}

    ////generates randomized earth data and saves to disk
    //void GenerateEarthData() {
    //    string planetDir = "Assets/TestArea/GeneratedPlanets/Earth";
    //    List<string> dirs = new List<string>(Directory.EnumerateDirectories(planetDir));
    //    int assetIndex = dirs.Count;

    //    //create data instance clones
    //    CelestialBodySettings bodySettings = earthCelestialSettings.Clone();
    //    OceanSettings oceanSettings = earthOceanSettings.Clone();
    //    AtmosphereSettings atmosphereSettings = earthAtmosphereSettings.Clone();
    //    EarthShape shapeSettings = earthShapeSettings.Clone();
    //    EarthShading shadingSettings = earthShadingSettings.Clone();

    //    //modify data
    //    shapeSettings.seed = GenerateSeed();
    //    bodySettings.shape = shapeSettings;
    //    shadingSettings.seed = GenerateSeed();
    //    shadingSettings.atmosphereSettings = atmosphereSettings;
    //    shadingSettings.oceanSettings = oceanSettings;
    //    bodySettings.shading = shadingSettings;

    //    //save data
    //    string guid = AssetDatabase.CreateFolder(planetDir, assetIndex.ToString());
    //    string assetPath = AssetDatabase.GUIDToAssetPath(guid);
    //    AssetDatabase.CreateAsset(atmosphereSettings, assetPath + "/Atmosphere.asset");
    //    AssetDatabase.CreateAsset(oceanSettings, assetPath + "/Ocean.asset");
    //    AssetDatabase.CreateAsset(shapeSettings, assetPath + "/Shape.asset");
    //    AssetDatabase.CreateAsset(shadingSettings, assetPath + "/Shading.asset");
    //    AssetDatabase.CreateAsset(bodySettings, assetPath + "/Body.asset");
    //}

    ////instantiates empty planet object and assigns loaded earth data
    //void LoadEarthData(int assetIndex) {
    //    string assetDir = "Assets/TestArea/GeneratedPlanets/Earth/" + assetIndex + "/";

    //    //load data as instances
    //    //GameObject planet = Instantiate(emptyPlanetPrefab);
    //    //CelestialBody body = planet.GetComponent<CelestialBody>();
    //    CelestialBodySettings bodySettings = (CelestialBodySettings)AssetDatabase.LoadAssetAtPath(assetDir + "Body.asset", typeof(CelestialBodySettings));
    //    OceanSettings oceanSettings = (OceanSettings)AssetDatabase.LoadAssetAtPath(assetDir + "Ocean.asset", typeof(OceanSettings));
    //    AtmosphereSettings atmosphereSettings = (AtmosphereSettings)AssetDatabase.LoadAssetAtPath(assetDir + "Atmosphere.asset", typeof(AtmosphereSettings));
    //    EarthShape shapeSettings = (EarthShape)AssetDatabase.LoadAssetAtPath(assetDir + "Shape.asset", typeof(EarthShape));
    //    EarthShading shadingSettings = (EarthShading)AssetDatabase.LoadAssetAtPath(assetDir + "Shading.asset", typeof(EarthShading));

    //    //create gameobject and apply data
    //    GameObject planetObject = Instantiate(emptyPlanetPrefab);
    //    CelestialBodyGenerator generator = planetObject.GetComponentInChildren<CelestialBodyGenerator>();
    //    generator.body = bodySettings;
    //}

    //void GenerateMoon() {

    //}

    //void GenerateCyclops() {

    //}

    //void GenerateIcy() {

    //}

    //void GenerateFire() {

    //}

    //void GenerateBean() {

    //}

    //void GenerateEye() {

    //}

    //void GenerateStarSystemScene(StarSystemData systemData) {

    //}

    //Vector3 GenerateRandomScenePosition(float sceneSize) {
    //    float halfSize = sceneSize / 2.0f;
    //    return new Vector3(Random.Range(-halfSize, halfSize), Random.Range(-halfSize, halfSize), Random.Range(-halfSize, halfSize));
    //}

    //bool ValidateBodyPosition() {
    //    return true;
    //}

    ////void SaveBodyAssetsToDisk(GameObject bodyObject, int assetIndex) {
    ////    Mesh mesh = bodyObject.GetComponentInChildren<MeshFilter>().sharedMesh;
    ////    MeshRenderer meshRen = bodyObject.GetComponentInChildren<MeshRenderer>();
    ////    Material mat = meshRen.sharedMaterial;
    ////    //Texture2D tex = mat.mainTexture;

    ////    string guid = AssetDatabase.CreateFolder("Assets/TestArea/GeneratedPlanets", assetIndex.ToString());
    ////    string assetPath = AssetDatabase.GUIDToAssetPath(guid);
    ////    AssetDatabase.CreateAsset(mat, assetPath + "/Material.mat");
    ////    AssetDatabase.CreateAsset(mesh, assetPath + "/Mesh.mesh");
    ////}
}