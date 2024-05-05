using Scripts.Model.Data;
using Scripts.Model.Definitions;
using Scripts.Model.Definitions.Localization;
using System;
using UI.Hud.Dialogs;
using UnityEngine;

namespace Scripts.Components.Dialogs
{
    public class ShowDialogComponent : MonoBehaviour
    {
        [SerializeField] private Mode _mode;
        [SerializeField] private DialogData _bound;
        [SerializeField] private DialogDef _external;
        [SerializeField] private string _key;

        private DialogBoxController _dialogBox;

        private void Start()
        {
            LocalizationManager.I.OnLocaleChanged += OnLocaleChanged;
            OnLocaleChanged();
        }

        private void OnLocaleChanged()
        {
            var sentences = LocalizationManager.I.Localize(_key).Split('&');
            _external.Data.ChangeSentences(sentences);
        }
        public void Show()
        {
            if (_dialogBox == null)
                _dialogBox = FindObjectOfType<DialogBoxController>();
            _dialogBox.ShowDialog(Data);
        }

        public void Show(DialogDef def)
        {
            _external = def;
            OnLocaleChanged();
            Show();
        }

        public void SetKey(string key)
        {
            _key = key;
        }

        public void OnDestroy()
        {
            LocalizationManager.I.OnLocaleChanged -= OnLocaleChanged;
        }

        public DialogData Data
        {
            get
            {
                switch (_mode)
                {
                    case Mode.Bound:
                        return _bound;
                    case Mode.External:
                        return _external.Data;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public enum Mode
        {
            Bound,
            External
        }
    }
}
