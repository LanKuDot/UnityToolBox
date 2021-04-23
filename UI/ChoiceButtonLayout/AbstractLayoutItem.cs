using UnityEngine;

namespace CommonToolBox.UI
{
    /// <summary>
    /// The basic layout item
    /// </summary>
    public abstract class AbstractLayoutItem : MonoBehaviour
    {
        /// <summary>
        /// Initialize the button
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <param name="data">The data for the item</param>
        public abstract void Initialize(int id, object data);
    }
}
