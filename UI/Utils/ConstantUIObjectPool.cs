using System;
using System.Collections.Generic;
using UnityEngine;

namespace LanKuDot.UnityToolBox.UI.Utils
{
    /// <summary>
    /// The object pool for managing the constant number of ui objects
    /// </summary>
    /// <typeparam name="T">The type of the ui object</typeparam>
    public class ConstantUIObjectPool<T>
        where T : MonoBehaviour
    {
        private readonly Queue<T> _objectQueue = new ();
        private readonly List<T> _activationList = new ();

        /// <summary>
        /// The object pool for managing the constant number of ui objects
        /// </summary>
        /// <param name="objects">The available objects</param>
        public ConstantUIObjectPool(IEnumerable<T> objects)
        {
            foreach (var obj in objects) {
                obj.gameObject.SetActive(false);
                _objectQueue.Enqueue(obj);
            }
        }

        /// <summary>
        /// Are there objects in the pool?
        /// </summary>
        public bool HasObject() =>
            _objectQueue.Count > 0;

        /// <summary>
        /// Get an ui object from the pool
        /// </summary>
        /// The returned object will be stored in the internal activation list
        /// <exception cref="InvalidOperationException">
        /// There has no more object to return from the pool
        /// </exception>
        public T Get()
        {
            if (!HasObject())
                throw new InvalidOperationException("There has no object in the pool");

            var obj = _objectQueue.Dequeue();
            _activationList.Add(obj);
            return obj;
        }

        /// <summary>
        /// Release all the ui objects in the internal activation list
        /// </summary>
        public void ReleaseAll()
        {
            foreach (var obj in _activationList) {
                obj.gameObject.SetActive(false);
                _objectQueue.Enqueue(obj);
            }
            _activationList.Clear();
        }
    }
}
