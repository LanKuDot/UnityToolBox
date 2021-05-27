using UnityEngine;

namespace LanKuDot.UnityToolBox
{
    /// <summary>
    /// Create the singleton instance of class MonoBehaviour for entire game
    /// </summary>
    public class MonoGameSingleton<T> : MonoSingleton<T>
        where T : MonoBehaviour
    {
        protected new void Awake()
        {
            if (Instance == null) {
                base.Awake();
                DontDestroyOnLoad(gameObject);
            } else if (Instance.gameObject != gameObject) {
                Destroy(gameObject);
            }
        }
    }
}
