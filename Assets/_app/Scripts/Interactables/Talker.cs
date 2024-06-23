using UnityEngine;

namespace Assets._app.Scripts.Interactables {
    public class Talker : Interactable {
        [Header("Dialogue Fields")]
        public string speaker;
        public string text;

        protected override void Interact() {
            Debug.Log($"{speaker.ToUpper()}: \"{text}\"");
        }
    }
}
