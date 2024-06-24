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

        /**
         * @TODO Try to modify interacting system to use events instead of reading the GetInteracting function in each frame
         * @BUG Currently, trying to close the dialogue box while looking at an Interactable object messes with things
         */
        private IEnumerator DisplayDialogue() {
            // Set isInteracting to true
            isInteracting = true;
            // Display dialogue box
            DialogueBoxManager.Instance.Display(speaker, text);
            // Wait for current interaction to end
            yield return new WaitWhile(() => InputManager.Instance.GetInteracting());
            // Wait until next interaction
            yield return new WaitUntil(() => InputManager.Instance.GetInteracting());
            // Close dialogue box
            DialogueBoxManager.Instance.Close();
            // Set isInteracting to false
            isInteracting = false;
        }
    }
}
