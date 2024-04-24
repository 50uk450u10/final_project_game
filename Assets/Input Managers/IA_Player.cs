//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input Managers/IA_Player.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @IA_Player: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @IA_Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""IA_Player"",
    ""maps"": [
        {
            ""name"": ""SettingsMenu"",
            ""id"": ""76bc4833-cfa3-4140-859c-19c54e2ef49e"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""52e1b9a3-2b4b-44b7-88b8-5b932aa4a575"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4b92d2ad-08ac-4ece-b9f6-1188393099cf"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SettingsMenu
        m_SettingsMenu = asset.FindActionMap("SettingsMenu", throwIfNotFound: true);
        m_SettingsMenu_Escape = m_SettingsMenu.FindAction("Escape", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // SettingsMenu
    private readonly InputActionMap m_SettingsMenu;
    private List<ISettingsMenuActions> m_SettingsMenuActionsCallbackInterfaces = new List<ISettingsMenuActions>();
    private readonly InputAction m_SettingsMenu_Escape;
    public struct SettingsMenuActions
    {
        private @IA_Player m_Wrapper;
        public SettingsMenuActions(@IA_Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_SettingsMenu_Escape;
        public InputActionMap Get() { return m_Wrapper.m_SettingsMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SettingsMenuActions set) { return set.Get(); }
        public void AddCallbacks(ISettingsMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_SettingsMenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SettingsMenuActionsCallbackInterfaces.Add(instance);
            @Escape.started += instance.OnEscape;
            @Escape.performed += instance.OnEscape;
            @Escape.canceled += instance.OnEscape;
        }

        private void UnregisterCallbacks(ISettingsMenuActions instance)
        {
            @Escape.started -= instance.OnEscape;
            @Escape.performed -= instance.OnEscape;
            @Escape.canceled -= instance.OnEscape;
        }

        public void RemoveCallbacks(ISettingsMenuActions instance)
        {
            if (m_Wrapper.m_SettingsMenuActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISettingsMenuActions instance)
        {
            foreach (var item in m_Wrapper.m_SettingsMenuActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SettingsMenuActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SettingsMenuActions @SettingsMenu => new SettingsMenuActions(this);
    public interface ISettingsMenuActions
    {
        void OnEscape(InputAction.CallbackContext context);
    }
}