﻿using Scripts.Model.Definitions.Repositories;
using System;
using UnityEngine;

namespace Scripts.Model.Definitions
{
    [Serializable]
    public struct StatDef
    {
        [SerializeField] private string _name;
        [SerializeField] private StatId _id;
        [SerializeField] private Sprite _icon;
        [SerializeField] private StatLevel[] _levels;

        public StatId ID => _id;
        public string Name => _name;
        public Sprite Icon => _icon;
        public StatLevel[] Levels => _levels;

    }

    [Serializable] 
    public struct StatLevel
    {
        [SerializeField] private float _value;
        [SerializeField] private ItemWithCount _price;

        public float Value => _value;
        public ItemWithCount Price => _price;

    }

    public enum StatId
    {
        Hp,
        Speed,
        RangeDamage
    }
}
