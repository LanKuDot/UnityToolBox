using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace LanKuDot.UnityToolBox.UI.PointerDetection
{
    public class PointerRaycastingUI : MonoBehaviour,
        IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField]
        private Camera _targetCamera;

        public event UnityAction<Ray> onDragBegin;
        public event UnityAction<Ray> onDragging;
        public event UnityAction<Ray> onDragEnd;

        private Ray GetRay(Vector2 screenPos)
        {
            return _targetCamera.ScreenPointToRay(screenPos);
        }

        #region Handler Implementation

        public void OnPointerDown(PointerEventData eventData)
        {
            onDragBegin?.Invoke(GetRay(eventData.position));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onDragging?.Invoke(GetRay(eventData.position));
        }

        public void OnDrag(PointerEventData eventData)
        {
            onDragEnd?.Invoke(GetRay(eventData.position));
        }

        #endregion
    }
}
