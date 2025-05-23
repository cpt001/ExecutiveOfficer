﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameStart : MonoBehaviour {
    //player ship ref
    public PlayerShipController playerShip;
    //target rb
    public Rigidbody targetRB;
    //target module
    public ShipModule targetModule;
    //target velocity
    public float targetVelocity;

    private void Awake() {
        
    }

    private void Start() {
        Init();
    }

    private void FixedUpdate() {

    }

    private void Init() {
        
        playerShip.DebugSetAllTurretsTarget(targetModule);
        AccelerateTargetRigidBody();
    }

    private void AccelerateTargetRigidBody() {
        targetRB.AddForce(Vector3.forward * targetVelocity, ForceMode.Impulse);
    }
}