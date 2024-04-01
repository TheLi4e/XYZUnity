using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Scripts.Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] GameObject _objectToDestroy;

        public void DestroyObject()
        {
            Destroy(_objectToDestroy);
        }


       
    }
}