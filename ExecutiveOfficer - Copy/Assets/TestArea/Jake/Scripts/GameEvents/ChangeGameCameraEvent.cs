using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeGameCameraEvent : GameEvent {
    public CinemachineVirtualCameraBase gameCamera;
    public bool isBlendFinished;

    public ChangeGameCameraEvent(CinemachineVirtualCameraBase gameCam, bool isFinished) {
        gameCamera = gameCam;
        isBlendFinished = isFinished;
    }
}