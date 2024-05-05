using System;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace Scripts.Effects
{
    public class ParallaxEffect :MonoBehaviour
    {
        [SerializeField] private float _effectvalue;
        [SerializeField] private Transform _followTarget;

        private float _startX;

        private void Start()
        {
            _startX = transform.position.x;
        }

        private void LateUpdate()
        {
            var currentPosition = transform.position;
            var deltaX = _followTarget.position.x * _effectvalue;
            transform.position =  new Vector3(_startX+deltaX,currentPosition.y, currentPosition.z);
        }
    }
}
