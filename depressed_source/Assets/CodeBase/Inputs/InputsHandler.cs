using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Inputs
{
    public static class InputsHandler
    {
        public static bool IsRightButtonPressed => Controls.Global.LeftMouseButton.IsPressed();
        public static Vector2 Movement => Controls.Player.Movement.ReadValue<Vector2>();

        public static bool ISUIMODE => !Controls.Player.enabled;

        public static event Action OnLeftMouseButtonDown;
        public static event Action OnLeftMouseButtonUp;
        public static event Action OnInteracted;
        public static event Action OnAttack;
        
        private static readonly Controls Controls;
        
        static InputsHandler()
        {
            Controls = new Controls();
            
            Controls.Global.LeftMouseButton.performed += RightMouseButtonPerformed;
            Controls.Global.LeftMouseButton.canceled += RightMouseButtonCanceled;
            Controls.Player.Interacted.performed += Interacted;
            Controls.Player.Attack.performed += Attack;
            
            Controls.Enable();
        }

        private static void Attack(InputAction.CallbackContext obj)
        {
            OnAttack?.Invoke();
        }

        private static void Interacted(InputAction.CallbackContext context)
        {
            OnInteracted?.Invoke();
        }

        public static void EnterUIMode()
        {
            Controls.Player.Disable();
        }

        public static void EnterPlayerMode()
        {
            Controls.Player.Enable();
        }
        
        private static void RightMouseButtonPerformed(InputAction.CallbackContext context)
        {
            OnLeftMouseButtonDown?.Invoke();
        }
        private static void RightMouseButtonCanceled(InputAction.CallbackContext context)
        {
            OnLeftMouseButtonUp?.Invoke();
        }
    }
}