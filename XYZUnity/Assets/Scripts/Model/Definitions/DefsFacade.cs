using Scripts.Model.Definitions.Repositories;
using Scripts.Model.Definitions.Repository;
using UnityEngine;

namespace Scripts.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private InventoryItemsDef _items;
        [SerializeField] private ThrowableItemsDef _throwableitems;
        [SerializeField] private PotionsRepository _potions;
        [SerializeField] private PerkRepository _perks;
        [SerializeField] private PlayerDef _player;

        public InventoryItemsDef Items => _items;
        public ThrowableItemsDef Throwable => _throwableitems;
        public PotionsRepository Potions => _potions;
        public PerkRepository Perks => _perks;
        public PlayerDef Player => _player;

        private static DefsFacade _instance;
        public static DefsFacade I => _instance == null ? LoadDefs() : _instance;

        private static DefsFacade LoadDefs()
        {
            return _instance = Resources.Load<DefsFacade>("DefsFacade");
        }
    }
}
