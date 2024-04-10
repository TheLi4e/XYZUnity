using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components
{
    public class CoinCounterComponent : MonoBehaviour
    {
        public Text _coinCounter;
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }
        void Update()
        {
            _coinCounter.text = "Coins " + _session.Data.Coins;
        }
    }
}


