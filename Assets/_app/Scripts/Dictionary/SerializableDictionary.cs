using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

namespace _app.Scripts.Dictionary {
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue> {
        // ===== Fields =====

        [Header("Dictionary Fields")]
        [SerializeField] private SerializableKeyValuePair<TKey, TValue>[] _dictionary;
        
        // ===== Methods =====
        public void Initialize() {
            // Clear dictionary
            Clear();

            // Add Key/Value Pairs to dictionary
            foreach(SerializableKeyValuePair<TKey, TValue> pair in _dictionary)
                Add(pair.key, pair.value);
        }
    }
}
