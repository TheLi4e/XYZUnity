using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Components
{
    internal class ExitLevelComponent :MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        public void Exit()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
