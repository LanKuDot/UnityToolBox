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

        /// <summary>
        /// The unclamped version of "Lerp"
        /// </summary>
        /// <param name="ratio">The ratio for the lerp</param>
        /// <returns>The value is unclamped</returns>
        public float LerpUnclamped(float ratio)
        {
            return Mathf.LerpUnclamped(_min, _max, ratio);
        }

        /// <summary>
        /// Get the lerp value between the min and the max value
        /// </summary>
        /// <param name="ratio">The ratio for the lerp</param>
        /// <returns>The value is clamped within the range</returns>
        public float Lerp(float ratio)
        {
            return Mathf.Lerp(_min, _max, ratio);
        }

        /// <summary>
        /// Return the ratio of value between min and max value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The ratio is unclamped</returns>
        public float InverseLerpUnclamped(float value)
        {
            return Mathf.InverseLerp(_min, _max, value);
        }

        /// <summary>
        /// Return the ratio of value between min and max value and
        /// its value is clamped in [0, 1]
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The ratio which is clamped in [0, 1]</returns>
        public float InverseLerp(float value)
        {
            return Mathf.Clamp(InverseLerpUnclamped(value), 0, 1);
        }
    }
}
