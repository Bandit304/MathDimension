using UnityEngine;
using _app.Scripts.Managers;
using System;

namespace _app.Scripts.Dialogue {
    [Serializable]
    public class Dialogue {
        [Header("Dialogue Display")]
        public string speaker;
        [TextArea]
        public string text;

        [Header("Dialogue Audio")]
        // Dictionary key of dialogue audio in AudioDictionary file
        public string audioKey;

        public void Open() {
            // Display dialogue box
            if (!!DialogueBoxManager.Instance)
                DialogueBoxManager.Instance.Display(speaker, text);
            if (!!AudioManager.Instance && audioKey != "") {
                AudioManager.Instance.PlayRandomAudioFromKey(audioKey);
            }
        }

        public void Close() {
            // Close dialogue box
            if (!!DialogueBoxManager.Instance)
                DialogueBoxManager.Instance.Close();
        }
    }
}
