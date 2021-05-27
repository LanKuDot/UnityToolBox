using System.Collections.Generic;
using UnityEngine;

namespace LanKuDot.UnityToolBox.UI.DisplayCase
{
    /// <summary>
    /// The container for holding the items passed to the display case
    /// </summary>
    public class ItemContainer : MonoBehaviour
    {
        /// <summary>
        /// The items in the container
        /// </summary>
        private List<GameObject> _items;
        /// <summary>
        /// The range of moving distance of the container
        /// </summary>
        private Rect _distanceRange;
        /// <summary>
        /// The gap between items
        /// </summary>
        private float _itemGap;

        /// <summary>
        /// Fill the items to the container from bottom to up
        /// </summary>
        /// <param name="itemGap">The gap between items</param>
        /// <param name="items">The items to be filled</param>
        /// <param name="random">
        /// Whether to randomize items in the container or not
        /// </param>
        public void Fill(
            float itemGap, GameObject[] items, bool random)
        {
            _itemGap = itemGap;
            _items = new List<GameObject>(items);
            if (random)
                RandomizeItems();

            var numOfItems = _items.Count;

            for (var i = 0; i < numOfItems; ++i) {
                var itemTransform = _items[i].transform;
                itemTransform.SetParent(transform);
                itemTransform.localPosition = GetItemPosition(numOfItems, i);
            }

            _distanceRange =
                Rect.MinMaxRect(
                    0, -_items[numOfItems - 1].transform.localPosition.y,
                    0, -_items[0].transform.localPosition.y);
        }

        /// <summary>
        /// Randomize the order of items in container
        /// </summary>
        private void RandomizeItems()
        {
            var result = new List<GameObject>();

            while (_items.Count > 0) {
                var randomID = Random.Range(0, _items.Count);
                result.Add(_items[randomID]);
                _items.RemoveAt(randomID);
            }

            _items = result;
        }

        /// <summary>
        /// Get the item position according to total number of items
        /// </summary>
        /// <param name="numOfItems">The total number of items</param>
        /// <param name="index">The index of the item</param>
        /// <returns>The local position in the container</returns>
        private Vector3 GetItemPosition(int numOfItems, int index)
        {
            return _itemGap * (index - numOfItems / 2) * Vector3.up;
        }

        /// <summary>
        /// Move the items
        /// </summary>
        /// <param name="deltaPosition">
        /// The distance in the world space to be moved
        /// </param>
        public void Move(Vector2 deltaPosition)
        {
            transform.position += Vector3.up * deltaPosition.y;
            ClampDistance();
        }

        /// <summary>
        /// Clamp the distance of container not to exceed the range of moving distance
        /// </summary>
        private void ClampDistance()
        {
            var localPosition = transform.localPosition;
            localPosition.y =
                Mathf.Clamp(
                    localPosition.y, _distanceRange.yMin, _distanceRange.yMax);
            transform.localPosition = localPosition;
        }

        /// <summary>
        /// Return the item back to the container
        /// </summary>
        public void Return(GameObject item)
        {
            var id = _items.IndexOf(item);

            if (id == -1) {
                Debug.LogError($"Item {item.name} is not in the display case");
                return;
            }

            var itemTransform = item.transform;
            itemTransform.SetParent(transform);
            itemTransform.localPosition = GetItemPosition(_items.Count, id);
        }

        /// <summary>
        /// Remove item from the container
        /// </summary>
        public void Remove(GameObject item)
        {
            var id = _items.IndexOf(item);
            var numOfItems = _items.Count;

            // Make items get close to the center
            if ((numOfItems & 1) == 1) {
                for (var i = id + 1; i < numOfItems; ++i)
                    _items[i].transform.localPosition += Vector3.down * _itemGap;

                _distanceRange.yMin += _itemGap;
            } else {
                for (var i = id - 1; i > -1; --i)
                    _items[i].transform.localPosition += Vector3.up * _itemGap;

                _distanceRange.yMax -= _itemGap;
            }

            ClampDistance();
            _items.RemoveAt(id);
        }

        /// <summary>
        /// Add an item to the container
        /// </summary>
        /// <param name="item"></param>
        public void Add(GameObject item)
        {
            var id = _items.IndexOf(item);

            if (id != -1) {
                Debug.LogError($"Item {item.name} is already in the display case");
                return;
            }

            _items.Add(item);

            var numOfItems = _items.Count;
            var itemTransform = item.transform;
            itemTransform.SetParent(transform);
            itemTransform.localPosition =
                GetItemPosition(numOfItems, numOfItems - 1);

            if ((numOfItems & 1) == 0) {
                // If the number of items becomes even, move the whole items 1 unit back
                for (var i = 0; i < numOfItems - 1; ++i)
                    _items[i].transform.localPosition += Vector3.down * _itemGap;

                _distanceRange.yMax += _itemGap;
            } else
                _distanceRange.yMin -= _itemGap;

            ClampDistance();
        }
    }
}
