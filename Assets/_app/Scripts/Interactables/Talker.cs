using System.Collections;
using Assets._app.Scripts.Managers;
using UnityEngine;

namespace Assets._app.Scripts.Interactables {
    public class Talker : Interactable {
        [Header("Dialogue Fields")]
        public string speaker;
        public string text;

        protected override void Interact() {
            Debug.Log($"{speaker.ToUpper()}: \"{text}\"");
            StartCoroutine(DisplayDialogue());
        }

        /**
         * @TODO Try to modify interacting system to use events instead of reading the GetInteracting function in each frame
         * @BUG Currently, trying to close the dialogue box while looking at an Interactable object messes with things
         */
        private IEnumerator DisplayDialogue() {
            // Display dialogue box
            DialogueBoxManager.Instance.Display(speaker, text);
            // Wait for current interaction to end
            yield return new WaitWhile(() => InputManager.Instance.GetInteracting());
            // Wait until next interaction
            yield return new WaitUntil(() => InputManager.Instance.GetInteracting());
            // Close dialogue box
            DialogueBoxManager.Instance.Close();
        }
    }
}
