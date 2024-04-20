using Scripts.Model.Data;
using System;
using UnityEngine;

namespace Scripts.Model
{
    [Serializable]
    internal class PlayerData
    {
        [SerializeField] private InventoryData _inventory;
        
        public int HP;
       
        public InventoryData Inventory => _inventory;

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
