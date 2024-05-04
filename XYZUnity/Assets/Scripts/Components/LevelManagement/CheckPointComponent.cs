using Scripts.Model;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.LevelManagement
{
    [RequireComponent(typeof(SpawnComponent))]
    public class CheckPointComponent : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private UnityEvent _setChecked;
        [SerializeField] private UnityEvent _setUnchecked;

        private GameSession _session;
        private SpawnComponent _heroSpawner;

        private void Start()
        {
            _heroSpawner = GetComponent<SpawnComponent>();
            _session = FindObjectOfType<GameSession>();
            if (_session.isChecked(_id))
                _setChecked?.Invoke();
            else
                _setUnchecked?.Invoke();
        }

        public void Check()
        {
            _session.SetChecked(_id);
        }
        
        public void SpawnHero()
        {
            _heroSpawner.Spawn();
        }
    }
}
