using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    /// Determines player spawn location
    /// 
    /// Need to set particles to false
    /// Need to set UI to false
    /// Need to create prefab from galaxy gen?
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
    public GameObject[] possiblePlayerStartLocations;   //Determines potential start locations.
    public GameObject[] gmb;       //Generates galaxy star nodes with information
    public SystemBehaviour sysBehavior;
    //public SystemFinder[] systemFinder;     //Executes system find, link
    //public GalacticMapGenerator[] gmg;    //Controls clickable node generation and triggers generation of connections between stars
    //public PlayerLocator playerLocation;  //Finds the player's home, adjusts linked systems
    //public EnemyLocator enemyLocator;     //Finds the enemy's home base, and scatters hardpoints across the galaxy

    [Header("UI Information")]
    public Slider nodeCount;
    public Slider galaxyArmCount;
    public GameObject GAC_GO;
    public GameObject Node_GO;
    private TextMeshProUGUI GACText;
    private TextMeshProUGUI NodeText;
    //public GameObject playerSpawnIndicator;


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
        //PlayerLocator();
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
        galaxyGenerator.canGenerate = true;
    }
    public List<SystemBehaviour> candidates = new List<SystemBehaviour>();
    private int playerSpawnCandidateLocation;
    public GameObject playerSpawn;
    public void PlayerLocator() //This function WRECKS editor performance.
    {
        //foreach (Transform starContainer in transform.GetComponentInChildren<Transform>())
        foreach(SystemBehaviour starContainer in transform.GetComponentsInChildren<SystemBehaviour>())
        {
            if (starContainer.GetComponentInChildren<SystemBehaviour>().typeOfStar == SystemBehaviour.StarType.ClassA)
            {
                candidates.Add(starContainer.GetComponentInChildren<SystemBehaviour>());
                //Instantiate(playerSpawnIndicator, starContainer.transform);
                //Debug.Log("Candidate Found: " + candidates);
            }
            /*  Need to create an exception for finding NO class x stars, rather than an exception for all stars but class x
            {
                Debug.Log("No spawn candidates found, please regenerate galaxy.");
            }*/
        }

        if (!playerSpawn)
        {
            playerSpawnCandidateLocation = Random.Range(0, candidates.Count);
            playerSpawn = candidates[playerSpawnCandidateLocation].gameObject;
            sysBehavior = playerSpawn.GetComponent<SystemBehaviour>();
            sysBehavior.playerPresent = true;
        }
    }
}
