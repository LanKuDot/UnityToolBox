using UnityEngine;

namespace LanKuDot.UnityToolBox.Math
{
    /// <summary>
    /// The calculator about a sphere
    /// </summary>
    public class SphereResolver
    {
        private readonly Vector3 _origin;
        private readonly float _radius;

        /// <summary>
        /// The calculator about a sphere
        /// </summary>
        /// <param name="origin">The origin of the sphere</param>
        /// <param name="radius">The radius of the sphere</param>
        public SphereResolver(Vector3 origin, float radius)
        {
            _origin = origin;
            _radius = radius;
        }

        /// <summary>
        /// Get the point on the sphere surface
        /// </summary>
        /// <param name="pitchDeg">The angle of the pitch axis in degree</param>
        /// <param name="yawDeg">The angle of the yaw axis in degree</param>
        /// <returns>The coordinate on the surface</returns>
        public Vector3 GetPointOnSurface(float pitchDeg, float yawDeg)
        {
            var pitchRad = pitchDeg * Mathf.Deg2Rad;
            var yawRad = yawDeg * Mathf.Deg2Rad;

            var height = _radius * Mathf.Sin(pitchRad);
            var cutPlaneRadius = _radius * Mathf.Cos(pitchRad);

            var cutPlaneX = cutPlaneRadius * Mathf.Sin(yawRad);
            var curPlaneZ = cutPlaneRadius * Mathf.Cos(yawRad);

            return new Vector3(cutPlaneX, height, curPlaneZ) + _origin;
        }

        /// <summary>
        /// Get the pitch and yaw angle in degree according to the point
        /// </summary>
        /// <param name="point">
        /// The target position which is converted to the closest point on the sphere surface
        /// </param>
        /// <param name="pitchDeg">The angle of the pitch axis in degree</param>
        /// <param name="yawDeg">The angle of the yaw axis in degree</param>
        public void GetClosestPitchAndYewDeg(
            Vector3 point, out float pitchDeg, out float yawDeg)
        {
            var unitVector = (point - _origin).normalized;
            pitchDeg = Mathf.Asin(unitVector.y) * Mathf.Rad2Deg;
            yawDeg = Mathf.Asin(unitVector.x) * Mathf.Rad2Deg;
            if (unitVector.z <= 0)
                yawDeg = 180 - yawDeg;
        }

        /// <summary>
        /// Get the closest point on the sphere surface
        /// </summary>
        /// <param name="point">The reference point</param>
        /// <returns>The point on the sphere surface</returns>
        public Vector3 GetClosestSurfacePoint(Vector3 point)
        {
            var vector = point - _origin;
            return vector.normalized * _radius + _origin;
        }
    }
}
