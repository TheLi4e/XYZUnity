using Scripts.Utils;
using System;
using UnityEditor.Build;
using UnityEngine;

namespace Scripts.Creatures.Mobs
{
    public class ShootingTrapAI : MonoBehaviour
    {
        [SerializeField] public LayerCheck _vision;
        [SerializeField] private Cooldown _cooldown;
        [SerializeField] private SpriteAnimation _animation;

        private void Update()
        {
            if (_vision.IsTouchingLayer && _cooldown.IsReady)
            {
                Shoot();
            }
        }

        public void Shoot()
        {
            _cooldown.Reset();
            _animation.SetClip("start");
        }
    }
}
