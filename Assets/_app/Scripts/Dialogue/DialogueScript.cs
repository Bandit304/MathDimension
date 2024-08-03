using System;
using UnityEngine;

namespace _app.Scripts.Dialogue {
    [Serializable]
    public class DialogueScript {
        // ===== Fields =====
        protected int dialogueIndex = 0;
        protected Dialogue currentDialogue;
        
        [Header("Dialogue Script")]
        public Dialogue[] dialogues;

        // ===== Methods =====
        public void Open() {
            // Reset index
            dialogueIndex = 0;
            // Get & open first dialogue in script
            if (dialogues.Length > 0)
                currentDialogue = dialogues[dialogueIndex];
            currentDialogue?.Open();
        }

        public bool Next() {
            // Close current dialogue
            currentDialogue?.Close();
            // Increment dialogue index
            dialogueIndex++;
            // If all dialogue in script has been read, return false
            if (dialogueIndex >= dialogues.Length)
                return false;
            // Else, open next dialogue and return true
            currentDialogue = dialogues[dialogueIndex];
            currentDialogue?.Open();
            return true;
        }
    }
}
