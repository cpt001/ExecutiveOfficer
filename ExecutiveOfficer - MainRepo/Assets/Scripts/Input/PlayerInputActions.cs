// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""ShipControl"",
            ""id"": ""d652b6c1-5a87-4138-ac84-ff0f2603fd00"",
            ""actions"": [
                {
                    ""name"": ""Thrust"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f53a7fa5-2ab4-4ea7-a26a-d765b644c2f9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pitch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8964a704-51cf-43d5-9c9b-faabc69bac33"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a86d3ec9-bba4-45b3-bbbb-6d6af56288fc"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Yaw"",
                    ""type"": ""PassThrough"",
                    ""id"": ""92129503-aed3-4613-8fc7-0edeb85249f2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""edc35362-c2c9-4ad8-ac0f-409138ad7bb6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleTargetingMode"",
                    ""type"": ""Button"",
                    ""id"": ""0cf14897-b0fe-44e1-92b2-1fb70e3cf406"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleTurretGroups"",
                    ""type"": ""Button"",
                    ""id"": ""351a557c-ffce-4efd-9c75-d6a6aa19a7b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockTarget"",
                    ""type"": ""Button"",
                    ""id"": ""93599924-5468-4350-9789-248dcdbb0dec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup1"",
                    ""type"": ""Button"",
                    ""id"": ""c81c6a6d-ef63-4d9c-9a08-ebe3c17b2aec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup2"",
                    ""type"": ""Button"",
                    ""id"": ""f44d8abf-a79d-4659-b7c6-dbe57ac1716c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup3"",
                    ""type"": ""Button"",
                    ""id"": ""9bdffeb2-aa52-4e30-afd9-22eedee1303c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup4"",
                    ""type"": ""Button"",
                    ""id"": ""0b699402-9729-43c2-b69b-c490b9a25405"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup5"",
                    ""type"": ""Button"",
                    ""id"": ""74d5763e-90ae-4898-94aa-b58001961f45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup6"",
                    ""type"": ""Button"",
                    ""id"": ""f88fd3d8-42b5-4682-b306-2df7a1b9d34b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup7"",
                    ""type"": ""Button"",
                    ""id"": ""51101dfe-3ff7-4a5d-8f40-4ff833ed0851"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup8"",
                    ""type"": ""Button"",
                    ""id"": ""e54ba271-bdb6-4d7f-870b-c9d7cb8937ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup9"",
                    ""type"": ""Button"",
                    ""id"": ""9810e345-fe0d-4fdb-9c07-51da968d4292"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectTurretGroup10"",
                    ""type"": ""Button"",
                    ""id"": ""8cc3327c-f74c-45d8-9a1a-07689cd027a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""958a9c03-1022-43e9-b9e5-e1770de62c09"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""aebb3a31-d7cd-44f4-b23c-49dfcb5167c1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ed1434db-760b-4ee9-b81f-227043cd9b9d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""99f00694-b2c7-42e7-9495-58d40c0d1271"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0b1c8ca9-ac13-424f-80e4-785f7bc3ae37"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4cbfea6e-816f-4a3b-8cc0-b748e68804de"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""bf455fc4-227a-478f-b3de-359a9588d18d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3d94bce1-ac53-44b2-9e46-611f6913db22"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""03fb0178-c3fb-402b-8100-bd02be624806"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d74a3458-a692-4cb6-92af-848af1d078ce"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""87c7649b-8282-44b6-883e-0b4d36128ea9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""880e7398-13e9-48fb-ba6e-ae53a03fea2f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3ea7d445-0196-424b-826b-a25bbc2e9bd1"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf30efec-5d35-49a4-adef-bdd75b892fb6"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleTargetingMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30672735-2ea5-453b-a198-4983c4c9e2b0"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleTurretGroups"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06ef2936-6539-49c1-96d3-e2db7a2b77ed"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adf5fffd-c7cc-4c9b-a316-bfc5a20fd3c9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a59b8e1-f89f-4245-acd5-1ae36e7fb87e"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6d39dde-fe56-49f1-9312-fdf62f8764b2"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ce35fb4-2166-46c8-a746-7890ae5e07bb"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e845b908-a2df-4625-b97f-38bfb03fa36f"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56b05255-1c1c-4221-aea5-4a6ca905ac2d"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30dd77f2-e250-4cf9-a54c-247a38b2757d"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f66e50f7-1325-4c74-9dfc-b3bdb63a8272"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15b84d73-6ff5-4902-8fd4-740abf47ada2"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94326a19-5336-45f5-b59c-a77c19c6c0a3"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTurretGroup10"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ShipControl
        m_ShipControl = asset.FindActionMap("ShipControl", throwIfNotFound: true);
        m_ShipControl_Thrust = m_ShipControl.FindAction("Thrust", throwIfNotFound: true);
        m_ShipControl_Pitch = m_ShipControl.FindAction("Pitch", throwIfNotFound: true);
        m_ShipControl_Roll = m_ShipControl.FindAction("Roll", throwIfNotFound: true);
        m_ShipControl_Yaw = m_ShipControl.FindAction("Yaw", throwIfNotFound: true);
        m_ShipControl_CameraLook = m_ShipControl.FindAction("CameraLook", throwIfNotFound: true);
        m_ShipControl_ToggleTargetingMode = m_ShipControl.FindAction("ToggleTargetingMode", throwIfNotFound: true);
        m_ShipControl_CycleTurretGroups = m_ShipControl.FindAction("CycleTurretGroups", throwIfNotFound: true);
        m_ShipControl_LockTarget = m_ShipControl.FindAction("LockTarget", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup1 = m_ShipControl.FindAction("SelectTurretGroup1", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup2 = m_ShipControl.FindAction("SelectTurretGroup2", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup3 = m_ShipControl.FindAction("SelectTurretGroup3", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup4 = m_ShipControl.FindAction("SelectTurretGroup4", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup5 = m_ShipControl.FindAction("SelectTurretGroup5", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup6 = m_ShipControl.FindAction("SelectTurretGroup6", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup7 = m_ShipControl.FindAction("SelectTurretGroup7", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup8 = m_ShipControl.FindAction("SelectTurretGroup8", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup9 = m_ShipControl.FindAction("SelectTurretGroup9", throwIfNotFound: true);
        m_ShipControl_SelectTurretGroup10 = m_ShipControl.FindAction("SelectTurretGroup10", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // ShipControl
    private readonly InputActionMap m_ShipControl;
    private IShipControlActions m_ShipControlActionsCallbackInterface;
    private readonly InputAction m_ShipControl_Thrust;
    private readonly InputAction m_ShipControl_Pitch;
    private readonly InputAction m_ShipControl_Roll;
    private readonly InputAction m_ShipControl_Yaw;
    private readonly InputAction m_ShipControl_CameraLook;
    private readonly InputAction m_ShipControl_ToggleTargetingMode;
    private readonly InputAction m_ShipControl_CycleTurretGroups;
    private readonly InputAction m_ShipControl_LockTarget;
    private readonly InputAction m_ShipControl_SelectTurretGroup1;
    private readonly InputAction m_ShipControl_SelectTurretGroup2;
    private readonly InputAction m_ShipControl_SelectTurretGroup3;
    private readonly InputAction m_ShipControl_SelectTurretGroup4;
    private readonly InputAction m_ShipControl_SelectTurretGroup5;
    private readonly InputAction m_ShipControl_SelectTurretGroup6;
    private readonly InputAction m_ShipControl_SelectTurretGroup7;
    private readonly InputAction m_ShipControl_SelectTurretGroup8;
    private readonly InputAction m_ShipControl_SelectTurretGroup9;
    private readonly InputAction m_ShipControl_SelectTurretGroup10;
    public struct ShipControlActions
    {
        private @PlayerInputActions m_Wrapper;
        public ShipControlActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Thrust => m_Wrapper.m_ShipControl_Thrust;
        public InputAction @Pitch => m_Wrapper.m_ShipControl_Pitch;
        public InputAction @Roll => m_Wrapper.m_ShipControl_Roll;
        public InputAction @Yaw => m_Wrapper.m_ShipControl_Yaw;
        public InputAction @CameraLook => m_Wrapper.m_ShipControl_CameraLook;
        public InputAction @ToggleTargetingMode => m_Wrapper.m_ShipControl_ToggleTargetingMode;
        public InputAction @CycleTurretGroups => m_Wrapper.m_ShipControl_CycleTurretGroups;
        public InputAction @LockTarget => m_Wrapper.m_ShipControl_LockTarget;
        public InputAction @SelectTurretGroup1 => m_Wrapper.m_ShipControl_SelectTurretGroup1;
        public InputAction @SelectTurretGroup2 => m_Wrapper.m_ShipControl_SelectTurretGroup2;
        public InputAction @SelectTurretGroup3 => m_Wrapper.m_ShipControl_SelectTurretGroup3;
        public InputAction @SelectTurretGroup4 => m_Wrapper.m_ShipControl_SelectTurretGroup4;
        public InputAction @SelectTurretGroup5 => m_Wrapper.m_ShipControl_SelectTurretGroup5;
        public InputAction @SelectTurretGroup6 => m_Wrapper.m_ShipControl_SelectTurretGroup6;
        public InputAction @SelectTurretGroup7 => m_Wrapper.m_ShipControl_SelectTurretGroup7;
        public InputAction @SelectTurretGroup8 => m_Wrapper.m_ShipControl_SelectTurretGroup8;
        public InputAction @SelectTurretGroup9 => m_Wrapper.m_ShipControl_SelectTurretGroup9;
        public InputAction @SelectTurretGroup10 => m_Wrapper.m_ShipControl_SelectTurretGroup10;
        public InputActionMap Get() { return m_Wrapper.m_ShipControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipControlActions set) { return set.Get(); }
        public void SetCallbacks(IShipControlActions instance)
        {
            if (m_Wrapper.m_ShipControlActionsCallbackInterface != null)
            {
                @Thrust.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnThrust;
                @Thrust.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnThrust;
                @Thrust.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnThrust;
                @Pitch.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnPitch;
                @Pitch.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnPitch;
                @Pitch.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnPitch;
                @Roll.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnRoll;
                @Yaw.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnYaw;
                @Yaw.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnYaw;
                @Yaw.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnYaw;
                @CameraLook.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnCameraLook;
                @CameraLook.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnCameraLook;
                @CameraLook.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnCameraLook;
                @ToggleTargetingMode.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnToggleTargetingMode;
                @ToggleTargetingMode.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnToggleTargetingMode;
                @ToggleTargetingMode.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnToggleTargetingMode;
                @CycleTurretGroups.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnCycleTurretGroups;
                @CycleTurretGroups.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnCycleTurretGroups;
                @CycleTurretGroups.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnCycleTurretGroups;
                @LockTarget.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnLockTarget;
                @LockTarget.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnLockTarget;
                @LockTarget.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnLockTarget;
                @SelectTurretGroup1.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup1;
                @SelectTurretGroup1.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup1;
                @SelectTurretGroup1.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup1;
                @SelectTurretGroup2.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup2;
                @SelectTurretGroup2.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup2;
                @SelectTurretGroup2.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup2;
                @SelectTurretGroup3.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup3;
                @SelectTurretGroup3.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup3;
                @SelectTurretGroup3.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup3;
                @SelectTurretGroup4.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup4;
                @SelectTurretGroup4.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup4;
                @SelectTurretGroup4.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup4;
                @SelectTurretGroup5.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup5;
                @SelectTurretGroup5.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup5;
                @SelectTurretGroup5.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup5;
                @SelectTurretGroup6.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup6;
                @SelectTurretGroup6.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup6;
                @SelectTurretGroup6.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup6;
                @SelectTurretGroup7.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup7;
                @SelectTurretGroup7.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup7;
                @SelectTurretGroup7.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup7;
                @SelectTurretGroup8.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup8;
                @SelectTurretGroup8.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup8;
                @SelectTurretGroup8.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup8;
                @SelectTurretGroup9.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup9;
                @SelectTurretGroup9.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup9;
                @SelectTurretGroup9.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup9;
                @SelectTurretGroup10.started -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup10;
                @SelectTurretGroup10.performed -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup10;
                @SelectTurretGroup10.canceled -= m_Wrapper.m_ShipControlActionsCallbackInterface.OnSelectTurretGroup10;
            }
            m_Wrapper.m_ShipControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Thrust.started += instance.OnThrust;
                @Thrust.performed += instance.OnThrust;
                @Thrust.canceled += instance.OnThrust;
                @Pitch.started += instance.OnPitch;
                @Pitch.performed += instance.OnPitch;
                @Pitch.canceled += instance.OnPitch;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Yaw.started += instance.OnYaw;
                @Yaw.performed += instance.OnYaw;
                @Yaw.canceled += instance.OnYaw;
                @CameraLook.started += instance.OnCameraLook;
                @CameraLook.performed += instance.OnCameraLook;
                @CameraLook.canceled += instance.OnCameraLook;
                @ToggleTargetingMode.started += instance.OnToggleTargetingMode;
                @ToggleTargetingMode.performed += instance.OnToggleTargetingMode;
                @ToggleTargetingMode.canceled += instance.OnToggleTargetingMode;
                @CycleTurretGroups.started += instance.OnCycleTurretGroups;
                @CycleTurretGroups.performed += instance.OnCycleTurretGroups;
                @CycleTurretGroups.canceled += instance.OnCycleTurretGroups;
                @LockTarget.started += instance.OnLockTarget;
                @LockTarget.performed += instance.OnLockTarget;
                @LockTarget.canceled += instance.OnLockTarget;
                @SelectTurretGroup1.started += instance.OnSelectTurretGroup1;
                @SelectTurretGroup1.performed += instance.OnSelectTurretGroup1;
                @SelectTurretGroup1.canceled += instance.OnSelectTurretGroup1;
                @SelectTurretGroup2.started += instance.OnSelectTurretGroup2;
                @SelectTurretGroup2.performed += instance.OnSelectTurretGroup2;
                @SelectTurretGroup2.canceled += instance.OnSelectTurretGroup2;
                @SelectTurretGroup3.started += instance.OnSelectTurretGroup3;
                @SelectTurretGroup3.performed += instance.OnSelectTurretGroup3;
                @SelectTurretGroup3.canceled += instance.OnSelectTurretGroup3;
                @SelectTurretGroup4.started += instance.OnSelectTurretGroup4;
                @SelectTurretGroup4.performed += instance.OnSelectTurretGroup4;
                @SelectTurretGroup4.canceled += instance.OnSelectTurretGroup4;
                @SelectTurretGroup5.started += instance.OnSelectTurretGroup5;
                @SelectTurretGroup5.performed += instance.OnSelectTurretGroup5;
                @SelectTurretGroup5.canceled += instance.OnSelectTurretGroup5;
                @SelectTurretGroup6.started += instance.OnSelectTurretGroup6;
                @SelectTurretGroup6.performed += instance.OnSelectTurretGroup6;
                @SelectTurretGroup6.canceled += instance.OnSelectTurretGroup6;
                @SelectTurretGroup7.started += instance.OnSelectTurretGroup7;
                @SelectTurretGroup7.performed += instance.OnSelectTurretGroup7;
                @SelectTurretGroup7.canceled += instance.OnSelectTurretGroup7;
                @SelectTurretGroup8.started += instance.OnSelectTurretGroup8;
                @SelectTurretGroup8.performed += instance.OnSelectTurretGroup8;
                @SelectTurretGroup8.canceled += instance.OnSelectTurretGroup8;
                @SelectTurretGroup9.started += instance.OnSelectTurretGroup9;
                @SelectTurretGroup9.performed += instance.OnSelectTurretGroup9;
                @SelectTurretGroup9.canceled += instance.OnSelectTurretGroup9;
                @SelectTurretGroup10.started += instance.OnSelectTurretGroup10;
                @SelectTurretGroup10.performed += instance.OnSelectTurretGroup10;
                @SelectTurretGroup10.canceled += instance.OnSelectTurretGroup10;
            }
        }
    }
    public ShipControlActions @ShipControl => new ShipControlActions(this);
    public interface IShipControlActions
    {
        void OnThrust(InputAction.CallbackContext context);
        void OnPitch(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnYaw(InputAction.CallbackContext context);
        void OnCameraLook(InputAction.CallbackContext context);
        void OnToggleTargetingMode(InputAction.CallbackContext context);
        void OnCycleTurretGroups(InputAction.CallbackContext context);
        void OnLockTarget(InputAction.CallbackContext context);
        void OnSelectTurretGroup1(InputAction.CallbackContext context);
        void OnSelectTurretGroup2(InputAction.CallbackContext context);
        void OnSelectTurretGroup3(InputAction.CallbackContext context);
        void OnSelectTurretGroup4(InputAction.CallbackContext context);
        void OnSelectTurretGroup5(InputAction.CallbackContext context);
        void OnSelectTurretGroup6(InputAction.CallbackContext context);
        void OnSelectTurretGroup7(InputAction.CallbackContext context);
        void OnSelectTurretGroup8(InputAction.CallbackContext context);
        void OnSelectTurretGroup9(InputAction.CallbackContext context);
        void OnSelectTurretGroup10(InputAction.CallbackContext context);
    }
}
