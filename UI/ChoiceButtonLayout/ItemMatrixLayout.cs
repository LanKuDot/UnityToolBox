using System.Collections.Generic;
using UnityEngine;

namespace LanKuDot.UnityToolBox.UI.ChoiceButtonLayout
{
    /// <summary>
    /// The layout for arranging created items
    /// </summary>
    public class ItemMatrixLayout<T> : MonoBehaviour where T : AbstractLayoutItem
    {
        [SerializeField]
        [Tooltip("The prefab for making items")]
        private GameObject _itemPrefab;
        [SerializeField]
        [Tooltip("The number of items per row")]
        private int _itemsPerRow = 3;
        [SerializeField]
        [Tooltip("The gap between items")]
        private Vector2 _itemGap = new Vector2(40, 40);

        protected T[] items;

        /// <summary>
        /// Create items and setup its data
        /// </summary>
        /// <param name="itemDatas">The datas for each item</param>
        protected void CreateItems(object[] itemDatas)
        {
            var numOfItems = itemDatas.Length;
            var positionAdjust =
                new Vector2(
                    (-(_itemsPerRow / 2) + ((_itemsPerRow & 1) == 0 ? 0.5f : 0))
                    * _itemGap.x,
                    0);
            var createdItems = new List<T>();

            for (var i = 0; i < numOfItems; ++i) {
                var newObj = Instantiate(_itemPrefab, transform);

                var rectTransform = newObj.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = GetItemPosition(i, positionAdjust);

                var item = newObj.GetComponent<T>();
                item.Initialize(i, itemDatas[i]);
                createdItems.Add(item);
            }

            items = createdItems.ToArray();
        }

        /// <summary>
        /// Determine the position of an item in the layout
        /// </summary>
        /// <param name="id">The index of the item</param>
        /// <param name="origin">The position of the first item</param>
        /// <returns>The position</returns>
        private Vector2 GetItemPosition(int id, Vector2 origin)
        {
            var position =
                new Vector2(
                    (id % _itemsPerRow) * _itemGap.x,
                    -(id / _itemsPerRow) * _itemGap.y
                );

            return origin + position;
        }
    }
}
