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

    private void FixedUpdate() {
        transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
    }

    public void DamageModule(ShipModule module) {
        module.ApplyDamage(damage);
    }

    private IEnumerator HandleProjectileLifetime() {
        yield return new WaitForSeconds(lifetime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform != transform) {
            ShipModule module = other.transform.GetComponent<ShipModule>();
            if (module != null) {
                module.ApplyDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}