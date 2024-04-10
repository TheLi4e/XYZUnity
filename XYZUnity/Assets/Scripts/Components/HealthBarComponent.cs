using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Components
{
    internal class HealthBarComponent : MonoBehaviour
    {
        public Text _healthBar;
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        void Update()
        {
            _healthBar.text = "HP " + _session.Data.HP;
        }

    }
}
