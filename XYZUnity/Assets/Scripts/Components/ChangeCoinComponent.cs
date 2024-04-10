using Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components
{
    internal class ChangeCoinComponent :MonoBehaviour
    {
        private Hero _hero;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("SilverCoin"))
                _hero.AddCoins(1);
            if(other.CompareTag("GoldCoin"))
                _hero.AddCoins(10);
            Destroy(gameObject);
        }
        

        public void DecreaseCounter()
        {
            _hero.RemoveCoins();
        }
    }
}
