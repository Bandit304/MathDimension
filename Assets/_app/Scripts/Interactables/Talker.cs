using System.Collections;
using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Interactables {
    public class Talker : Interactable {
        [Header("Dialogue Fields")]
        public string speaker;
        public string text;

        protected override void Interact() {
            StartCoroutine(DisplayDialogue());
        }

        private IEnumerator DisplayDialogue() {
            // Disable player
            if (!!InputManager.Instance)
                InputManager.Instance.DisablePlayer();
            // Display dialogue box
            if (!!DialogueBoxManager.Instance)
                DialogueBoxManager.Instance.Display(speaker, text);
            // Wait for current interaction to end
            yield return null;
            // Wait until next interaction
            yield return new WaitUntil(() => InputManager.Instance.GetInteracting());
            // Close dialogue box
            if (!!DialogueBoxManager.Instance)
                DialogueBoxManager.Instance.Close();
            // Enable player
            if (!!InputManager.Instance)
                InputManager.Instance.EnablePlayer();
        }
    }
}
