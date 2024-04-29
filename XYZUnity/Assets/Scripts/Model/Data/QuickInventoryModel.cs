﻿using Scripts.Model.Data.Properties;
using Scripts.Model.Definitions;
using Scripts.Utils.Disposables;
using System;
using UnityEngine;

namespace Scripts.Model.Data
{
    public class QuickInventoryModel
    {
        private readonly PlayerData _data;

        public InventoryItemData[] Inventory { get; private set; }

        public readonly IntProperty SelectedIndex = new IntProperty();

        public event Action OnChanged;  
        
        public InventoryItemData SelectedItem => Inventory[SelectedIndex.Value]; 


        public QuickInventoryModel(PlayerData data)
        {
            _data = data;
            Inventory = _data.Inventory.GetAll(ItemTag.Usable);
            _data.Inventory.OnChanged += OnChangedInventory;
        }

        private void OnChangedInventory(string id, int value)
        {
            var indexFound = Array.FindIndex(Inventory, x => x.Id == id);
            if (indexFound != -1)
            {
                Inventory = _data.Inventory.GetAll(ItemTag.Usable);
                SelectedIndex.Value = Mathf.Clamp(SelectedIndex.Value, 0, Inventory.Length - 1);
                OnChanged?.Invoke();
            }
        }

        public IDisposable Subscribe(Action call)
        {
            OnChanged += call;
            return new ActionDisposable(() => OnChanged -= call); 
        }

        public void SetNextItem()
        {
            SelectedIndex.Value = (int) Mathf.Repeat(SelectedIndex.Value+1, Inventory.Length);
        }
    }
}
