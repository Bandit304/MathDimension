using System.Collections.Generic;
using _app.Scripts.Dialogue;
using TMPro;
using UnityEngine;

namespace _app.Scripts.Managers {
    public class DialogueBoxManager : MonoBehaviour {
        [Header("Singleton Reference")]
        public static DialogueBoxManager Instance { get; private set; }

        [Header("Dialogue UI Components")]
        public Canvas dialogueUI;
        public TMP_Text dialogueSpeaker;
        public TMP_Text dialogueText;

        [Header("Flags for other managers")]
        public bool IsDisplaying { get; private set; }

        [Header("Dialogue Data")]
        public DialogueData dialogueData;

        // Awake is called once before the first execution of Start after the MonoBehaviour is created
        void Awake() {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);

            // Initialize dialogueData dictionary
            if (!!dialogueData)
                dialogueData.scripts.Initialize();
        }

        void Start() {
            // Hide dialogue UI on startup
            if (!!dialogueUI)
                dialogueUI.enabled = false;
        }

        public void Display(string speaker, string text) {
            // Set IsDisplaying flag to true
            IsDisplaying = true;
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
            // set IsDisplaying flag to false
            IsDisplaying = false;
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

        public DialogueScript[] GetScripts(string[] scriptKeys) {
            // If dialogue data does not exist, return
            if (!dialogueData)
                return null;
            // Create list of dialogue scripts
            List<DialogueScript> scripts = new List<DialogueScript>();
            // Get scripts from scriptKeys
            foreach (string scriptKey in scriptKeys)
                scripts.Add(dialogueData.GetScript(scriptKey));
            // Return list of scripts, converted to array
            return scripts.ToArray();
        }
    }
}
