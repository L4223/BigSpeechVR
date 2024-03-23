// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.XR;
//  
// namespace Controlling
// {
//     public class ButtonController : MonoBehaviour
//     {
//         static readonly Dictionary<string, InputFeatureUsage<bool>> AvailableButtons = new Dictionary<string, InputFeatureUsage<bool>>
//         {
//             {"triggerButton", CommonUsages.triggerButton },
//             {"primary2DAxisClick", CommonUsages.primary2DAxisClick },
//             {"primary2DAxisTouch", CommonUsages.primary2DAxisTouch },
//             {"menuButton", CommonUsages.menuButton },
//             {"gripButton", CommonUsages.gripButton },
//             {"secondaryButton", CommonUsages.secondaryButton },
//             {"secondaryTouch", CommonUsages.secondaryTouch },
//             {"primaryButton", CommonUsages.primaryButton },
//             {"primaryTouch", CommonUsages.primaryTouch },
//         };
//  
//         public enum ButtonOption
//         {
//             TriggerButton,
//             Primary2DAxisClick,
//             Primary2DAxisTouch,
//             MenuButton,
//             GripButton,
//             SecondaryButton,
//             SecondaryTouch,
//             PrimaryButton,
//             PrimaryTouch
//         };
//  
//         [Tooltip("Input device role (left or right controller)")]
//         public InputDeviceRole deviceRole;
//        
//         [Tooltip("Select the button")]
//         public ButtonOption button;
//  
//         [Tooltip("Event when the button starts being pressed")]
//         public UnityEvent onPress;
//  
//         [Tooltip("Event when the button is released")]
//         public UnityEvent onRelease;
//  
//         // to check whether it's being pressed
//         public bool IsPressed { get; private set; }
//  
//         // to obtain input devices
//         List<InputDevice> _inputDevices;
//         bool _inputValue;
//  
//         InputFeatureUsage<bool> _inputFeature;
//  
//         void Awake()
//         {
//             // get label selected by the user
//             string featureLabel = Enum.GetName(typeof(ButtonOption), button);
//  
//             // find dictionary entry
//             if (featureLabel != null) AvailableButtons.TryGetValue(featureLabel, out _inputFeature);
//
//             // init list
//             _inputDevices = new List<InputDevice>();
//         }
//  
//
//         void Update()
//         {
//             InputDevices.GetDevicesWithCharacteristics(deviceRole, _inputDevices);
//  
//             for (int i = 0; i < _inputDevices.Count; i++)
//             {
//                 if (_inputDevices[i].TryGetFeatureValue(_inputFeature,
//                     out _inputValue) && _inputValue)
//                 {
//                     // if start pressing, trigger event
//                     if (!IsPressed)
//                     {
//                         IsPressed = true;
//                         onPress.Invoke();
//                     }
//                 }
//  
//                 // check for button release
//                 else if (IsPressed)
//                 {
//                     IsPressed = false;
//                     onRelease.Invoke();
//                 }
//             }
//         }
//     }
// }