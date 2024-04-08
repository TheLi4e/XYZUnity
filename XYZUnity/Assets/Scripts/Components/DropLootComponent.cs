using UnityEngine;


namespace Assets.Scripts.Components
{
    internal class DropLootComponent : MonoBehaviour
    {
        [SerializeField] GameObject _silverCoin;
        [SerializeField] GameObject _goldCoin;
        [SerializeField] float _probabilitySilver;
        [SerializeField] float _probabilityGold;
        [SerializeField] int _valueCoins;

        private int _random;

        public void DropLoot()
        {
            _random = Random.Range(0, 100);
            var pos = transform.position;
            for (int i = 1; i <= _valueCoins; i++)
            {
                if (_random <= _probabilityGold)
                {
                    pos.x -= 0.2f;
                    Instantiate(_goldCoin, pos, Quaternion.identity);
                }
                if (_random <= _probabilitySilver)
                {
                    pos.x += 0.1f;
                    Instantiate(_silverCoin, pos, Quaternion.identity);
                }
            }
        }
    }
}
