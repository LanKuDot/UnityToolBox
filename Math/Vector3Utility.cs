using UnityEngine;

namespace LanKuDot.UnityToolBox.Math
{
    public static class Vector3Utility
    {
        /// <summary>
        /// Get the normalized direction from pos to to pos, and ignore the y direction
        /// </summary>
        /// <param name="from">The from position</param>
        /// <param name="to">The to position</param>
        public static Vector3 GetDirectionIgnoreY(Vector3 from, Vector3 to)
        {
            var direction = to - from;
            direction.y = 0;
            return direction.normalized;
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
