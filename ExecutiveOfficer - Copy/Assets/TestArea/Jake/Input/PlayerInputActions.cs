// GENERATED AUTOMATICALLY FROM 'Assets/TestArea/Jake/Input/PlayerInputActions.inputactions'

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
    }
}
