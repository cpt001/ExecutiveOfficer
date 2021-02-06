using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float lifetime = 0.0f;
    [SerializeField]
    private float movementSpeed = 0.0f;
    [SerializeField]
    private int damage = 0;

    private void Awake() {
        Init();
    }

    private void Init() {
        StartCoroutine(HandleProjectileLifetime());
    }

    public void DamageModule(ShipModule module) {
        module.ApplyDamage(damage);
    }

    private IEnumerator HandleProjectileLifetime() {
        yield return new WaitForSeconds(lifetime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform != transform) {
            ShipModule module = collision.transform.GetComponent<ShipModule>();
            if (module != null) {
                module.ApplyDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}