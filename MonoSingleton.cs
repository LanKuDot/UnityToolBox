using UnityEngine;

/// <summary>
/// Create the singleton instance of MonoBehaviour class
/// </summary>
public class MonoSingleton<T> : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected void Awake()
    {
        Instance = GetComponent<T>();
    }
}
