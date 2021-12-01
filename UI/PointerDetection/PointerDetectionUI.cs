using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace LanKuDot.UnityToolBox.UI.PointerDetection
{
    /// <summary>
    /// Detect the pointer action on UI panel
    /// </summary>
    public class PointerDetectionUI : MonoBehaviour,
        IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        #region Events

        public event UnityAction<Vector2> onDragBegin;
        public event UnityAction<Vector2> onDragging;
        public event UnityAction<Vector2> onDragEnd;

        #endregion

        #region Handler Implementation

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            onDragBegin?.Invoke(eventData.position);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            onDragEnd?.Invoke(eventData.position);
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            onDragging?.Invoke(eventData.position);
        }

        #endregion
    }
}
