using LanKuDot.UnityToolBox.Math;
using UnityEngine;

namespace ToolBox
{
    /// <summary>
    /// The utility for generating the min max values
    /// </summary>
    public static class MinMaxValueUtility
    {
        /// <summary>
        /// Generate a set of the min max value
        /// </summary>
        /// The most minimum value in all min max values is globalMin, and
        /// the most maximum value in all min max values is globalMax.
        /// The number of offset will be padded at the two ends of each min max value
        /// orderly according to the num of min max values.
        /// <param name="globalMin">The most minimum value</param>
        /// <param name="globalMax">The most maximum value</param>
        /// <param name="offset">
        /// The unit offset to be padded at two ends of min max value</param>
        /// <param name="num">The number of min max values to be generated</param>
        /// <returns>An array of generated min max values</returns>
        public static MinMaxValue[] GetOffsetCluster(
            float globalMin, float globalMax, float offset, int num)
        {
            Debug.Assert(
                globalMin <= globalMax,
                $"{nameof(globalMin)} is greater than {nameof(globalMax)}");
            Debug.Assert(
                globalMax - globalMin > offset,
                $"{nameof(offset)} is greater than the range "+
                $"from the {nameof(globalMin)} to {nameof(globalMax)}");

            var range = (globalMax - globalMin) - offset * (num - 1);
            var minMaxValues = new MinMaxValue[num];

            for (var i = 0; i < num; ++i) {
                var min = offset * i;
                var max = min + range;
                minMaxValues[i] = new MinMaxValue(min, max);
            }

            return minMaxValues;
        }
    }
}
