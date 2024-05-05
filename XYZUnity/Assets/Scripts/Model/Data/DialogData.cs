using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Model.Data
{
    [Serializable]
    public class DialogData
    {
        [SerializeField] private string[] _sentences;
        public string[] Sentences => _sentences;

        public void ChangeSentences(string[] newSentArray)
        {
            var newSentence = new List<string>();

            foreach (var sent in newSentArray)
            {
                newSentence.Add(sent);
            }

            _sentences = newSentence.ToArray();
        }
    }
}
