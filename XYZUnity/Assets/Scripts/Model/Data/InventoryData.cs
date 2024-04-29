using Scripts.Model.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Model.Data
{
    [Serializable]
    public class InventoryData
    {
        [SerializeField] private List<InventoryItemData> _inventory = new List<InventoryItemData>();

        public delegate void OnInventoryChanged(string id, int value);

        public OnInventoryChanged OnChanged;

        public void Add(string id, int value)
        {
            if (value <= 0) return;

            var itemDef = DefsFacade.Instance.Items.Get(id);
            if (itemDef.IsVoid) return;

            var isFull = _inventory.Count >= DefsFacade.Instance.Player.InventorySize;

            if (itemDef.HasTag(ItemTag.Stackable))
            {
                AddToStack(id, value);
            }
            else
            {
                AddNonStack(id, value);
            }

            OnChanged?.Invoke(id, Count(id));
        }

        public InventoryItemData[] GetAll(params ItemTag[] tags)
        {
            var retValue = new List<InventoryItemData>();
            foreach ( var item in _inventory )
            {
                var itemDef = DefsFacade.Instance.Items.Get(item.Id);
                var isAllRequirementsMet = tags.All(x => itemDef.HasTag(x));
                if (isAllRequirementsMet)
                    retValue.Add(item);
            }

            return retValue.ToArray();
        }
        private void AddNonStack(string id, int value)
        {

            for (var i = 0; i < value; i++)
            {
                var isFull = _inventory.Count >= DefsFacade.Instance.Player.InventorySize;
                if (isFull) return;

                var item = new InventoryItemData(id) { Value = 1 };
                _inventory.Add(item);
            }
        }

        private void AddToStack(string id, int value)
        {
            var itemsLast = DefsFacade.Instance.Player.InventorySize - _inventory.Count;
            value = Mathf.Min(itemsLast, value);

            var isFull = _inventory.Count >= DefsFacade.Instance.Player.InventorySize;
            var item = GetItem(id);
            if (item == null)
            {
                item = new InventoryItemData(id);
                _inventory.Add(item);
            }
            item.Value += value;
        }

        public void Remove(string id, int value)
        {
            var itemDef = DefsFacade.Instance.Items.Get(id);
            if (itemDef.IsVoid) return;

            if (itemDef.HasTag(ItemTag.Stackable))
            {
                RemoveFromStack(id, value);
            }
            else
            {
                RemoveNonStack(id, value);
            }

            OnChanged?.Invoke(id, Count(id));
        }

        private void RemoveFromStack(string id, int value)
        {
            var item = GetItem(id);
            if (item == null) return;

            item.Value -= value;

            if (item.Value <= 0)
                _inventory.Remove(item);
        }

        private void RemoveNonStack(string id, int value)
        {
            for (int i = 0; i < value; i++)
            {
                var item = GetItem(id);
                if (item == null) return;

                _inventory.Remove(item);
            }
        }

        internal int Count(string id)
        {
            var count = 0;
            foreach (var item in _inventory)
            {
                if (item.Id == id)
                    count += item.Value;
            }
            return count;
        }

        private InventoryItemData GetItem(string id)
        {
            foreach (var item in _inventory)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }



    }


    [Serializable]
    public class InventoryItemData
    {
        [InventoryId] public string Id;
        public int Value;

        public InventoryItemData(string id)
        {
            Id = id;
        }
    }
}
