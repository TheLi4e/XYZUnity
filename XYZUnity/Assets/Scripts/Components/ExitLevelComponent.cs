using Scripts.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Components
{
    internal class ExitLevelComponent :MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        public void Exit()
        {
            var session = FindObjectOfType<GameSession>();
            session.Save();
            SceneManager.LoadScene(_sceneName);
        }
    }
}
