using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    public void OnHorizontalMovement(InputValue context)
    {
        var direction = context.Get<float>();
        _hero.SetDirection(direction);
    }

    public void SaySomething(InputValue context)
    {
        _hero.SaySomething();
    }
}
