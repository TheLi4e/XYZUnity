using Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    internal class CheckCircleOverlap : MonoBehaviour
    {
        [SerializeField] private float _radius = 1f;
        [SerializeField] private LayerMask _mask;
        [SerializeField] private string[] _tags;
        [SerializeField] private OnOverlapEvent _onOverlap;
        private Collider2D[] _interActionResult = new Collider2D[10];


        internal void Check()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
                transform.position,
                _radius,
                _interActionResult,
                _mask);

            var overlaps = new List<GameObject>();
            for (var i = 0; i < size; i++)
            {
                var overlapResult = _interActionResult[i];
                var isInTag = _tags.Any(tag => _interActionResult[i].CompareTag(tag));
                if(isInTag)
                {
                    _onOverlap?.Invoke(_interActionResult[i].gameObject);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Handles.color = HandlesUtils.TransparantedRed;
            Handles.DrawSolidDisc(transform.position, Vector3.forward, _radius);
        }

        [Serializable]
        public class OnOverlapEvent : UnityEvent<GameObject>
        {
        }
    }
}
