using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;


        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.Inreact();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.Attack();
        }

        public void OnThrow(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _hero.StartThrowing();
            }

            if (context.canceled)
            {
                _hero.UseInventory();
            }
        }

        public void OnUsePotion(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.UsePotion();
        }

        public void OnNextQuickItem(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.QuickInvNextItem();
        }

        public void OnNextInvItem(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.InvNextItem();
        }

        public void OnUseLeapPerk(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.UseLeap();
        }
    }
}

