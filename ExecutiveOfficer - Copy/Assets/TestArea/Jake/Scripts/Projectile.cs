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
    private Rigidbody projectileRigidbody;
    private bool isArmed;

    public float MovementSpeed {
        get {
            return movementSpeed;
        }

        set {
            movementSpeed = value;
        }
    }

    private void Awake() {
        Init();
    }

    private void Init() {
        projectileRigidbody = GetComponent<Rigidbody>();
        StartCoroutine(HandleProjectileLifetime());
    }

    private void Update() {
        //print("Projectile velocity - " + projectileRigidbody.velocity + "!");
        //print("Projectile velocity magnitude - " + projectileRigidbody.velocity.magnitude + "!");
    }

    private void FixedUpdate() {
        //translate movement
        //transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
    }

    public void InitializeProjectileVelocity(Vector3 parentVelocity) {
        projectileRigidbody.AddForce(transform.forward * movementSpeed + parentVelocity, ForceMode.Impulse);
        //projectileRigidbody.velocity = transform.forward * movementSpeed;// + parentVelocity;
    }

    private void DamageModule(ShipModule module) {
        module.ApplyDamage(damage);
    }

    private IEnumerator HandleProjectileLifetime() {
        yield return new WaitForSeconds(lifetime);
    }

    private void OnTriggerEnter(Collider other) {
        if (isArmed) {
            if (other.transform != transform) {
                ShipModule module = other.transform.GetComponent<ShipModule>();
                if (module != null) {
                    module.ApplyDamage(damage);
                }
                Destroy(gameObject);
            }
        }
    }

    //Arms projectile after leaving turret dome
    private void OnTriggerExit(Collider other) {
        if (other.name == "TurretDome") {
            isArmed = true;
        }
    }
}