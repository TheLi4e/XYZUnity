using Cinemachine;
using UnityEngine;

namespace Scripts.Components.LevelManagement
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class SetFollowComponent :MonoBehaviour
    {
        private void Start()
        {
            var camera = GetComponent<CinemachineVirtualCamera>();
            camera.Follow = FindObjectOfType<Hero>().transform; 
        }
    }
}
