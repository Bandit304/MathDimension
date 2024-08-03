using System;
using _app.Scripts.Dictionary;
using UnityEngine;

namespace _app.Scripts.Dialogue {
    [CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
    public class DialogueData : ScriptableObject {
        // ===== Fields =====
        public SerializableDictionary<string, DialogueScript> scripts;
        
        // ===== Constructors =====
        
        // ===== Methods =====
        public DialogueScript GetScript(string scriptKey) {
            // If script exists, get script
            if (scripts.TryGetValue(scriptKey, out DialogueScript script))
                return script;

            // Else, return null
            return null;
        }
    }
}
