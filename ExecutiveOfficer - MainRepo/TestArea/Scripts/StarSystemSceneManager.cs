using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StarSystemSceneManager : MonoBehaviour {
    public const string FilePath = "StarSystemData/";

    [SerializeField]
    private GameObject emptyStarPrefab = null;
    [SerializeField]
    private GameObject emptyPlanetPrefab = null;

    private StarSystemData currentSceneData = null;

    //load scene data at a given index
    public void LoadScene(StarSystemData sceneData) {
        //load and create objects in scene based on sceneData

        //load stars
        for (int i = 0; i < sceneData.StarDatas.Count; i++) {
            //instantiate empty star prefab at saved position
            LoadStar(sceneData.StarDatas[i]);
        }

        //load planets
        for (int i = 0; i < sceneData.StarDatas.Count; i++) {
            //instantiate empty planet prefab at saved position
            LoadPlanet(sceneData.PlanetDatas[i]);
        }

        //load store stations
        //for (int i = 0; i < sceneData.StoreDatas.Count; i++) {

        //}

        //load enemies
        //for (int i = 0; i < sceneData.EnemyDatas.Count; i++) {

        //}
    }

    //save scene data at index
    public void SaveScene() {
        //save star data

        //save planet data

        //save store data

        //save enemy data

        //save to galaxy data on disk
    }

    private void LoadStar(StarData star) {
        GameObject starObj = Instantiate(emptyStarPrefab, GameFunctionHelper.ConvertSerializedVector3ToUnityVector3(star.ObjectPosition), Quaternion.Euler(GameFunctionHelper.ConvertSerializedVector3ToUnityVector3(star.ObjectRotation)));
        starObj.transform.localScale = new Vector3(star.ObjectSize, star.ObjectSize, star.ObjectSize);
        starObj.GetComponent<Renderer>().material = (Material)AssetDatabase.LoadAssetAtPath(star.AssetPath + "/Material.asset", typeof(Material));
        starObj.GetComponent<Star>().Data = star;
    }

    private void LoadPlanet(PlanetData planet) {
        GameObject planetObj = Instantiate(emptyPlanetPrefab, GameFunctionHelper.ConvertSerializedVector3ToUnityVector3(planet.ObjectPosition), Quaternion.Euler(GameFunctionHelper.ConvertSerializedVector3ToUnityVector3(planet.ObjectRotation)));
        planetObj.transform.localScale = new Vector3(planet.ObjectSize, planet.ObjectSize, planet.ObjectSize);
        planetObj.GetComponent<Planet>().Data = planet;
        CelestialBodySettings bodysettings = (CelestialBodySettings)AssetDatabase.LoadAssetAtPath(planet.AssetPath + "/Body.asset", typeof(CelestialBodySettings));
        CelestialBodyGenerator generator = planetObj.GetComponentInChildren<CelestialBodyGenerator>();
        generator.body = bodysettings;
        //switch (planet.BodyType) {
        //    case PlanetType.BEAN:
        //    LoadBeanData(planetObj);
        //    break;
        //    case PlanetType.CYCLOPS:
        //    LoadCyclopsData(planetObj);
        //    break;
        //    case PlanetType.EARTH:
        //    LoadEarthData(planetObj);
        //    break;
        //    case PlanetType.EYE:
        //    LoadEyeData(planetObj);
        //    break;
        //    case PlanetType.FIERY:
        //    LoadFieryData(planetObj);
        //    break;
        //    case PlanetType.ICY:
        //    LoadIcyData(planetObj);
        //    break;
        //    case PlanetType.MOON:
        //    LoadMoonData(planetObj);
        //    break;
        //}
    }

    //private void LoadBeanData(GameObject planetObj) {
        
    //}

    //private void LoadCyclopsData(GameObject planetObj) {

    //}

    //void LoadEarthData(GameObject planetObj) {
    //    PlanetData data = planetObj.GetComponent<PlanetData>();

    //    //load data as instances
    //    //celestialbody body = planet.getcomponent<celestialbody>();
    //    CelestialBodySettings bodysettings = (CelestialBodySettings)AssetDatabase.LoadAssetAtPath(data.AssetPath + "/Body.asset", typeof(CelestialBodySettings));
    //    //OceanSettings oceansettings = (OceanSettings)AssetDatabase.LoadAssetAtPath(data.AssetPath + "/Ocean.asset", typeof(OceanSettings));
    //    //AtmosphereSettings atmospheresettings = (AtmosphereSettings)AssetDatabase.LoadAssetAtPath(data.AssetPath + "/Atmosphere.asset", typeof(AtmosphereSettings));
    //    //EarthShape shapesettings = (EarthShape)AssetDatabase.LoadAssetAtPath(data.AssetPath + "/Shape.asset", typeof(EarthShape));
    //    //EarthShading shadingsettings = (EarthShading)AssetDatabase.LoadAssetAtPath(data.AssetPath + "/Shading.asset", typeof(EarthShading));

    //    CelestialBodyGenerator generator = planetObj.GetComponentInChildren<CelestialBodyGenerator>();
    //    generator.body = bodysettings;
    //}

    //private void LoadEyeData(GameObject planetObj) {

    //}

    //private void LoadFieryData(GameObject planetObj) {

    //}

    //private void LoadIcyData(GameObject planetObj) {

    //}

    //private void LoadMoonData(GameObject planetObj) {

    //}
}