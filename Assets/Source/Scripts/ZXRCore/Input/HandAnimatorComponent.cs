using Source.Scripts.Core.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

namespace Source.Scripts.Core
{
    public class HandAnimatorComponent : BaseComponent
    {
        private Animator animator;
        [SerializeField] private InputActionProperty triggerAction;
        [SerializeField] private InputActionProperty gripAction;

        private const string Trigger = "Trigger";
        private const string Grip = "Grip";
        
        private void Awake()
        {
            InitComponentInGameObject(out animator);
        }

        private void OnEnable()
        {
            triggerAction.action.performed += HandleTrigger;
            gripAction.action.performed += HandleGrip;
        }

        private void OnDisable()
        {
            triggerAction.action.performed -= HandleTrigger;
            gripAction.action.performed -= HandleGrip;
        }

        private void HandleTrigger(InputAction.CallbackContext callbackContext)
        {
            animator.SetFloat(Trigger, triggerAction.action.ReadValue<float>());
        }

        private void HandleGrip(InputAction.CallbackContext callbackContext)
        {
            animator.SetFloat(Grip, gripAction.action.ReadValue<float>());
        }
    }
}