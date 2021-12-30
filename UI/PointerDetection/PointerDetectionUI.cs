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

        public event UnityAction<PointerEventData> onDragBegin;
        public event UnityAction<PointerEventData> onDragging;
        public event UnityAction<PointerEventData> onDragEnd;

        #endregion

        #region Handler Implementation

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            onDragBegin?.Invoke(eventData);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            onDragEnd?.Invoke(eventData);
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            onDragging?.Invoke(eventData);
        }

        #endregion
    }
}
