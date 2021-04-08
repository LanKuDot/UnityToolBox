using UnityEngine;

/// <summary>
/// The enum for the vector direction
/// </summary>
public enum VectorDirection
{
    Forward,
    Back,
    Up,
    Down,
    Left,
    Right
}

public static class VectorDirectionUtility
{
    public static Vector3 GetVector(VectorDirection direction)
    {
        switch (direction) {
            case VectorDirection.Forward:
                return Vector3.forward;
            case VectorDirection.Back:
                return Vector3.back;
            case VectorDirection.Up:
                return Vector3.up;
            case VectorDirection.Down:
                return Vector3.down;
            case VectorDirection.Left:
                return Vector3.left;
            case VectorDirection.Right:
                return Vector3.right;
            default:
                return Vector3.zero;
        }
    }
}
