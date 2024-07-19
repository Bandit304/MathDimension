using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Player {
    public class PlayerNotebookController : MonoBehaviour {
        // ===== Unity Lifecycle Events =====

        // Update is called once per frame
        void Update() {
            // Toggle notebook UI on button press
            if (
                // Check to make sure Manager instances exist in scene
                !!InputManager.Instance &&
                !!NotebookManager.Instance &&
                // Check if notebook UI can be toggled
                NotebookManager.Instance.CanToggle &&
                // Check if notebook toggle button has been pressed
                InputManager.Instance.IsTogglingNotebookUI()
            )
                NotebookManager.Instance.Toggle();
        }
    }
}
