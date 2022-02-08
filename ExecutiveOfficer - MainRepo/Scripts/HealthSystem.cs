using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create a simple list that grabs all children, place on each armor container
/// Create a list of lists
/// </summary>
/// 
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

    /// <summary>
    /// Armor holder is the master object containing all armor collisions.
    /// Hardpoint holder contains all hardpoints.
    /// </summary>
    public GameObject armorHolder;
    private Collider[] ArmorColliders;
    public GameObject hardPointHolder;
    private Collider[] HardPointColliders;

    /// <summary>
    /// maybe populate master list
    /// then populate sublists from there instead of dynamically creating them?
    /// </summary>
    /// 
    public Transform armorContainer;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.Find("ArmorContainer"))
        {

            armorContainer = gameObject.transform.Find("ArmorContainer");
            foreach (Transform child in armorContainer.transform)
            {
                if (child != null)  //Theoretically should only fire if there's child objects? Might be better to restructure armor container to contain vitals instead.
                {
                    foreach (ShipModule aL in child.GetComponentInChildren<ArmorList>().moduleList)    //This still only gets the top layer
                    {
                        if (aL != null)
                        {
                            Debug.Log("Module Found: " + aL.name);
                        }
                        if (!aL)
                        {
                            Debug.Log("No Shipmodule Found");
                            break;
                        }
                    }
                }
                else
                {
                    Debug.Log("No Child found; ensure there's shipmodule components on attached armor pieces!");
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
