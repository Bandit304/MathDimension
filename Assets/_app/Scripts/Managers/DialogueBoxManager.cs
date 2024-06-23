using TMPro;
using UnityEngine;

namespace Assets._app.Scripts.Managers {
    public class DialogueBoxManager : MonoBehaviour {
        [Header("Singleton Reference")]
        public static DialogueBoxManager Instance { get; private set; }

        [Header("Dialogue UI Components")]
        public Canvas dialogueUI;
        public TMP_Text dialogueSpeaker;
        public TMP_Text dialogueText;

        // Awake is called once before the first execution of Start after the MonoBehaviour is created
        void Awake() {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        void Start() {
            // Hide dialogue UI on startup
            if (!!dialogueUI)
                dialogueUI.enabled = false;
        }

        public void Display(string speaker, string text) {
            // Set dialogue speaker
            if (!!dialogueSpeaker)
                dialogueSpeaker.text = speaker;
            // Set dialogue text
            if (!!dialogueText)
                dialogueText.text = text;
            // Display dialogue UI
            if (!!dialogueUI)
                dialogueUI.enabled = true;
        }

        public void Close() {
            // Set dialogue speaker
            if (!!dialogueSpeaker)
                dialogueSpeaker.text = "";
            // Set dialogue text
            if (!!dialogueText)
                dialogueText.text = "";
            // Display dialogue UI
            if (!!dialogueUI)
                dialogueUI.enabled = false;
        }
    }
}
