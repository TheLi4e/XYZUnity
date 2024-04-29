﻿using Scripts.Components;
using Scripts.Utils.Disposables;
using System;
using UnityEngine;


namespace UI.Widgets
{
    public class HpBarWidget : MonoBehaviour
    {
        [SerializeField] private ProgressBarWidget _progressBarWidget;
        [SerializeField] private HealthComponent _hp;

        private readonly CompositeDisposable _trash = new CompositeDisposable();
        private int _maxHp;


        private void Start()
        {
            if (_hp == null)
                _hp = GetComponentInParent<HealthComponent>();

            _maxHp = _hp.Health;

            _trash.Retain(_hp._onDie.Subscribe(OnDie));
            _trash.Retain(_hp._onChange.Subscribe(OnHpChanged));
        }

        private void OnDie()
        {
            Destroy(gameObject);
        }

        private void OnHpChanged(int hp)
        {
            var progress = (float)hp / _maxHp;
            _progressBarWidget.SetProgress(progress);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
