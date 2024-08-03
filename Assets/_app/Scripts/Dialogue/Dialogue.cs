using UnityEngine;
using _app.Scripts.Managers;
using System;
using Random = UnityEngine.Random;

namespace _app.Scripts.Dialogue {
    [Serializable]
    public class Dialogue {
        public string speaker;
        [TextArea]
        public string text;
        public AudioClip[] audioClips;

        public void Open() {
            // Display dialogue box
            if (!!DialogueBoxManager.Instance)
                DialogueBoxManager.Instance.Display(speaker, text);
            if (!!AudioManager.Instance && audioClips?.Length != 0) {
                AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
                AudioManager.Instance.PlayGlobalAudio(randomClip);
            }
        }

        public void Close() {
            // Close dialogue box
            if (!!DialogueBoxManager.Instance)
                DialogueBoxManager.Instance.Close();
        }
    }
}
