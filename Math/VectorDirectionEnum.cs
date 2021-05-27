using UnityEngine;

namespace LanKuDot.UnityToolBox.Math
{
    /// <summary>
    /// The enum for the vector direction
    /// </summary>
    public enum VectorDirectionEnum
    {
        Forward,
        Back,
        Up,
        Down,
        Left,
        Right
    }

    public static class VectorDirectionEnumUtil
    {
        /// <summary>
        /// Get the unit vector from the corresponding direction enum
        /// </summary>
        /// <param name="directionEnum">The direction enum</param>
        /// <returns>The unit vector of that direction</returns>
        public static Vector3 GetVector(VectorDirectionEnum directionEnum)
        {
            switch (directionEnum) {
                case VectorDirectionEnum.Forward:
                    return Vector3.forward;
                case VectorDirectionEnum.Back:
                    return Vector3.back;
                case VectorDirectionEnum.Up:
                    return Vector3.up;
                case VectorDirectionEnum.Down:
                    return Vector3.down;
                case VectorDirectionEnum.Left:
                    return Vector3.left;
                case VectorDirectionEnum.Right:
                    return Vector3.right;
                default:
                    return Vector3.zero;
            }
        }
    }
}