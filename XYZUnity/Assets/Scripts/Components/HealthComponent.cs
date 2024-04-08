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


        public void ApplyDamage(int damageValue)
        {
            _health -= damageValue;
            _onDamage?.Invoke();
            if (_health <= 0)
                _onDie?.Invoke();
        }

        public void ApplyHeal(int heal)
        {
            _health += heal;
            _onHeal?.Invoke();
        }

    }
}
