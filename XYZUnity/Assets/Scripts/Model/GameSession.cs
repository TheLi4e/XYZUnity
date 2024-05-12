using Scripts.Components.LevelManagement;
using Scripts.Model.Data;
using Scripts.Model.Definitions;
using Scripts.Utils.Disposables;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Model
{
    internal class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        [SerializeField] private string _defaultCheckPoint;

        public PlayerData Data => _data;
        private PlayerData _save;
        private readonly CompositeDisposable _trash = new CompositeDisposable();
        public QuickInventoryModel QuickInventory { get; private set; }
        public InventoryModel Inventory { get; private set; }
        public PerksModel PerksModel { get; private set; }
        public StatsModel StatsModel { get; private set; }

        private readonly List<string> _checkpoints = new List<string>();

        private List<string> _removedItems = new List<string>();


        private void Awake()
        {
            var existsSession = GetExistsSession();

            if (existsSession)
            {
                existsSession.StartSession(_defaultCheckPoint);
                Destroy(gameObject);
            }
            else
            {
                Save();
                InitModels();
                DontDestroyOnLoad(gameObject);
                StartSession(_defaultCheckPoint);
            }
        }

        private void StartSession(string defaultCheckPoint)
        {
            SetChecked(defaultCheckPoint);
            LoadHud();
            SpawnHero();
        }

        private void SpawnHero()
        {
            var checkPoints = FindObjectsOfType<CheckPointComponent>();
            var lastCheckPoint = _checkpoints.Last();
            foreach (var checkPoint in checkPoints)
            {
                if (checkPoint.Id == lastCheckPoint)
                {
                    checkPoint.SpawnHero();
                    break;
                }
            }
        }

        private void InitModels()
        {
            QuickInventory = new QuickInventoryModel(_data);
            _trash.Retain(QuickInventory);

            Inventory = new InventoryModel(_data);
            _trash.Retain(Inventory);

            PerksModel = new PerksModel(_data);
            _trash.Retain(PerksModel);

            StatsModel = new StatsModel(_data);
            _trash.Retain(StatsModel);

            _data.Hp.Value = (int) StatsModel.GetValue(StatId.Hp);
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        private GameSession GetExistsSession()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach (var gameSession in sessions)
            {
                if (gameSession != this)
                    return gameSession;
            }

            return null;
        }

        public void Save()
        {
            _save = _data.Clone();
        }

        public void LoadLastSave()
        {
            _data = _save.Clone();
            _trash.Dispose();
            InitModels();
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }

        public bool isChecked(string id)
        {
            return _checkpoints.Contains(id);
        }

        public void SetChecked(string id)
        {
            if (!_checkpoints.Contains(id))
            {
                Save();
                _checkpoints.Add(id);
            }
        }

        public bool RestoreState(string instanceId)
        {
            return _removedItems.Contains(instanceId);
        }

        public void StoreState(string instanceId)
        {
            if (!_removedItems.Contains(instanceId))
                _removedItems.Add(instanceId);
        }
    }
}
