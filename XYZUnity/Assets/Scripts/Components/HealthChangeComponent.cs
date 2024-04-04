using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    internal class HealthChangeComponent : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _heal;

        public void ApplyDamage(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.ApplyDamage(_damage);
            }
        }

        public void ApplyHeal(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            healthComponent.ApplyHeal(_heal);
        }
    }
}