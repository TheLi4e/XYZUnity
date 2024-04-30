using System;
using UnityEngine;

namespace Scripts.Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;

        [ContextMenu("Spawn")]

  
        public void Spawn()
        {
            var instaniate = Instantiate(_prefab, _target.position, Quaternion.identity);
            instaniate.transform.localScale = _target.lossyScale;
        }

        public void SetPrefab(GameObject prefab)
        {
            _prefab = prefab;
        }
    }
}
