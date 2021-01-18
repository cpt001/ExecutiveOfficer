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

    [Header("Armor Section Hp")]
    public float Fore;
    public float Aft;
    public float[] Ventral;
    public float[] Dorsal;
    public float[] Port;
    public float[] Starboard;
    public float[] hangarDoorHealth;
    public float ReactorArmor;  //This armor exists around the reactor only as a buffer against serious damage (prevents easy kill)

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
        if (armorHolder != null)
        {
            ArmorColliders = GetComponentsInChildren<Collider>();
            for (int i = 0; i > ArmorColliders.Length; i++)
            {

            }
        }
        else
        {
            Debug.Log("Armor Holder not implemented!");
        }
        if (hardPointHolder != null)
        {
            HardPointColliders = GetComponentsInChildren<Collider>();
            for (int i = 0; i > HardPointColliders.Length; i++)
            {

            }
        }
        else
        {
            Debug.Log("Hardpoint Holder not implemented!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
