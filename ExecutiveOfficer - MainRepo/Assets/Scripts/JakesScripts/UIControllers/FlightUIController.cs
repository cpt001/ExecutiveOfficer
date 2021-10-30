using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightUIController : MonoBehaviour {
    [SerializeField]
    private Transform reticlePanel;
    [SerializeField]
    private GameObject flightReticlePrefab;
    private GameObject flightReticleObj;

    private void Awake() {
        Init();
    }

    private void Init() {

    }

    private void AddListeners() {
        Events.instance.AddListener<EnterFlightEvent>(ActivateFlightCursor);
        Events.instance.AddListener<EnterTargetingEvent>(DeactivateFlightCursor);
    }

    private void RemoveListeners() {
        Events.instance.RemoveListener<EnterFlightEvent>(ActivateFlightCursor);
        Events.instance.RemoveListener<EnterTargetingEvent>(DeactivateFlightCursor);
    }

    private void ActivateFlightCursor(EnterFlightEvent flightEvent) {
        flightReticleObj = Instantiate(flightReticlePrefab, reticlePanel);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DeactivateFlightCursor(EnterTargetingEvent targetingEvent) {
        Destroy(flightReticleObj);
    }

    private void OnEnable() {
        AddListeners();
    }

    private void OnDisable() {
        RemoveListeners();
    }
}