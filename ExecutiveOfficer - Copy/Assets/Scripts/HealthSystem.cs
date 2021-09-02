using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //Here's how this works. Players beat through section armors. 
    //If the shots don't connect with a subsection, it does .2 a pt of strint damage. 
    //If the shots are passing through a subsection, it does .5 pt.
    //Explosions from subsections failing do more damage depending on the system destroyed.
    [Header("Master HP")]
    public float structuralIntegrity = 100.0f;   //Master HP, pressure point damage. If a section is destroyed, *STRINT* starts taking damage.

    [Header("Armor Sections")]
    [SerializeField]
    private Dictionary<string, List<float>> armorListDictionary = new Dictionary<string, List<float>>();  //First time using dictionaries

    /*[Header("Armor Sections")]
    public List<GameObject> MasterArmorList = new List<GameObject>();
    public List<GameObject> NoseArmors = new List<GameObject>();
    public List<GameObject> NeckArmors = new List<GameObject>();
    public List<GameObject> BodyArmors = new List<GameObject>();
    public List<GameObject> ConnectorArmors = new List<GameObject>();
    public List<GameObject> HangarMaintenanceArmors = new List<GameObject>();
    public List<GameObject> HangarArmors = new List<GameObject>();
    public List<GameObject> EngineeringArmors = new List<GameObject>();
    public List<GameObject> EngineArmors = new List<GameObject>();
    public List<GameObject> JumpPylonArmors = new List<GameObject>();

    /*[Header("Armor Section Values")]
    public List<float> NoseArmorValues = new List<float>();
    public List<float> NeckArmorValues = new List<float>();
    public List<float> BodyArmorValues = new List<float>();
    public List<float> ConnectorArmorValues = new List<float>();
    public List<float> HangarMaintenanceArmorValues = new List<float>();
    public List<float> HangarArmorValues = new List<float>();
    public List<float> EngineeringArmorValues = new List<float>();
    public List<float> EngineArmorValues = new List<float>();
    public List<float> JumpPylonArmorValues = new List<float>();*/

    //This armor exists around the reactor only as a buffer against serious damage (prevents easy kill)

    [Header("Subsections")]
    public float engineeringHealth;     //Deals 30 strint damage if destroyed. Cannot repair engines if destroyed.
    public float reactorHealth;         //Deals 70 strint damage if destroyed.
    public float lifeSupportHealth;     //Deals 15 strint damage
    public float bridgeHealth;          //Deals 10 strint damage, ship will drift momentarily until engineering takes control. If engineering is destroyed, ship will drift indefinitely.
    public float fighterControlHealth;  //Deals 10 strint damage, fighters will continue engaging until dead. No replenishment.
    public float commsHealth;           //Deals 5 strint damage, unit will ignore formation orders.
    public float[] hangarHealth;        //Deals 10 strint damage, unit can no longer launch fighters.
    public float[] crewQuartersHealth;  //Deals 5 strint damage
    public float[] armoryHealth;        //Deals 5 strint damage
    public float[] munitionsStoreHealth;//Deals 30 strint damage, ship will fire less often, and eventually stop firing all together.
    public float[] engineHealth;        //Deals 10 strint damage, ship will drift.
    public float[] sensorHealth;        //Deals 5 strint damage, ship accuracy will reduce.

    /// <summary>
    /// Armor holder is the master object containing all armor collisions.
    /// Hardpoint holder contains all hardpoints.
    /// </summary>
    public GameObject armorHolder;
    private Collider[] ArmorColliders;
    public GameObject hardPointHolder;
    private Collider[] HardPointColliders;


    // Start is called before the first frame update
    void Start()
    {
        /*foreach(GameObject armor in GameObject.FindGameObjectsWithTag("DamagePoint")) //This works, but not to the end i need it too
        {
            MasterArmorList.Add(armor);
        }*/
        if (transform.Find("ArmorContainer"))   //Looks for the armor container -- it finds it, but it's not the default search point. it starts from root
        {
            Transform ArmorTarget = transform.Find("ArmorContainer");
            //Debug.Log("Armor Container found");
            foreach (Transform allSubObjects in ArmorTarget)    //Looks for each gameobject listed as a child
            {
                //Debug.Log("Subobjects found");
                string listName = gameObject.name;
                CreateList(listName);   //List created here with objects as name
                //Debug.Log("DamageContainer has objects: " + allSubObjects);

                foreach (Transform containedArmor in ArmorTarget.GetComponentInChildren<Transform>())   //Foreach object listed as a child of the damage container
                {
                    //Debug.Log("Contained armor has objects: " + containedArmor);
                    //List populated here; how do you access this new list?
                    
                    if (containedArmor == null)
                    {
                        //Debug.LogError("ArmorContainer has control points, but no damage points!");
                    }
                }
                
                if (allSubObjects == null)
                {
                    Debug.LogError("ArmorContainer has no control points!");
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("No ArmorContainer subobject found!");
        }
    }

    float defaultValues;
    public void CreateList(string listName)
    {
        List<float> list = new List<float>();
        armorListDictionary.Add(listName, list);
        list.Add(defaultValues);
        //Debug.Log("List created " + list);
        Debug.Log("Dictionary created: " + armorListDictionary);
    }
}
