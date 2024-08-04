using System;
using System.Collections;
using _app.Scripts.Dialogue;
using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Interactables {
    public class Talker : Interactable {
        // ===== Fields =====

        [Header("Dialogue Fields")]
        // Dictionary keys of dialogue scripts in DialogueData file
        [SerializeField] private string[] dialogueScriptKeys;
        private int scriptIndex;

        // ===== Interactable Overrides =====

        protected override void Interact() {
            StartCoroutine(DisplayDialogue());
        }

        // ===== Methods =====

        private IEnumerator DisplayDialogue() {
            // If dialogueScripts empty, end coroutine
            if (dialogueScriptKeys.Length == 0)
                yield break;

            // Get current script of dialogue
            DialogueScript dialogueScript = null;

            // Get next dialogue script from key
            if (!!DialogueBoxManager.Instance && dialogueScriptKeys.Length != 0)
                dialogueScript = DialogueBoxManager.Instance.GetScript(dialogueScriptKeys[scriptIndex]);
                
            // Increment script index
            if (scriptIndex < dialogueScriptKeys.Length - 1)
                scriptIndex++;

            // If no defined dialogue script was found, exit coroutine
            if (dialogueScript == null)
                yield break;

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

            // Enable player
            if (!!InputManager.Instance)
                InputManager.Instance.EnablePlayer();
        }
    }
}
