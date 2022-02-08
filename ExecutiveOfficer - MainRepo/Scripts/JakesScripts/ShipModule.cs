using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModule : MonoBehaviour {
    //[SerializeField]
    public int health;
    [SerializeField]
    private Collider hitBox;
    [SerializeField]
    private GameObject moduleDamage;

    private void Awake()
    {
        if (hitBox == null)
        {
            hitBox = GetComponent<Collider>();
        }
    }

    public void ApplyDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            //destroyed module event
            Events.instance.Raise(new ModuleDestroyedEvent(this));

            //destroy module
            //Destroy(gameObject);    //Destroy removed in exchange for effects
            ModuleDestroyed();
        }
    }

    public void ModuleDestroyed() //Fix me
    {
        hitBox.enabled = false;
        Instantiate(moduleDamage, transform.position, Quaternion.identity, this.transform.parent);
    }
}