using UnityEngine;

namespace LanKuDot.UnityToolBox.Math
{
    public static class Vector3Utility
    {
        /// <summary>
        /// Get the vector between two points with some ignored axis
        /// </summary>
        /// <param name="from">The from position</param>
        /// <param name="to">The to position</param>
        /// <param name="ignoreAxis">
        /// The axis to be ignored. The value of the ignored axis should be 1.
        /// </param>
        public static Vector3 GetVector(
            Vector3 from, Vector3 to, Vector3 ignoreAxis = default)
        {
            var direction = to - from;
            direction -= Vector3.Scale(direction, ignoreAxis);
            return direction;
        }

        /// <summary>
        /// Get the normalized direction from pos to to pos with some ignored axis
        /// </summary>
        /// <param name="from">The from position</param>
        /// <param name="to">The to position</param>
        /// <param name="ignoreAxis">
        /// The axis to be ignored. The value of the ignored axis should be 1.
        /// </param>
        public static Vector3 GetDirection(
            Vector3 from, Vector3 to, Vector3 ignoreAxis = default)
        {
            return GetVector(from, to, ignoreAxis).normalized;
        }

        /// <summary>
        /// Get the distance between two points with some ignored axis
        /// </summary>
        /// <param name="from">The from position</param>
        /// <param name="to">The to position</param>
        /// <param name="ignoreAxis">
        /// The axis to be ignored. The value of the ignored axis should be 1.
        /// </param>
        public static float GetDistance(
            Vector3 from, Vector3 to, Vector3 ignoreAxis = default)
        {
            return GetVector(from, to, ignoreAxis).magnitude;
        }

        /// <summary>
        /// Get the y degree for the specified direction
        /// </summary>
        /// <param name="direction">The direction to be calculated</param>
        /// <returns>The y degree</returns>
        public static float GetYDegree(Vector3 direction)
        {
            return Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
        }
    }
}
