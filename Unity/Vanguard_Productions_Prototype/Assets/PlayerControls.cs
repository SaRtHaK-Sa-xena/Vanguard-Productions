// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

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
            ""name"": ""Gameplay"",
            ""id"": ""59780bd4-0879-4fc0-9765-b11be1478e62"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3c4173be-f4e5-4efd-bc48-e19d57cc169f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""386067c0-239d-4090-b3ba-c1303d73d0aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LightAttack"",
                    ""type"": ""Button"",
                    ""id"": ""b77ed927-24b6-48f8-b05d-6015384019e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HeavyAttack"",
                    ""type"": ""Button"",
                    ""id"": ""ca22e65c-10b1-4a4d-b3ee-3d0351737391"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GrappleHook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""46ec852d-5a15-4323-88c1-abcac15c2a88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a876c327-8395-4a3d-8f8e-11d29fcf3ce0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5f23a62b-35df-413d-a743-6c08b3d0d643"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5aa2251b-87f1-476d-8954-7771d5343117"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""26835cd1-f91d-4f7b-8d30-d4ae95928827"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e810d0f5-a89a-4270-a34e-6307f8fcfa7b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7c9327f-66c9-4d72-8f07-eff864654916"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8432529-a3c5-4b75-b8c9-a780a2e8eb8d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrappleHook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Animation"",
            ""id"": ""f791a1aa-70f2-47d9-99c9-5ec5e465176b"",
            ""actions"": [
                {
                    ""name"": ""Running"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1a2930ad-4c74-4c9e-968e-996e4b2c2912"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""ed0bd864-6470-46d7-9c41-862a98a41a22"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""acb387c8-7bde-4899-8409-f2be9f173ea6"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3e7ebbf9-2f9d-459b-a72f-455337f6f064"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_LightAttack = m_Gameplay.FindAction("LightAttack", throwIfNotFound: true);
        m_Gameplay_HeavyAttack = m_Gameplay.FindAction("HeavyAttack", throwIfNotFound: true);
        m_Gameplay_GrappleHook = m_Gameplay.FindAction("GrappleHook", throwIfNotFound: true);
        // Animation
        m_Animation = asset.FindActionMap("Animation", throwIfNotFound: true);
        m_Animation_Running = m_Animation.FindAction("Running", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_LightAttack;
    private readonly InputAction m_Gameplay_HeavyAttack;
    private readonly InputAction m_Gameplay_GrappleHook;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @LightAttack => m_Wrapper.m_Gameplay_LightAttack;
        public InputAction @HeavyAttack => m_Wrapper.m_Gameplay_HeavyAttack;
        public InputAction @GrappleHook => m_Wrapper.m_Gameplay_GrappleHook;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @LightAttack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLightAttack;
                @LightAttack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLightAttack;
                @LightAttack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLightAttack;
                @HeavyAttack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHeavyAttack;
                @GrappleHook.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleHook;
                @GrappleHook.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleHook;
                @GrappleHook.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleHook;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LightAttack.started += instance.OnLightAttack;
                @LightAttack.performed += instance.OnLightAttack;
                @LightAttack.canceled += instance.OnLightAttack;
                @HeavyAttack.started += instance.OnHeavyAttack;
                @HeavyAttack.performed += instance.OnHeavyAttack;
                @HeavyAttack.canceled += instance.OnHeavyAttack;
                @GrappleHook.started += instance.OnGrappleHook;
                @GrappleHook.performed += instance.OnGrappleHook;
                @GrappleHook.canceled += instance.OnGrappleHook;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Animation
    private readonly InputActionMap m_Animation;
    private IAnimationActions m_AnimationActionsCallbackInterface;
    private readonly InputAction m_Animation_Running;
    public struct AnimationActions
    {
        private @PlayerControls m_Wrapper;
        public AnimationActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Running => m_Wrapper.m_Animation_Running;
        public InputActionMap Get() { return m_Wrapper.m_Animation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AnimationActions set) { return set.Get(); }
        public void SetCallbacks(IAnimationActions instance)
        {
            if (m_Wrapper.m_AnimationActionsCallbackInterface != null)
            {
                @Running.started -= m_Wrapper.m_AnimationActionsCallbackInterface.OnRunning;
                @Running.performed -= m_Wrapper.m_AnimationActionsCallbackInterface.OnRunning;
                @Running.canceled -= m_Wrapper.m_AnimationActionsCallbackInterface.OnRunning;
            }
            m_Wrapper.m_AnimationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Running.started += instance.OnRunning;
                @Running.performed += instance.OnRunning;
                @Running.canceled += instance.OnRunning;
            }
        }
    }
    public AnimationActions @Animation => new AnimationActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLightAttack(InputAction.CallbackContext context);
        void OnHeavyAttack(InputAction.CallbackContext context);
        void OnGrappleHook(InputAction.CallbackContext context);
    }
    public interface IAnimationActions
    {
        void OnRunning(InputAction.CallbackContext context);
    }
}
