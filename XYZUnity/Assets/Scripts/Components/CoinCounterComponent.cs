using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components
{
    public class CoinCounterComponent : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        public Text CoinCounter;
        public static int _coins;

        void Update()
        {
            _coins = _hero.Coins;
            CoinCounter.text = "Coins " + _coins;
        }

        public void IncreaseCounter()
        {
            if (gameObject.CompareTag("SilverCoin"))
                _hero.AddCoins(1);
            if (gameObject.CompareTag("GoldCoin"))
                _hero.AddCoins(10);
        }

        public void DecreaseCounter()
        {
            _hero.RemoveCoins();
        }
    }
}


