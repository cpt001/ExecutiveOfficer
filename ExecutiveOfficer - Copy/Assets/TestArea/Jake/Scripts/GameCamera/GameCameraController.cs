using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameCameraController : MonoBehaviour {
    [SerializeField]
    private CinemachineBrain cameraBrain;
    [SerializeField]
    private CinemachineVirtualCameraBase gameCamera;

    private void Start() {
        
    }

    private void Init() {

    }

    private void AddListeners() {
        Events.instance.AddListener<ChangeGameCameraEvent>(HandleGameCameraChange);
    }

    private void RemoveListeners() {
        Events.instance.RemoveListener<ChangeGameCameraEvent>(HandleGameCameraChange);
    }

    private void HandleGameCameraChange(ChangeGameCameraEvent cameraEvent) {
        if (cameraEvent.isBlendFinished == false) {
            ChangeGameCamera(cameraEvent.gameCamera);
        }
    }

    private void ChangeGameCamera(CinemachineVirtualCameraBase gameCam) {
        gameCamera.gameObject.SetActive(false);
        gameCamera = gameCam;
        gameCamera.gameObject.SetActive(true);
        StartCoroutine(HandleGameCameraBlend(gameCam));
    }

    private IEnumerator HandleGameCameraBlend(CinemachineVirtualCameraBase gameCam) {
        //wait until blend has finished
        while (cameraBrain.IsBlending == true) {
            yield return new WaitForSeconds(0);
        }
        Events.instance.Raise(new ChangeGameCameraEvent(gameCam, true));
        yield return null;
    }

    private void OnEnable() {
        AddListeners();
    }

    private void OnDisable() {
        RemoveListeners();
    }
}