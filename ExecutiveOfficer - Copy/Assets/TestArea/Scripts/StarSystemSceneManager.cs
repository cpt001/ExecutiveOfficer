using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystemSceneManager : MonoBehaviour {
    public const string FilePath = "StarSystemData/";

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

    //load scene data at a given index
    public void LoadScene() {
        StarSystemData sceneData;
    }

    //save scene data at index
    public void SaveScene() {

    }
}