// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/glossarioInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GlossarioInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GlossarioInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""glossarioInput"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""e3aea03e-6e1c-4b86-9d40-d32d7f9feb8e"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""9e8fbca4-2da1-405c-b472-bbe38132c29d"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Next"",
                    ""type"": ""Button"",
                    ""id"": ""fc8cf76d-0101-4289-ae98-8cf2824bad23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""b277bdf7-a8da-4a5e-8e5f-c18321d5e1d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""9d47d80e-f4e6-4082-92f6-c4b1bed31af7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9cd93cfd-4c42-44a4-82ac-f725c02679e2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d5327fe-b6e3-4a61-b127-fce5a2178ba4"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfb26b2f-6752-44f0-a384-f7d7b48b10bb"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e27d0b8e-9f0d-47be-b82c-4974657897a7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Rotate = m_Move.FindAction("Rotate", throwIfNotFound: true);
        m_Move_Next = m_Move.FindAction("Next", throwIfNotFound: true);
        m_Move_Back = m_Move.FindAction("Back", throwIfNotFound: true);
        m_Move_Return = m_Move.FindAction("Return", throwIfNotFound: true);
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

    // Move
    private readonly InputActionMap m_Move;
    private IMoveActions m_MoveActionsCallbackInterface;
    private readonly InputAction m_Move_Rotate;
    private readonly InputAction m_Move_Next;
    private readonly InputAction m_Move_Back;
    private readonly InputAction m_Move_Return;
    public struct MoveActions
    {
        private @GlossarioInput m_Wrapper;
        public MoveActions(@GlossarioInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Move_Rotate;
        public InputAction @Next => m_Wrapper.m_Move_Next;
        public InputAction @Back => m_Wrapper.m_Move_Back;
        public InputAction @Return => m_Wrapper.m_Move_Return;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnRotate;
                @Next.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnNext;
                @Next.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnNext;
                @Next.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnNext;
                @Back.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnBack;
                @Return.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnReturn;
                @Return.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnReturn;
                @Return.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnReturn;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Next.started += instance.OnNext;
                @Next.performed += instance.OnNext;
                @Next.canceled += instance.OnNext;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Return.started += instance.OnReturn;
                @Return.performed += instance.OnReturn;
                @Return.canceled += instance.OnReturn;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IMoveActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnNext(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnReturn(InputAction.CallbackContext context);
    }
}
