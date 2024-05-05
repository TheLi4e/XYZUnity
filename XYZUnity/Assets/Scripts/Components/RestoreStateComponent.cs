using Scripts.Model;
using UnityEditor.U2D.Common;
using UnityEngine;

namespace Scripts.Components
{
    public class RestoreStateComponent : MonoBehaviour
    {
        [SerializeField] private string _id;
        private GameSession _session;

        public string Id => _id;


        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
           var isAlive =  _session.RestoreState(_id);
            if(isAlive) 
                Destroy(gameObject);
        }


    }
}
