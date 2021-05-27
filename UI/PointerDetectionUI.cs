using UnityEngine;
using UnityEngine.EventSystems;

namespace LanKuDot.UnityToolBox.UI
{
    /// <summary>
    /// Detect the user pointer action on ui panel
    /// </summary>
    public class PointerDetectionUI : MonoBehaviour,
        IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        #region Serialized Fields

        [SerializeField]
        [Tooltip("The maximum dragging detection distance in pixel")]
        private float _maxDraggingDistance;

        #endregion

        #region Protected Fields

        /// <summary>
        /// Is the control detection UI being pressing?
        /// </summary>
        protected bool isPressing { get; private set; }
        /// <summary>
        /// Similar to <c>draggingRatio</c> but its value is not clamped into [-1, 1]
        /// </summary>
        protected Vector2 draggingRatioUnclamped => _draggingRatioUnclamped;
        /// <summary>
        /// The ratio between the dragging distance and _maxDraggingDistance.
        /// Its value is within [-1, 1].
        /// </summary>
        protected Vector2 draggingRatio =>
            new Vector2(
                Mathf.Clamp(_draggingRatioUnclamped.x, -1, 1),
                Mathf.Clamp(_draggingRatioUnclamped.y, -1, 1)
            );

        #endregion

        #region Private Fields

        /// <summary>
        /// The starting point of dragging action
        /// </summary>
        private Vector2 _startDraggingPos;
        private Vector2 _draggingRatioUnclamped;

        #endregion

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressing = true;
            _startDraggingPos = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var draggingDelta = eventData.position - _startDraggingPos;
            _draggingRatioUnclamped.x = draggingDelta.x / _maxDraggingDistance;
            _draggingRatioUnclamped.y = draggingDelta.y / _maxDraggingDistance;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressing = false;
            _draggingRatioUnclamped = Vector2.zero;
        }
    }
}
