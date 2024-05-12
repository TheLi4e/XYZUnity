﻿using Scripts.Model;
using Scripts.Model.Data;
using Scripts.Model.Definitions;
using Scripts.UI.Widgets;
using Scripts.Utils.Disposables;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud.QuickInventory
{
    public class InventoryItemWidget : MonoBehaviour, IItemRenderer<InventoryItemData>
    {
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _selection;
        [SerializeField] private Text _value;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private int _index;

        private void Start()
        {
            var session = FindObjectOfType<GameSession>();
            var quickInventoryIndex = session.QuickInventory.SelectedIndex;
            _trash.Retain(quickInventoryIndex.SubscribeAndInvoke(OnIndexChanged));
        }

        public void SetData(InventoryItemData item, int index)
        {
            _index = index;

            var def = DefsFacade.I.Items.Get(item.Id);
            _icon.sprite = def.Icon;
            _value.text = def.HasTag(ItemTag.Stackable) ? item.Value.ToString() : string.Empty;
        }

        private void OnIndexChanged(int newValue, int _)
        {
            _selection.SetActive(_index == newValue);
        }

        public void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
