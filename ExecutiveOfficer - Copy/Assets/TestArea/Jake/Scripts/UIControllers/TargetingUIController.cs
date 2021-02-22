using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingUIController : MonoBehaviour {
    [SerializeField]
    private Transform reticlePanel;
    [SerializeField]
    private Transform targetingPanel;
    [SerializeField]
    private GameObject targetHighlightPrefab;
    [SerializeField]
    private GameObject targetLockOnPrefab;
    [SerializeField]
    private GameObject targetingReticlePrefab;
    private GameObject targetingReticleObj;
    //kv pair = target data, ui object
    private Dictionary<TargetingData, GameObject> targetDict = new Dictionary<TargetingData, GameObject>();

    private void OnEnable() {
        AddEventListeners();
    }

    private void OnDisable() {
        RemoveEventListeners();
    }

    private void Awake() {
        Init();    
    }

    private void Update() {
        UpdateUIElements();
    }

    private void Init() {
        
    }

    private void TestInit() {

    }

    private void AddEventListeners() {
        Events.instance.AddListener<EnterTargetingEvent>(OnTargetingModeEntered);
        Events.instance.AddListener<EnterFlightEvent>(OnTargetingModeExited);
        Events.instance.AddListener<ShipTargetingEvent>(OnShipTargeting);
        Events.instance.AddListener<ModuleDestroyedEvent>(OnTargetModuleDestroyed);
    }

    private void RemoveEventListeners() {
        Events.instance.RemoveListener<EnterTargetingEvent>(OnTargetingModeEntered);
        Events.instance.RemoveListener<EnterFlightEvent>(OnTargetingModeExited);
        Events.instance.RemoveListener<ShipTargetingEvent>(OnShipTargeting);
        Events.instance.RemoveListener<ModuleDestroyedEvent>(OnTargetModuleDestroyed);
    }

    private void UpdateUIElements() {
        foreach (KeyValuePair<TargetingData, GameObject> targetDataPair in targetDict) {
            UpdateUIPosition(targetDataPair);
            UpdateUIScale(targetDataPair);
        }
    }

    private void UpdateUIPosition(KeyValuePair<TargetingData, GameObject> targetDataPair) {
        Vector3 screenPoint = Vector3.zero;
        screenPoint = Camera.main.WorldToScreenPoint(targetDataPair.Key.targetModule.transform.position);
        targetDataPair.Value.transform.position = screenPoint;
        //disable ui element if behind camera
        if (screenPoint.z < 0.0f) {
            targetDataPair.Value.SetActive(false);
        }
        else {
            targetDataPair.Value.SetActive(true);
        }
    }

    //change UI scale with distance from camera
    private void UpdateUIScale(KeyValuePair<TargetingData, GameObject> targetDataPair) {
        float minimumDistance = 10.0f;
        var maximumDistance = 100.0f;

        var minimumDistanceScale = 1.0f;
        var maximumDistanceScale = 0.1f;

        var distance = (targetDataPair.Key.targetModule.transform.position - Camera.main.transform.position).magnitude;
        var norm = (distance - minimumDistance) / (maximumDistance - minimumDistance);
        norm = Mathf.Clamp01(norm);

        var minScale = Vector3.one * maximumDistanceScale;
        var maxScale = Vector3.one * minimumDistanceScale;

        targetDataPair.Value.transform.localScale = Vector3.Lerp(maxScale, minScale, norm);
    }

    private void ActivateTargetElements() {
        foreach (KeyValuePair<TargetingData, GameObject> targetDataPair in targetDict) {
            targetDataPair.Value.SetActive(true);
        }
    }

    private void DeactivateTargetElements() {
        foreach (KeyValuePair<TargetingData, GameObject> targetDataPair in targetDict) {
            targetDataPair.Value.SetActive(false);
        }
    }

    #region EventListeners
    private void OnShipTargeting(ShipTargetingEvent targetingEvent) {
        switch (targetingEvent.targetData.targetMode) {
            case TargetingMode.HIGHLIGHT:
            OnTargetHighlighted(targetingEvent);
            break;
            case TargetingMode.LOCK:
            OnTargetLocked(targetingEvent);
            break;
            case TargetingMode.UNHIGHLIGHT:
            OnTargetUnhighlighted(targetingEvent);
            break;
            case TargetingMode.UNLOCK:
            OnTargetUnlocked(targetingEvent);
            break;
        }
    }

    private void OnTargetHighlighted(ShipTargetingEvent targetingEvent) {
        //create highlight ui element
        GameObject tmpObj = Instantiate(targetHighlightPrefab);
        //parent ui obj to panel
        tmpObj.transform.SetParent(targetingPanel, false);
        //move ui obj to module position
        tmpObj.transform.position = targetingEvent.targetData.targetModule.transform.position;
        targetDict.Add(targetingEvent.targetData, tmpObj);
    }

    private void OnTargetUnhighlighted(ShipTargetingEvent targetingEvent) {
        //print("Unhighlight event response!");
        targetingEvent.targetData.targetMode = TargetingMode.HIGHLIGHT;
        //destroy ui object
        Destroy(targetDict[targetingEvent.targetData]);
        //remove dict entry
        targetDict.Remove(targetingEvent.targetData);
    }

    private void OnTargetLocked(ShipTargetingEvent targetingEvent) {
        //create lockOn ui element
        GameObject tmpObj = Instantiate(targetLockOnPrefab);
        //parent ui obj to panel
        tmpObj.transform.SetParent(targetingPanel, false);
        //move ui obj to module position
        tmpObj.transform.position = targetingEvent.targetData.targetModule.transform.position;
        targetDict.Add(targetingEvent.targetData, tmpObj);
    }

    private void OnTargetUnlocked(ShipTargetingEvent targetingEvent) {
        targetingEvent.targetData.targetMode = TargetingMode.LOCK;
        //destroy ui object
        Destroy(targetDict[targetingEvent.targetData]);
        //remove dict entry
        targetDict.Remove(targetingEvent.targetData);
    }

    private void OnTargetingModeEntered(EnterTargetingEvent targetingEvent) {
        targetingReticleObj = Instantiate(targetingReticlePrefab, reticlePanel);
        Cursor.lockState = CursorLockMode.Locked;
        ActivateTargetElements();
    }

    private void OnTargetingModeExited(EnterFlightEvent flightEvent) {
        Destroy(targetingReticleObj);
        DeactivateTargetElements();
    }

    private void OnTargetModuleDestroyed(ModuleDestroyedEvent moduleEvent) {
        List<KeyValuePair<TargetingData, GameObject>> entriesToRemove = new List<KeyValuePair<TargetingData, GameObject>>();
        //remove all entries containing module
        foreach (KeyValuePair<TargetingData, GameObject> targetDataPair in targetDict) {
            if (targetDataPair.Key.targetModule == moduleEvent.destroyedModule) {
                entriesToRemove.Add(targetDataPair);
            }
        }
        for (int i = 0; i < entriesToRemove.Count; i++) {
            Destroy(entriesToRemove[i].Value);
            targetDict.Remove(entriesToRemove[i].Key);
        }
    }
    #endregion
}