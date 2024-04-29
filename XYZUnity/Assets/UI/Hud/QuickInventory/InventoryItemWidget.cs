﻿using Scripts.Model.Data;
using Scripts.Model.Definitions;
using Scripts.Utils.Disposables;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud.QuickInventory
{
    public class InventoryItemWidget :MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _selection;
        [SerializeField] private Text _value;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private int _index;

        public void SetData(InventoryItemData item, int index)
        {
            _index = index;

            var def = DefsFacade.Instance.Items.Get(item.Id);
            _icon.sprite = def.Icon;
            _value.text = def.IsStackable ? item.Value.ToString() : string.Empty;

        }
    }
}
