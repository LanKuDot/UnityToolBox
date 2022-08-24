using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace LanKuDot.UnityToolBox.UI.Utils
{
    /// <summary>
    /// The object pool for managing the ui objects
    /// </summary>
    public class UIObjectPool<T>
        where T : MonoBehaviour
    {
        private readonly ObjectPool<T> _objectPool;
        private readonly List<T> _activationList = new ();
        private readonly Action<T> _onCreate;

        /// <summary>
        /// The object pool for managing the ui objects
        /// </summary>
        /// <param name="onCreate">
        /// The callback to be invoked when it is going to create new ui object
        /// </param>
        public UIObjectPool(Func<T> onCreate)
        {
            _objectPool = new ObjectPool<T>(onCreate, OnGet, OnRelease, OnDestroy);
        }

        /// <summary>
        /// Get a ui object from the pool
        /// </summary>
        /// The returned object will be stored in the internal activation list
        public T Get()
        {
            var uiObject = _objectPool.Get();
            _activationList.Add(uiObject);
            return uiObject;
        }

        /// <summary>
        /// Find the specified ui object in the activated ones
        /// </summary>
        public T Find(Predicate<T> match) =>
            _activationList.Find(match);

        /// <summary>
        /// Release all the ui objects in the internal activation list
        /// </summary>
        public void ReleaseAll()
        {
            foreach (var uiObject in _activationList)
                _objectPool.Release(uiObject);
            _activationList.Clear();
        }

        private void OnGet(T uiObject)
        {}

        private void OnRelease(T uiObject) =>
            uiObject.gameObject.SetActive(false);

        private void OnDestroy(T uiObject) =>
            Object.Destroy(uiObject.gameObject);
    }
}
