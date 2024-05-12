using Scripts.UI.Widgets;
using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using Scripts.Model.Definitions.Localization;

namespace UI.Hud.Dialogs
{
    public class OptionItemWidget : MonoBehaviour, IItemRenderer<OptionData>
    {
        [SerializeField] private Text _label;
        [SerializeField] private SelectOption _onSelect;

        private OptionData _data;

        public void SetData(OptionData data, int index)
        {
            _data = data;
            _label.text = LocalizationManager.I.Localize(data.Text);
        }

        public void OnSelect()
        {
            _onSelect.Invoke(_data);
        }

        [Serializable]
        public class SelectOption : UnityEvent<OptionData>
        {
        }
    }
}
