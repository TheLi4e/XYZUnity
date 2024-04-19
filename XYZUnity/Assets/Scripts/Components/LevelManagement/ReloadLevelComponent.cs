using Scripts.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Components
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        private GameSession _session;
        public void Reload()
        {
            var session = FindObjectOfType<GameSession>();
            session.LoadLastSave();

            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}