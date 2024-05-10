using Scripts.Model;
using Scripts.Model.Definitions;
using Scripts.Model.Definitions.Localization;
using Scripts.UI.Widgets;
using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Widgets
{
    public class StatWidget : MonoBehaviour, IItemRenderer<StatDef>
    {
        [SerializeField] private Text _name;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _currentValue;
        [SerializeField] private Text _increaseValue;
        [SerializeField] private ProgressBarWidget _progress;
        [SerializeField] private GameObject _selector;

        private GameSession _session;
        private StatDef _data;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            UpdateView();
        }
        public void SetData(StatDef data, int index)
        {
            _data = data;
            if (_session != null)
                UpdateView();

        }

        private void UpdateView()
        {
            var statsModel = _session.StatsModel;

            _icon.sprite = _data.Icon;
            _name.text = LocalizationManager.I.Localize(_data.Name);
            var currentLevelValue = statsModel.GetValue(_data.ID);
            _currentValue.text = currentLevelValue.ToString(CultureInfo.InvariantCulture);

            var currentLevel = statsModel.GetCurrentLevel(_data.ID);
            var nextLevel = currentLevel + 1;
            var increaseValue = statsModel.GetValue(_data.ID, nextLevel);
            var currentIncreaseValue = statsModel.GetValue(_data.ID, currentLevel);
            _increaseValue.text = $"+ {increaseValue - currentIncreaseValue}";
            _increaseValue.gameObject.SetActive(increaseValue > 0);

            var maxLevel = DefsFacade.I.Player.GetStat(_data.ID).Levels.Length - 1;
            _progress.SetProgress(currentLevel / (float)maxLevel);

            _selector.SetActive(statsModel.InterfaceSelectedStat.Value == _data.ID);
        }

        public void OnSelect()
        {
            _session.StatsModel.InterfaceSelectedStat.Value = _data.ID;
        }
    }
}
