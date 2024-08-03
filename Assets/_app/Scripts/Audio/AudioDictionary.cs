using System.Collections.Generic;
using _app.Scripts.Dictionary;
using UnityEngine;

namespace _app.Scripts.Audio {
    [CreateAssetMenu(fileName = "AudioDictionary", menuName = "Scriptable Objects/AudioDictionary")]
    public class AudioDictionary : ScriptableObject {
        // ===== Fields =====

        [Header("Audio Groups")]
        public SerializableDictionary<string, AudioClip[]> clipDictionary;
        
        // ===== Methods =====

        public void Initialize() {
            clipDictionary.Initialize();
        }
        
        public AudioClip GetRandomClip(string groupKey) {
            // Try to get value from dictionary
            clipDictionary.TryGetValue(groupKey, out AudioClip[] output);

            // If output does not contain any audio clips, return null
            if (output.Length == 0)
                return null;
            
            // Else, return a random audio clip from output
            return output[Random.Range(0, output.Length)];
        }
    }
}
