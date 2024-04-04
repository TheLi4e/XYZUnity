using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Components
{
    internal class HealthBarComponent :MonoBehaviour
    {
        [SerializeField] GameObject _gameObject;
        public Text HealthBar;


        void Update()
        {
            var healthComponent = _gameObject.GetComponent<HealthComponent>();
            
            HealthBar.text = "Health " + healthComponent._health;
        }

    }
}
