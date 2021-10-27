// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""dd3396f4-387f-49c3-9b61-02a68aed85a6"",
            ""actions"": [
                {
                    ""name"": ""Thrust"",
                    ""type"": ""PassThrough"",
                    ""id"": ""db32e5d2-4033-4d93-8e84-2fb40071c1f8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Detach"",
                    ""type"": ""PassThrough"",
                    ""id"": ""71dac647-0875-4f02-8a6f-6ff2a419c90b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Parachute"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8a0e1a4b-0e96-444a-819f-9f043c841af1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ce149eb9-ba5b-46b5-9137-c5ca1ce662de"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96170e4f-a2f6-4428-9279-599c440a7ac7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Detach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bcd1ddd-1bda-44ca-a8b7-ac3836c1d2cf"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Parachute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Thrust = m_Keyboard.FindAction("Thrust", throwIfNotFound: true);
        m_Keyboard_Detach = m_Keyboard.FindAction("Detach", throwIfNotFound: true);
        m_Keyboard_Parachute = m_Keyboard.FindAction("Parachute", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_Thrust;
    private readonly InputAction m_Keyboard_Detach;
    private readonly InputAction m_Keyboard_Parachute;
    public struct KeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public KeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Thrust => m_Wrapper.m_Keyboard_Thrust;
        public InputAction @Detach => m_Wrapper.m_Keyboard_Detach;
        public InputAction @Parachute => m_Wrapper.m_Keyboard_Parachute;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Thrust.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnThrust;
                @Thrust.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnThrust;
                @Thrust.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnThrust;
                @Detach.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDetach;
                @Detach.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDetach;
                @Detach.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDetach;
                @Parachute.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnParachute;
                @Parachute.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnParachute;
                @Parachute.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnParachute;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Thrust.started += instance.OnThrust;
                @Thrust.performed += instance.OnThrust;
                @Thrust.canceled += instance.OnThrust;
                @Detach.started += instance.OnDetach;
                @Detach.performed += instance.OnDetach;
                @Detach.canceled += instance.OnDetach;
                @Parachute.started += instance.OnParachute;
                @Parachute.performed += instance.OnParachute;
                @Parachute.canceled += instance.OnParachute;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IKeyboardActions
    {
        void OnThrust(InputAction.CallbackContext context);
        void OnDetach(InputAction.CallbackContext context);
        void OnParachute(InputAction.CallbackContext context);
    }
}
