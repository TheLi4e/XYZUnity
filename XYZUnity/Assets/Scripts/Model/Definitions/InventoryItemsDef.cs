using Scripts.Model.Definitions.Repository;
using System;
using System.Linq;
using UnityEngine;

namespace Scripts.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/InventoryItems", fileName = " InventoryItems")]
    public class InventoryItemsDef : DefRepository<ItemDef>
    {
        [SerializeField] private ItemDef[] _items;
       
        private void OnEnable()
        {
            _collection = _items;
        }

        public ItemDef Get(string id)
        {
            foreach (var item in _items)
            {
                if (item.Id == id)
                    return item;
            }

            return default;
        }

#if UNITY_EDITOR
        public ItemDef[] itemsForEditor => _items;
#endif
    }

    [Serializable]
    public struct ItemDef :IHaveId
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemTag[] _tags;

        public string Id => _id;

        public bool IsVoid => string.IsNullOrEmpty(_id);

        public Sprite Icon => _icon; 

        public bool HasTag(ItemTag tag)
        {
            return _tags.Contains(tag);
        }
    }
}
