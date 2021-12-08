using UnityEngine;

namespace LanKuDot.UnityToolBox.System
{
    /// <summary>
    /// Create the singleton instance of MonoBehaviour class
    /// </summary>
    public class MonoSingleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        public static T Instance { private set; get; }

        protected void Awake()
        {
            if (Instance != null)
                Debug.LogWarning("There has more than one class instance for MonoSingleton.");

            Instance = GetComponent<T>();
        }
    }
}
