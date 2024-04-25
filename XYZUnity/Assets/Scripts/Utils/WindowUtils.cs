using UnityEngine;

namespace Scripts.Utils
{
    public class WindowUtils
    {
        public static void CreateWindow(string resoursePath)
        {
            var window = Resources.Load<GameObject>(resoursePath);
            var canvas = UnityEngine.Object.FindObjectOfType<Canvas>();
            Object.Instantiate(window, canvas.transform);
        } 
    }
}
 