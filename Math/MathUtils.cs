using UnityEngine;

namespace LanKuDot.UnityToolBox.Math
{
    /// <summary>
    /// The class for some mathematical calculation
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Get (cos(deg), sin(deg))
        /// </summary>
        /// <param name="degree">The degree</param>
        /// <returns>(cos(deg), sin(deg))</returns>
        public static Vector2 CosSin(float degree)
        {
            var rad = degree * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        }

        /// <summary>
        /// Get the position on a circle
        /// </summary>
        /// <param name="origin">The origin of the circle</param>
        /// <param name="radius">The radius of the circle</param>
        /// <param name="degree">
        /// The degree of the target point.
        /// Degree 0 is upward and the positive direction is CCW.
        /// </param>
        /// <returns>The calculated position</returns>
        public static Vector2 GetCirclePosition(Vector2 origin, float radius, float degree)
        {
            var localPosition = CosSin(degree + 90) * radius;
            return origin + localPosition;
        }


        /// <summary>
        /// Get the signed degree of the vector.
        /// Degree 0 is upward and the positive direction is CCW.
        /// </summary>
        /// <param name="vector">The target vector</param>
        /// <returns>The signed degree</returns>
        public static float GetVectorSignedDegree(Vector2 vector)
        {
            return Vector2.SignedAngle(Vector2.up, vector);
        }
    }
}
