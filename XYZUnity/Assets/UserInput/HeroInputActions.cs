// GENERATED AUTOMATICALLY FROM 'Assets/UserInput/HeroInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @HeroInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @HeroInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""HeroInputActions"",
    ""maps"": [
        {
            ""name"": ""Hero"",
            ""id"": ""93380603-5731-42bc-9a1d-1bb40c09553b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d8bc7b1c-bbe5-4daf-bf71-12bf6e5c264e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""fedae92b-8ad7-4725-9b1c-4fefad0abb91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""9c9564c8-d1f4-48cb-a4d9-b1efa65e5b6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""ac1876ea-121d-48f8-a0b7-0ccb82c3f729"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heal"",
                    ""type"": ""Button"",
                    ""id"": ""86ff140d-b243-4b4f-afc2-f6dd044a0362"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""QuickNextItem"",
                    ""type"": ""Button"",
                    ""id"": ""72540c92-e34a-4c8b-b8bb-83cc7168fc36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvNextItem"",
                    ""type"": ""Button"",
                    ""id"": ""573dad94-4bfb-43b1-adb4-fce8ef976dc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeapPerk"",
                    ""type"": ""Button"",
                    ""id"": ""25497250-b5af-4de5-8a4e-9cb88e24349f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ec5d46a5-6d3d-4c94-a996-1898bddb5ab8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0ca83682-189f-40bf-894a-f0b174c7fb53"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6554dce6-d175-48b1-b87e-92cb84b46830"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5d2ab4d1-bc70-4adc-a5d9-b91df2ade0aa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""011d435c-f00c-447d-9681-0c30ed09952c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""265eaeac-f2a7-4359-b4cc-b0056a444d7e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32b77b88-8036-4232-8b66-2b8404aca5cd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7962b369-b91c-4954-927a-1dfa12db1555"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""843b40b3-6efe-478f-935c-cf2ac6f09e4f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3214ef16-cdeb-4633-9184-a824c096368e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickNextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16d53693-35e7-46fb-a521-1b28a84b1b3d"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InvNextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6579a80-0671-438f-be8c-c303a99b7c34"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeapPerk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hero
        m_Hero = asset.FindActionMap("Hero", throwIfNotFound: true);
        m_Hero_Move = m_Hero.FindAction("Move", throwIfNotFound: true);
        m_Hero_Interact = m_Hero.FindAction("Interact", throwIfNotFound: true);
        m_Hero_Attack = m_Hero.FindAction("Attack", throwIfNotFound: true);
        m_Hero_Throw = m_Hero.FindAction("Throw", throwIfNotFound: true);
        m_Hero_Heal = m_Hero.FindAction("Heal", throwIfNotFound: true);
        m_Hero_QuickNextItem = m_Hero.FindAction("QuickNextItem", throwIfNotFound: true);
        m_Hero_InvNextItem = m_Hero.FindAction("InvNextItem", throwIfNotFound: true);
        m_Hero_LeapPerk = m_Hero.FindAction("LeapPerk", throwIfNotFound: true);
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

    // Hero
    private readonly InputActionMap m_Hero;
    private IHeroActions m_HeroActionsCallbackInterface;
    private readonly InputAction m_Hero_Move;
    private readonly InputAction m_Hero_Interact;
    private readonly InputAction m_Hero_Attack;
    private readonly InputAction m_Hero_Throw;
    private readonly InputAction m_Hero_Heal;
    private readonly InputAction m_Hero_QuickNextItem;
    private readonly InputAction m_Hero_InvNextItem;
    private readonly InputAction m_Hero_LeapPerk;
    public struct HeroActions
    {
        private @HeroInputActions m_Wrapper;
        public HeroActions(@HeroInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Hero_Move;
        public InputAction @Interact => m_Wrapper.m_Hero_Interact;
        public InputAction @Attack => m_Wrapper.m_Hero_Attack;
        public InputAction @Throw => m_Wrapper.m_Hero_Throw;
        public InputAction @Heal => m_Wrapper.m_Hero_Heal;
        public InputAction @QuickNextItem => m_Wrapper.m_Hero_QuickNextItem;
        public InputAction @InvNextItem => m_Wrapper.m_Hero_InvNextItem;
        public InputAction @LeapPerk => m_Wrapper.m_Hero_LeapPerk;
        public InputActionMap Get() { return m_Wrapper.m_Hero; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HeroActions set) { return set.Get(); }
        public void SetCallbacks(IHeroActions instance)
        {
            if (m_Wrapper.m_HeroActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnInteract;
                @Attack.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnAttack;
                @Throw.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnThrow;
                @Heal.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnHeal;
                @Heal.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnHeal;
                @Heal.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnHeal;
                @QuickNextItem.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnQuickNextItem;
                @QuickNextItem.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnQuickNextItem;
                @QuickNextItem.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnQuickNextItem;
                @InvNextItem.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnInvNextItem;
                @InvNextItem.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnInvNextItem;
                @InvNextItem.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnInvNextItem;
                @LeapPerk.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnLeapPerk;
                @LeapPerk.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnLeapPerk;
                @LeapPerk.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnLeapPerk;
            }
            m_Wrapper.m_HeroActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @Heal.started += instance.OnHeal;
                @Heal.performed += instance.OnHeal;
                @Heal.canceled += instance.OnHeal;
                @QuickNextItem.started += instance.OnQuickNextItem;
                @QuickNextItem.performed += instance.OnQuickNextItem;
                @QuickNextItem.canceled += instance.OnQuickNextItem;
                @InvNextItem.started += instance.OnInvNextItem;
                @InvNextItem.performed += instance.OnInvNextItem;
                @InvNextItem.canceled += instance.OnInvNextItem;
                @LeapPerk.started += instance.OnLeapPerk;
                @LeapPerk.performed += instance.OnLeapPerk;
                @LeapPerk.canceled += instance.OnLeapPerk;
            }
        }
    }
    public HeroActions @Hero => new HeroActions(this);
    public interface IHeroActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
        void OnQuickNextItem(InputAction.CallbackContext context);
        void OnInvNextItem(InputAction.CallbackContext context);
        void OnLeapPerk(InputAction.CallbackContext context);
    }
}
