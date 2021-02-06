using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModule : MonoBehaviour {
    [SerializeField]
    private int health;
    [SerializeField]
    private Collider hitBox;

    public void ApplyDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            hitBox.enabled = false;
        }
    }
}