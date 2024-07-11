using UnityEngine;
using _app.Scripts.Managers;
using System;

namespace _app.Scripts.Dialogue {
    [Serializable]
    public class Dialogue {
        public string speaker;
        public string text;

        public void Open() {
            // Display dialogue box
            if (!!DialogueBoxManager.Instance)
                DialogueBoxManager.Instance.Display(speaker, text);
        }

        public void Close() {
            // Close dialogue box
            if (!!DialogueBoxManager.Instance)
                DialogueBoxManager.Instance.Close();
        }
    }
}
