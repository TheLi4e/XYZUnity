using Scripts.Model;
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
            _coinCounter.text = "Coins " + _session.Data.Inventory.Count("Coin");;
        }
    }
}


