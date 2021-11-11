using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SimpleHealth : MonoBehaviour
{
    //public float mainHP = 100.0f;
    //public GameObject destroyedObject;
    public float damageTaken = 0;
    public bool damageApplied;

    public float ReactorHealth;
    public float EngineHealth;

    public List<ShipModule> shipHealthItems = new List<ShipModule>();
    public List<float> shipHealth = new List<float>();

    private void Start()
    {
        FillLists();
    }

    private void Update()
    {
        if (shipHealth.Average() <= 35)
        {

        }
    }

    private void FillLists()
    {
        //Gets all components with health and adds to list  --why isnt this working? --it sees and adds 4 objects, but theyre not populating?
        foreach (Transform child in transform)
        {
            shipHealthItems.Add(child.GetComponent<ShipModule>());
            //if (child.GetComponent<ShipModule>())            {            }
        }

        foreach (ShipModule module in shipHealthItems)
        {
            if (module.name.Contains("Reactor"))
            {
                ReactorHealth = module.health;
            }
            if (module.name.Contains("Engine"))
            {
                EngineHealth = module.health;
            }
            shipHealth.Add(module.health);
        }
    }

    public IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
