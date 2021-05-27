using System;
using UnityEngine;

namespace LanKuDot.UnityToolBox.Math
{
    [Serializable]
    public class MinMaxValue
    {
        [SerializeField]
        private float _min;
        [SerializeField]
        private float _max;

        public float min => _min;
        public float max => _max;

        public MinMaxValue()
        {}

        public MinMaxValue(float min, float max)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Clamp the value within the range of min-max value
        /// </summary>
        /// <param name="value">The value to be clamped</param>
        /// <returns>The clamped value</returns>
        public float Clamp(float value)
        {
            return Mathf.Clamp(value, _min, _max);
        }

        /// <summary>
        /// Check if the input value is in the range of the min-max value [both included]
        /// </summary>
        public bool IsWithin(float value)
        {
            return value >= _min && value <= _max;
        }
    }
}
