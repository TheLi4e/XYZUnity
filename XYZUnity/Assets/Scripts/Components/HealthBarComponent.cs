using Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components
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
