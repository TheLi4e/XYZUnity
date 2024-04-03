using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components
{
    public class CoinCounterComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;

        public Text coinCounter;
        public static int coins = 0;
       

        void Update()
        {
            coinCounter.text = "Coins " + coins;
        }

        public void IncreaseCounter()
        {
            if (gameObject.CompareTag("SilverCoin"))
                coins++;
            if (gameObject.CompareTag("GoldCoin"))
                coins+=10;
        }

        public static void DecreaseCounter()
        {
            coins = 0;
        }
    }
}


