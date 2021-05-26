using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectScreenIndicator : MonoBehaviour
{
    public enum ShowMode
    {
        Free,
        OnlyLeftRight
    }

    [SerializeField]
    [Tooltip("The showing mode of the indicator")]
    private ShowMode _showMode;
    [SerializeField]
    [Tooltip("The transform of the target object")]
    private Transform _targetTransform;
    [SerializeField]
    [Tooltip("The object for indicating the relative position of the target object")]
    private RectTransform _indicatorObject;
    [SerializeField]
    [Tooltip("The object for pointing the direction to the target object")]
    private RectTransform _pointerObject;
    [SerializeField]
    [Tooltip("Show the indicator if the target object is within the screen")]
    private bool _showIfInScreen;
    [SerializeField]
    [Tooltip("The offset from the screen edge to limit the position of the indicator")]
    private RectOffset _borderOffset;
    [SerializeField]
    [Tooltip("The y position of the indicator when in mode OnlyLeftRight")]
    private float _indicatorPosY;
    [SerializeField]
    [Tooltip("The radius offset of the pointer object from the parent object")]
    private float _pointerObjectRadius = 100f;

    private Camera _mainCamera;
    private Rect _indicatorPositionBorder;
    private Vector2 _screenCenterPosition;
    private Image _indicatorImage;

    private readonly Color _inFrontColor = new Color(1, 1, 1, 0.8f);
    private readonly Color _atBackColor = new Color(1, 0, 0, 0.8f);

    private void Awake()
    {
        _mainCamera = Camera.main;
        _indicatorPositionBorder =
            new Rect(
                _borderOffset.left, _borderOffset.bottom,
                Screen.width - _borderOffset.horizontal,
                Screen.height - _borderOffset.vertical);
        _screenCenterPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);

        _indicatorImage = _indicatorObject.gameObject.GetComponent<Image>();
    }

    private void LateUpdate()
    {
        var objScreenPos = _mainCamera.WorldToScreenPoint(_targetTransform.position);

        // If the object is behind the camera, mirror the position
        if (objScreenPos.z < 0) {
            objScreenPos.x = _screenCenterPosition.x * 2 - objScreenPos.x;
            objScreenPos.y = _screenCenterPosition.y * 2 - objScreenPos.y;
        }

        UpdateIndicator(objScreenPos);
        UpdatePointer(objScreenPos);
    }

    /// <summary>
    /// Update the position of the indicator
    /// </summary>
    /// <param name="objScreenPos">
    /// The position of the target object in screen space
    /// </param>
    private void UpdateIndicator(Vector3 objScreenPos)
    {
        if (!_showIfInScreen && Screen.safeArea.Contains(objScreenPos)) {
            _indicatorObject.gameObject.SetActive(false);
            return;
        }

        var indicatorPos = GetClampedPosition(objScreenPos);

        _indicatorImage.color = objScreenPos.z < 0 ? _atBackColor : _inFrontColor;

        if (_showMode == ShowMode.OnlyLeftRight) {
            indicatorPos.y = _indicatorPosY;
            indicatorPos.x =
                indicatorPos.x > _screenCenterPosition.x ?
                    _indicatorPositionBorder.xMax :
                    _indicatorPositionBorder.xMin;
        }

        _indicatorObject.gameObject.SetActive(true);
        _indicatorObject.position = indicatorPos;
    }

    /// <summary>
    /// Clamp the position in the _positionBorder
    /// </summary>
    /// <param name="position">The position to be clamped</param>
    /// <returns>The clamped position</returns>
    private Vector2 GetClampedPosition(Vector2 position)
    {
        return
            new Vector2(
                Mathf.Clamp(position.x, _indicatorPositionBorder.xMin, _indicatorPositionBorder.xMax),
                Mathf.Clamp(position.y, _indicatorPositionBorder.yMin, _indicatorPositionBorder.yMax));
    }

    /// <summary>
    /// Update the position of the pointer
    /// </summary>
    /// <param name="objScreenPos">
    /// The position of the target object in the screen space
    /// </param>
    private void UpdatePointer(Vector3 objScreenPos)
    {
        if (objScreenPos.z > 0 && _indicatorPositionBorder.Contains(objScreenPos)) {
            _pointerObject.gameObject.SetActive(false);
            return;
        }

        var degree =
            MathUtils.GetVectorSignedDegree(objScreenPos - _indicatorObject.position);
        var localPosition =
            MathUtils.GetCirclePosition(Vector2.zero, _pointerObjectRadius, degree);

        _pointerObject.gameObject.SetActive(true);
        _pointerObject.localPosition = localPosition;
        _pointerObject.rotation = Quaternion.Euler(0, 0, degree);
    }
}
