using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts.Components
{
    internal class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent _action;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                _action?.Invoke(other.gameObject);
            }
        }

    }

    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {
    }

}
