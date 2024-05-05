﻿using Scripts.Model;
using Scripts.UI;
using Scripts.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.InGameMenu
{
    public class InGameMenuWindow : AnimatedWindow
    {
        private float _defaultTimeScale;

        protected override void Start()
        {
            base.Start();

            _defaultTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        public void OnShowSettings()
        {
            WindowUtils.CreateWindow("UI/SettingsWindow");
        }

        public void OnLanguages()
        {
            WindowUtils.CreateWindow("UI/LocalizationWindow");
        }

        public void OnExit()
        {
            SceneManager.LoadScene("MainMenu");
            var session = FindObjectOfType<GameSession>();
            Destroy(session.gameObject);
        }

        private void OnDestroy()
        {
            Time.timeScale = _defaultTimeScale;
        }
    }
}
