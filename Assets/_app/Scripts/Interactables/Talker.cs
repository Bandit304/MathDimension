using System.Collections;
using _app.Scripts.Dialogue;
using UnityEngine;

namespace _app.Scripts.Interactables {
    public class Talker : Interactable {
        [Header("Dialogue Fields")]
        public DialogueScript dialogueScript;

        protected override void Interact() {
            StartCoroutine(DisplayDialogue());
        }

        private IEnumerator DisplayDialogue() {
            // Disable player
            if (!!InputManager.Instance)
                InputManager.Instance.DisablePlayer();
            // Display dialogue box
            if (!!dialogueScript)
                dialogueScript.Open();
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
