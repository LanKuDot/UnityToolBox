using UnityEngine;

namespace LanKuDot.UnityToolBox.ObjectManagement.Raycasting
{
    /// <summary>
    /// The object that is raycastable
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class RaycastableObject : MonoBehaviour
    {
        private Collider _collider;
        /// <summary>
        /// Is this object raycastable?
        /// </summary>
        public bool raycastable
        {
            set => _collider.enabled = value;
            get => _collider.enabled;
        }

        protected void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        /// <summary>
        /// Select the object
        /// </summary>
        public virtual void Select()
        {
        }

        /// <summary>
        /// Unselect the object
        /// </summary>
        public virtual void UnSelect()
        {
        }
    }
}
