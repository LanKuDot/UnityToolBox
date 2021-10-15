using System;
using System.Collections.Generic;
using LanKuDot.UnityToolBox.Attributes;
using UnityEngine;

namespace LanKuDot.UnityToolBox.ObjectManagement.ObjectPoolNS
{
    public class ObjectPool : MonoSingleton<ObjectPool>
    {
        [SerializeField]
        private ObjectPoolItem[] _poolItems = new ObjectPoolItem[1];

        // The name of the pool object will be the key of these dictionaries
        private readonly Dictionary<string, Queue<GameObject>> _pools =
            new Dictionary<string, Queue<GameObject>>();
        private readonly Dictionary<string, GameObject> _objectsToPool =
            new Dictionary<string, GameObject>();

        private new void Awake()
        {
            base.Awake();

            foreach (var item in _poolItems) {
                var queue = new Queue<GameObject>();
                var originalObj = item.objectToPool;
                var objName = originalObj.name;

                _pools.Add(objName, queue);

                for (var i = 0; i < item.initialNum; ++i) {
                    var obj = SpawnObject(objName);
                    obj.transform.SetParent(transform);
                    ReturnObject(obj);
                }

                _objectsToPool.Add(objName, originalObj);
            }
        }

        private GameObject SpawnObject(string objName)
        {
            var originalObj = _objectsToPool[objName];
            var newObj = Instantiate(originalObj);
            newObj.name = objName;
            return newObj;
        }

        public GameObject GetObject(string objName)
        {
            var pool = _pools[objName];
            return pool.Count == 0 ? SpawnObject(objName) : pool.Dequeue();
        }

        public void ReturnObject(GameObject obj)
        {
            if (obj.activeSelf)
                obj.SetActive(false);
            _pools[obj.name].Enqueue(obj);
        }
    }

    [Serializable]
    public class ObjectPoolItem
    {
        [ShowOnly]
        public string name;
        public GameObject objectToPool;
        public int initialNum;
    }
}