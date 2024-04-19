using UnityEngine;

namespace Scripts.Components
{
    internal class ChangeCoinComponent : MonoBehaviour
    {
        [SerializeField] private int _numCoins;
        private Hero _hero;

        private void Start()
        {
            _hero = FindObjectOfType<Hero>();
        }

        public void Add()
        {
            _hero.AddCoins(_numCoins);
        }


        public void DecreaseCounter()
        {
            _hero.RemoveCoins();
        }
    }
}
