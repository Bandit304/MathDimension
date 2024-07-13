using System.Collections;
using _app.Scripts.Dialogue;
using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Interactables {
    public class Talker : Interactable {
        // ===== Fields =====

        [Header("Dialogue Fields")]
        public DialogueScript[] dialogueScripts;
        private int scriptIndex;

        // ===== Interactable Overrides =====

        protected override void Interact() {
            StartCoroutine(DisplayDialogue());
        }

        // ===== Methods =====

        private IEnumerator DisplayDialogue() {
            // If dialogueScripts empty, end coroutine
            if (dialogueScripts.Length == 0)
                yield break;

            // Get current script of dialogue
            DialogueScript dialogueScript = dialogueScripts[scriptIndex];

            // Disable player
            if (!!InputManager.Instance)
                InputManager.Instance.DisablePlayer();
            
            // Display dialogue box
            dialogueScript.Open();
        
            // Cycle through lines of dialogue dialogue in current script
            do {
                // Wait for current interaction to end
                yield return null;
                // Wait until next interaction
                yield return new WaitUntil(() => InputManager.Instance.GetInteracting());
            // Display next dialogue in script
            } while (dialogueScript.Next());
            
            // Move to next script of dialogue, if applicable
            if (scriptIndex < dialogueScripts.Length - 1)
                scriptIndex++;

            // Enable player
            if (!!InputManager.Instance)
                InputManager.Instance.EnablePlayer();
        }
    }
}
