using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components
{
    public class CoinCounterComponent : MonoBehaviour
    {
        public Text CoinCounter;
        public static int Coins = 0;


        void Update()
        {
            CoinCounter.text = "Coins " + Coins;
        }

        public void IncreaseCounter()
        {
            if (gameObject.CompareTag("SilverCoin"))
                Coins++;
            if (gameObject.CompareTag("GoldCoin"))
                Coins += 10;
        }

        public static void DecreaseCounter()
        {
            Coins = 0;
        }
    }
}


