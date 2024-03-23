using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Controlling
{
    public class TriggerInputActionReference : MonoBehaviour
    {
        [Header("Button")]
        [SerializeField]
        [Tooltip("The input action reference to be triggered, only a bool action is supported.")]
        private InputActionReference inputActionReference;

        [SerializeField] [Tooltip("The event to be triggered when the input action reference is triggered.")]
        private UnityEvent inputActionReferenceTriggered;
        
        [SerializeField] [Tooltip("The event to be triggered when the input action reference is canceled.")]
        private UnityEvent inputActionReferenceCanceled; 

        void Update()
        {
            if (!isActiveAndEnabled) 
                return;

            if (inputActionReference.action.triggered)
            {
                inputActionReferenceTriggered.Invoke();
            }
            else
            {
                inputActionReferenceCanceled.Invoke();
            }
        }
    }
}