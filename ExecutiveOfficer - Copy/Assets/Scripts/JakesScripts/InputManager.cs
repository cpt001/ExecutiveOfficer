using UnityEngine;

public class InputManager : MonoBehaviour {
    private PlayerInputActions playerControls;

    private void Awake() {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    public float GetThrust() {
        return playerControls.ShipControl.Thrust.ReadValue<float>();
    }

    public float GetPitch() {
        return playerControls.ShipControl.Thrust.ReadValue<float>();
    }

    public float GetRoll() {
        return playerControls.ShipControl.Thrust.ReadValue<float>();
    }

    public float GetYaw() {
        return playerControls.ShipControl.Thrust.ReadValue<float>();
    }

    public Vector2 GetMouseDelta() {
        return playerControls.ShipControl.CameraLook.ReadValue<Vector2>();
    }
}