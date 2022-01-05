using System;
using System.Collections.Generic;
using UnityEngine;

namespace LanKuDot.UnityToolBox.Generic
{
    [Serializable]
    public class SerializedDictionary<TKey, TValue> :
        Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField, HideInInspector]
        private List<TKey> _keys = new List<TKey>();
        [SerializeField, HideInInspector]
        private List<TValue> _values = new List<TValue>();

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            foreach (var item in this) {
                _keys.Add(item.Key);
                _values.Add(item.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            Clear();
            var numOfItem = Mathf.Min(_keys.Count, _values.Count);
            for (var i = 0; i < numOfItem; ++i) {
                this[_keys[i]] = _values[i];
            }
        }
    }
}
