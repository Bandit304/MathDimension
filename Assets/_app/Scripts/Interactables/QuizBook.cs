using UnityEngine;

namespace _app.Scripts.Interactables
{
    public class QuizBook : Interactable
    {
        [SerializeField] private InputManager inputs;
        protected override void Interact()
        {
            // Disable Player Movement and Enable Mouse Movement
            DisableMovement();
            // Display Quiz Menu
            UIManager.Instance.StartQuiz();
        }

        private void DisableMovement()
        {
            Cursor.lockState = CursorLockMode.Confined;
            inputs.enabled = false;
        }
        
        private void EnableMovement()
        {
            Cursor.lockState = CursorLockMode.Locked;
            inputs.enabled = true;
        }
    }
}
