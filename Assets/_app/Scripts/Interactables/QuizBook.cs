using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Interactables
{
    public class QuizBook : Interactable
    {
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
            InputManager.Instance.DisablePlayer();
        }
    }
}
