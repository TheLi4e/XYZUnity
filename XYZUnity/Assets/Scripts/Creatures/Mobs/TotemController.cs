using Scripts.Components;
using Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Creatures.Mobs
{
    public class TotemController :MonoBehaviour
    {
        [SerializeField] private List<ShootingTrapAI> _traps;
        [SerializeField] private Cooldown _cooldown;

        private int _currentTrap;

        private void Start()
        {
            foreach (var trap in _traps)
            {
                trap.enabled = false;
                var hp =trap.GetComponent<HealthComponent>();
                hp._onDie.AddListener(() => OnTrapDead(trap));
            }
        }

        private void OnTrapDead(ShootingTrapAI shootingTrapAI)
        {
            var index = _traps.IndexOf(shootingTrapAI);
            _traps.Remove(shootingTrapAI);
            if (index <= _currentTrap)
            {
                _currentTrap--;
            }
        }

        private void Update()
        {
            if (_traps.Count ==0)
            {
                enabled = false;
                Destroy(gameObject, 1f);
            }
            var hasTarget = _traps.Any(trap => trap._vision.IsTouchingLayer);

            if (hasTarget)
            {
                if (_cooldown.IsReady)
                {
                    _traps[_currentTrap].Shoot();
                    _cooldown.Reset();
                    _currentTrap = (int) Mathf.Repeat(_currentTrap+1, _traps.Count);

                }
            }
        }
    }
}
