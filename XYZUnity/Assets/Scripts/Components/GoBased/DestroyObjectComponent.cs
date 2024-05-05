using Scripts.Model;
using UnityEngine;

namespace Scripts.Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] GameObject _objectToDestroy;
        [SerializeField] private RestoreStateComponent _restoreState;

        public void DestroyObject()
        {
            Destroy(_objectToDestroy);
            if(_restoreState!=null)
                FindObjectOfType<GameSession>().StoreState(_restoreState.Id);
        }
    }
}