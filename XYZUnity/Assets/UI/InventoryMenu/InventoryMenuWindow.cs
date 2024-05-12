using Scripts.Model.Data;
using Scripts.Model;
using Scripts.UI;
using Scripts.UI.Widgets;
using Scripts.Utils.Disposables;
using UnityEngine;
using UI.Hud.InventoryMenu;

namespace UI.InventoryMenu
{
    public class InventoryMenuWindow : AnimatedWindow
    {
        [SerializeField] private Transform _container;
        [SerializeField] private BigInventoryItemWidget _prefab;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private GameSession _session;

        private DataGroup<InventoryItemData, BigInventoryItemWidget> _dataGroup;

        protected override void Start()
        {
            base.Start();
            _dataGroup = new DataGroup<InventoryItemData, BigInventoryItemWidget>(_prefab, _container);
            _session = FindObjectOfType<GameSession>();
            _trash.Retain(_session.Inventory.Subscribe(Rebuild));
            Rebuild();
        }

        private void Rebuild()
        {
            var inventory = _session.Inventory.Inventory;
            _dataGroup.SetData(inventory);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
