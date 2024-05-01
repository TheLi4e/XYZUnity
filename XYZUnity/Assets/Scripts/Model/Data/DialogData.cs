﻿using System;
using UnityEngine;

namespace Scripts.Model.Data
{
    [Serializable]
    public class DialogData
    {
        [SerializeField] private string[] _sentences;
        public string[] Sentences => _sentences;

    }
}
