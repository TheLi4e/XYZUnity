﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
            if (context.performed)
                _hero.Throw();
        }

        public void OnUsePotion(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.UsePotion();
        }

        public void OnNextItem(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.NextItem();
        }
    }
}

