using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameStart : MonoBehaviour {
    private void Start() {
        Init();
    }

    private void Init() {
        Events.instance.Raise(new EnterFlightEvent());
    }
}