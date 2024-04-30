﻿using Scripts.Model;
using Scripts.Model.Data;
using Scripts.Utils.Disposables;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Hud.QuickInventory
{
    public class QuickInventoryController : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private InventoryItemWidget _prefab;

        private readonly CompositeDisposable _trash = new CompositeDisposable();
        private List<InventoryItemWidget> _createdItems = new List<InventoryItemWidget>();

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _trash.Retain(_session.QuickInventory.Subscribe(Rebuild));
            Rebuild();
        }

        private void Rebuild()
        {
            var inventory = _session.QuickInventory.Inventory;

            //create required items
            for (var i = _createdItems.Count; i < inventory.Length; i++)
            {
                var item = Instantiate(_prefab, _container);
                _createdItems.Add(item);
            }

            // update data and activate
            for (var i = 0; i < inventory.Length; i++)
            {
                _createdItems[i].SetData(inventory[i], i);
                _createdItems[i].gameObject.SetActive(true);
            }

            //hide unused items
            for (var i = inventory.Length; i < _createdItems.Count; i++)
            {
                _createdItems[i].gameObject.SetActive(false);
            }
        }
    }
}
