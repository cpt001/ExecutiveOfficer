using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerationController : MonoBehaviour
{
    /// <summary>
    /// This controller determines all the stats for the individual components.
    /// Currently capable of... 
    /// UI designated change of Arm and Node counts
    /// UI designated generation
    /// 
    /// Future Plans...
    /// >Should be able to 'lock' generation, and allow the player to begin generation of the selectable map.
    /// >Should be able to determine player starting location, and safe zone allocation.
    /// >Should be able to determine the opposing AI's difficulty and starting locations
    /// 
    /// Persisting Bugs...
    /// 1) The previous galaxy still refuses to be removed when generation is triggered.
    /// 
    /// </summary>

    
    public bool generateNewGalaxy;
    private bool galaxyGenerated;
    [Range(1, 11)]
    public float NumberArms = 1;
    //private int numArmsGenerated;
    [Range(30, 300)]
    public float numNodes;    //How many nodes generate in the galaxy
    [Tooltip("Beware, this can affect performance drastically.")]
    public int NumSystemsPerNode;


    //This is planned information
    [Range(0, 5)]
    public int difficulty;  //0 sandbox, 1 easy, 2 normal, 3 hard, 4 difficult, 5 impossible
    public float resourceDensityController;
    public int numBodiesPerSystem;  //Each body increases the resource density bias
    public float habitabilityBias;  
    public float ireBias;
    public float enemyControlOverSystems;
    public float enemyAwakeness;
    public int playerMercyZone; //How many linked systems will be relatively safe for the player to expand to
    private GameObject centerOfGalaxy;

    [Header("Execution Phases")]
    public bool generateGalaxy = false;
    public bool acceptGalaxy = false;

    [Header("SubScripts")]
    public GalaxyGenerator galaxyGenerator; //Generates the master galaxy shape
    public GalacticMapGenerator[] mapGen;   //Populates galaxy with starfields. Can be regenerated for new configs
    public GameObject[] gmb;       //Generates galaxy star nodes with information
    public SystemFinder[] systemFinder;     //Executes system find, link
    public GalacticMapGenerator[] gmg;    //Controls clickable node generation and triggers generation of connections between stars
    //public PlayerLocator playerLocation;  //Finds the player's home, adjusts linked systems
    //public EnemyLocator enemyLocator;     //Finds the enemy's home base, and scatters hardpoints across the galaxy

    [Header("UI Information")]
    public Slider nodeCount;
    public Slider galaxyArmCount;
    public GameObject GAC_GO;
    public GameObject Node_GO;
    private TextMeshProUGUI GACText;
    private TextMeshProUGUI NodeText;


    private void Awake()
    {
        centerOfGalaxy = GameObject.FindGameObjectWithTag("CenterOfGalaxy");
        GACText = GAC_GO.GetComponent<TextMeshProUGUI>();
        NodeText = Node_GO.GetComponent<TextMeshProUGUI>();
        if (GACText == null || NodeText == null)
        {
            Debug.LogError("Failed to get component");
        }
    }


    // Update is called once per frame
    void Update()
    {
        numNodes = nodeCount.value;
        NodeText.SetText("Value # " + nodeCount.value); //NodeText.text = "Value # " + nodeCount.value;
        NumberArms = galaxyArmCount.value;
        GACText.SetText("Value # " + galaxyArmCount.value); //GACText.text = "Value # " + galaxyArmCount.value;

        if (generateGalaxy)
        {
            //Generates nodes, then the particle systems on top of them
            Generation();
        }

        if (acceptGalaxy)
        {       
            foreach(GameObject s2 in gmb)
            {
                gameObject.AddComponent<SystemBehaviour>();
            }
        }
    }

    public void GenerateClickables()
    {        
        GalacticMapGenerator[] gmg = FindObjectsOfType<GalacticMapGenerator>(); 
        for (int i = 0; i < gmg.Length; i++)
        {
            //Debug.Log("Generation Triggerd on obj: " + gmg[i].gameObject.name);
            gmg[i].ButtonControlGenerateStars();
        }
    }

    public void Generation()
    {
        if (NumberArms != galaxyGenerator.numArmsGenerated) //if the number of arms has changed, regenerate the galaxy
        {
            galaxyGenerator.ChangeArms();
        }

        if (centerOfGalaxy.GetComponentInChildren<Transform>() != null)
        {
            foreach(Transform child in centerOfGalaxy.transform)
            {
                Destroy(child.gameObject);
            }
        }

        /*gmb = GameObject.FindGameObjectsWithTag("StarSystem");
        if (gmb != null)    //Destroy the old galaxy    -- This isnt working. need to remotely destroy all the objects in hierarchy under the center of galaxy item. (2021)
        {
            foreach (GameObject s in gmb)
            {
                Destroy(gameObject);
            }
        }*/
        galaxyGenerator.canGenerate = true;
    }
}
