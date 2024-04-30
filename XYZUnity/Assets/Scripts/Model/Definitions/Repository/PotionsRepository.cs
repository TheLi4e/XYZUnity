using System;
using UnityEngine;

namespace Scripts.Model.Definitions.Repository
{
    [CreateAssetMenu(menuName = "Defs/Repository/Potions", fileName = "Potions")]
    public class PotionsRepository : DefRepository<PotionDef>
    {
    }

    [Serializable]
    public struct PotionDef : IHaveId
    {
        [InventoryId][SerializeField] private string _id;
        [SerializeField] private float _value;
        [SerializeField] private float _time;
        public string Id => _id;
        public float Value => _value;
        public float Time => _time;
    }
}
