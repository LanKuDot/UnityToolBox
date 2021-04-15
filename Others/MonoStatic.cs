using UnityEngine;

/// <summary>
/// Create the static instance of MonoBehaviour class
/// </summary>
public class MonoStatic<T> : MonoBehaviour
    where T : MonoBehaviour
{
    public static T Instance { private set; get; }

    protected void Awake()
    {
        if (Instance != null)
            Debug.Log("There has more than one class instance for MonoStatic.")

        Instance = GetComponent<T>();
    }
}
