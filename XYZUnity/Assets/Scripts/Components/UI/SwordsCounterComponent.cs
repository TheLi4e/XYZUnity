using Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components
{
    internal class SwordsCounterComponent : MonoBehaviour
    {
        public Text _swordsCounter;
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }
        void Update()
        {
            _swordsCounter.text = "Swords " + _session.Data.Inventory.Count("Sword");
        }
    }
}

