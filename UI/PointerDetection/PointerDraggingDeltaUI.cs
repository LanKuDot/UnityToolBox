using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace LanKuDot.UnityToolBox.UI.PointerDetection
{
    /// <summary>
    /// Detect the user pointer action on ui panel
    /// </summary>
    public class PointerDraggingDeltaUI : PointerDetectionUI
    {
        #region Serialized Fields

        [SerializeField]
        [Tooltip("Convert the returned value to the ratio?")]
        private bool _convertToRatio;
        [SerializeField]
        [Tooltip("Whether to clamp the returned value or not")]
        private bool _toClampValue;
        [SerializeField]
        [Tooltip("The maximum dragging detection distance in pixel")]
        private float _maxDraggingDistance;

        #endregion

        #region Events

        public new event UnityAction<Vector2> onDragBegin;
        public new event UnityAction<Vector2> onDragging;
        public new event UnityAction<Vector2> onDragEnd;

        #endregion

        #region Private Fields

        /// <summary>
        /// The starting point of dragging action
        /// </summary>
        private Vector2 _startDraggingPos;
        /// <summary>
        /// The factor for converting the delta position to the ratio value
        /// </summary>
        private float _ratioFactor;

        #endregion

        private void Awake()
        {
            _ratioFactor = _convertToRatio ? _maxDraggingDistance : 1;
        }

        #region Handler Implementation

        public override void OnPointerDown(PointerEventData eventData)
        {
            _startDraggingPos = eventData.position;
            onDragBegin?.Invoke(Vector2.zero);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            var draggingDelta = GetDraggingDelta(eventData.position);
            onDragging?.Invoke(draggingDelta);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
             var draggingDelta = GetDraggingDelta(eventData.position);
             onDragEnd?.Invoke(draggingDelta);
        }

        #endregion

        private Vector2 GetDraggingDelta(Vector2 curPos)
        {
            var draggingDelta = curPos - _startDraggingPos;

            if (!_toClampValue)
                return draggingDelta / _ratioFactor;

            draggingDelta.x =
                Mathf.Clamp(
                    draggingDelta.x, -_maxDraggingDistance, _maxDraggingDistance);
            draggingDelta.y =
                Mathf.Clamp(
                    draggingDelta.y, -_maxDraggingDistance, _maxDraggingDistance);

            return draggingDelta / _ratioFactor;
        }
    }
}
