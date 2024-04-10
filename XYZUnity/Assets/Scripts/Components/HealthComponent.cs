using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    internal class HealthComponent : MonoBehaviour
    {
        [SerializeField] public int _health;

        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private HealthChangeEvent _onChange;

        //public void ApplyDamage(int damageValue)
        //{
        //    _health -= damageValue;
        //    _onDamage?.Invoke();
        //    if (_health <= 0)
        //        _onDie?.Invoke();
        //}

        //public void ApplyHeal(int heal)
        //{
        //    _health += heal;
        //    _onHeal?.Invoke();
        //}

        public void ModifyHealth(int healthDelta)
        {
            _health += healthDelta;
            _onChange?.Invoke(_health);
            if (healthDelta < 0)
            {
                _onDamage?.Invoke();
            }

            if (healthDelta > 0)
            {
                _onHeal?.Invoke();
            }

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }

        internal void SetHealth(int health)
        {
           _health = health;
        }

        [Serializable]
        public class HealthChangeEvent : UnityEvent<int>
        {

        }

    }
}
