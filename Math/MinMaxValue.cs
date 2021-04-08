using System;
using UnityEngine;

[Serializable]
public class MinMaxValue
{
    [SerializeField]
    private float _min;
    [SerializeField]
    private float _max;

    public float min => _min;
    public float max => _max;

    /// <summary>
    /// Check if the input value is in the range of the min-max value [both included]
    /// </summary>
    public bool IsWithin(float value)
    {
        return value >= _min && value <= _max;
    }
}
