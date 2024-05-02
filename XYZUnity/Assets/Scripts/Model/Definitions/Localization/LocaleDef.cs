using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Scripts.Model.Definitions.Localization
{
    [CreateAssetMenu(menuName = "Defs/LocaleDef", fileName = "LocaleDef")]
    public class LocaleDef : ScriptableObject
    {
        //https://docs.google.com/spreadsheets/d/e/2PACX-1vQEaFlu_PAkH7fo55jcJVXEHfUH8swsUmOOOcELXUOF1TjUG2dymO7ObvP-H05b-muETjiGkfOrpIsY/pub?gid=0&single=true&output=tsv                  en
        //https://docs.google.com/spreadsheets/d/e/2PACX-1vQEaFlu_PAkH7fo55jcJVXEHfUH8swsUmOOOcELXUOF1TjUG2dymO7ObvP-H05b-muETjiGkfOrpIsY/pub?gid=2069891923&single=true&output=tsv         ru
        //https://docs.google.com/spreadsheets/d/e/2PACX-1vQEaFlu_PAkH7fo55jcJVXEHfUH8swsUmOOOcELXUOF1TjUG2dymO7ObvP-H05b-muETjiGkfOrpIsY/pub?gid=612296113&single=true&output=tsv          es

        [SerializeField] private string _url;
        [SerializeField] private List<LocaleItem> _localeItems;

        private UnityWebRequest _request;

        [ContextMenu("Update locale")]
        private void UpdateLocale()
        {
            if (_request != null) return;

            _request = UnityWebRequest.Get(_url);
            _request.SendWebRequest().completed += OnDataLoaded;
        }

        private void OnDataLoaded(AsyncOperation operation)
        {
            if (operation.isDone)
            {
                var rows = _request.downloadHandler.text.Split('\n'); 
                foreach(var row in rows)
                {
                    AddLocaleItem(row);
                }
            }
        }

        private void AddLocaleItem(string row)
        {
            try
            {
                var parts = row.Split('\t');
                _localeItems.Add(new LocaleItem { Key = parts[0], Value = parts[1]});
            }
            catch(Exception ex)
            {
                Debug.LogError($"Can't parse row: {row}.\n {ex}");
            }
        }

        [Serializable]
        private class LocaleItem
        {
            public string Key;
            public string Value;
        }

    }
}
