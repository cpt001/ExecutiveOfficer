using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private float speed = 100;
    [SerializeField]
    private float rotationSpeed = 25;
    [SerializeField]
    private float focusDistance = 2000;    //Distance at which missile stops following, and flies straight.
    public Transform target;
    private float detectionDistance = 5.0f;
    private bool isLookingAtObject = false;
    private int barrelLayerMask;
    public GameObject explosive;
    private bool isFollowingTarget;
    private Vector3 tempVector;

    private void Awake()
    {
        barrelLayerMask = LayerMask.GetMask("SpawnPoint");
    }

    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("TestTarget").transform;
        }
    }

    void Update()
    {
        if (!target)
        {
            isFollowingTarget = false;
        }

        if (Vector3.Distance(transform.position, target.position) < focusDistance)
        {
            isFollowingTarget = false;
        }
        if (target)
        {
            isFollowingTarget = true;
            Vector3 targetDirection = target.position - transform.position;

            if (isLookingAtObject)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

                if (isFollowingTarget)
                {
                    transform.rotation = Quaternion.LookRotation(newDirection);
                }
            }
            else
            {
                if (isFollowingTarget)
                {
                    tempVector = targetDirection.normalized;

                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(tempVector * speed * Time.deltaTime, Space.World);
                }
            }
        }

        RaycastHit projectileHit;
        if (Physics.Raycast(transform.position, transform.forward, out projectileHit, detectionDistance, ~barrelLayerMask))
        {
            if (projectileHit.transform.GetComponent<SimpleHealth>())
            {
                
                HitSomething();
            }
            else
            {
                Explosion();
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Shootable")
        {
            Explosion();
        }
    }

    private void HitSomething()
    {
        Instantiate(explosive, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void Explosion()
    {
        Instantiate(explosive, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
