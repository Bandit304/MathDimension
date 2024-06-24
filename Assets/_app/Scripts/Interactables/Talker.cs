using System.Collections;
using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Interactables {
    public class Talker : Interactable {
        [Header("Dialogue Fields")]
        public string speaker;
        public string text;

        [Header("Interaction Flags")]
        private bool isInteracting = false;

        protected override void Interact() {
            // If not interacting, display dialogue
            if (!isInteracting)
                StartCoroutine(DisplayDialogue());
        }

        private IEnumerator DisplayDialogue() {
            // Set isInteracting to true
            isInteracting = true;
            // Display dialogue box
            DialogueBoxManager.Instance.Display(speaker, text);
            // Wait for current interaction to end
            yield return null;
            // Wait until next interaction
            yield return new WaitUntil(() => InputManager.Instance.GetInteracting());
            // Close dialogue box
            DialogueBoxManager.Instance.Close();
            // Set isInteracting to false
            isInteracting = false;
        }
    }
}
