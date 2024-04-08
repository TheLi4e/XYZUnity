using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CheckCircleOverlap : MonoBehaviour
    {
        [SerializeField] private float _radius = 1f;

        private Collider2D[] _interActionResult = new Collider2D[5];

        public GameObject[] GetObjectsInRange()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
                transform.position,
                _radius,
                _interActionResult);

            var overlaps = new List<GameObject>();
            for (var i = 0; i < size; i++)
            {
                overlaps.Add(_interActionResult[i].gameObject);
            }
            return overlaps.ToArray();
        }

        private void OnDrawGizmosSelected()
        {
            Handles.color = HandlesUtils.TransparantedRed;
            Handles.DrawSolidDisc(transform.position, Vector3.forward, _radius);
        }
    }
}
