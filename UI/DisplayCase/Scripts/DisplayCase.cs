using UnityEngine;

namespace LanKuDot.UnityToolBox.UI.DisplayCase
{
    /// <summary>
    /// The management class of the display case
    /// </summary>
    public class DisplayCase : MonoBehaviour
    {
        [SerializeField]
        private DragArea _dragArea = null;
        [SerializeField]
        private ItemContainer _itemContainer = null;
        [SerializeField]
        private float _itemGap = 1.5f;

        private Vector2 _lastDragPos;

        private void Start()
        {
            _dragArea.OnAreaBeginDrag.AddListener(OnDragBegin);
            _dragArea.OnAreaDrag.AddListener(OnDrag);
        }

        #region Item Operation

        /// <summary>
        /// Fill items to the display case. It is an initial function.
        /// </summary>
        /// <param name="items">The items to be filled</param>
        /// <param name="random">To randomize the order of items or not</param>
        public void FillItems(GameObject[] items, bool random = false)
        {
            _itemContainer.Fill(_itemGap, items, random);
        }

        /// <summary>
        /// Return the item that is not removed from the case back to its position
        /// </summary>
        /// <param name="item">The item to be returned</param>
        public void ReturnItem(GameObject item)
        {
            _itemContainer.Return(item);
        }

        /// <summary>
        /// Remove an item from the case
        /// </summary>
        /// <param name="item">The item to be removed</param>
        public void RemoveItem(GameObject item)
        {
            _itemContainer.Remove(item);
        }

        /// <summary>
        /// Add an item to the case. It will be at the top of the case
        /// </summary>
        /// <param name="item">The item to be added</param>
        public void AddItem(GameObject item)
        {
            _itemContainer.Add(item);
        }

        #endregion

        private void OnDragBegin(Vector2 mousePosition)
        {
            _lastDragPos = Camera.main.ScreenToWorldPoint(mousePosition);
        }

        /// <summary>
        /// When the DragArea is being dragged, move the item container as far as
        /// the mouse dragged.
        /// </summary>
        /// <param name="mousePosition"></param>
        private void OnDrag(Vector2 mousePosition)
        {
            var curDragPos = (Vector2) Camera.main.ScreenToWorldPoint(mousePosition);
            var deltaPos = curDragPos - _lastDragPos;
            _itemContainer.Move(deltaPos);
            _lastDragPos = curDragPos;
        }
    }
}
