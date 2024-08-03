using System;
using UnityEngine;

namespace _app.Scripts.Dictionary {
    [Serializable]
    public class SerializableKeyValuePair<TKey, TValue> {
        // ===== Fields =====
        
        public TKey key;
        public TValue value;
    }
}
