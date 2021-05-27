using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace LanKuDot.UnityToolBox.UI.DisplayCase
{
    [Serializable]
    public class BeginDragAreaEvent : UnityEvent<Vector2>
    {}

    [Serializable]
    public class DragAreaEvent : UnityEvent<Vector2>
    {}

    [Serializable]
    public class EndDragAreaEvent : UnityEvent<Vector2>
    {}

    /// <summary>
    /// Detect the dragging operation on the area defined by the collider
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    public class DragArea :
        MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public BeginDragAreaEvent OnAreaBeginDrag;
        public DragAreaEvent OnAreaDrag;
        public EndDragAreaEvent OnAreaEndDrag;

        private void Reset()
        {
            var collider = GetComponent<BoxCollider2D>();
            collider.isTrigger = true;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnAreaBeginDrag.Invoke(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnAreaDrag.Invoke(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnAreaEndDrag.Invoke(eventData.position);
        }
    }
}
