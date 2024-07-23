using _app.Scripts.Player;
using UnityEngine;

namespace _app.Scripts.Managers
{
    public class InputManager : MonoBehaviour
    {
        // this is a singleton as we will only need one input manager
        private static InputManager _instance;
        public static InputManager Instance
        {
            get
            {
                return _instance;
            }
        }
    
        private PlayerInputs playerControls;

        // int keeping track of how many things currently require the player to be disabled
        private int disableCount;

        private void Awake()
        {
            // playerControls manages input from the Player Input System
            if (_instance != null && _instance != this)
            {
                // this destroys the current instance if another one exists
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
            playerControls = new PlayerInputs();
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        public Vector2 GetPlayerMovement()
        {
            return playerControls.Player.Movement.ReadValue<Vector2>();
        }
    
        public Vector2 GetMouseDelta()
        {
            return playerControls.Player.Look.ReadValue<Vector2>();
        }

        public bool GetInteracting()
        {
            return playerControls.Player.Interact.triggered;
        }

        // Disable player controller and player interact components
        public void DisablePlayer() {
            // Increment disable count
            disableCount++;

            // If player is still enabled, disable player
            if (disableCount == 1) {
                PlayerController playerController = PlayerController.Instance;
                // Disable Player Interact
                if (!!playerController.playerInteract)
                    playerController.playerInteract.enabled = false;
                // Disable Player Controller
                if (!!playerController)
                    playerController.enabled = false;
            }
        }

        // Enable player controller and player interact components
        public void EnablePlayer() {
            // Decrement disable count
            disableCount--;

            // If nothing requires the player to be disabled, enable player
            if (disableCount == 0) {
                PlayerController playerController = PlayerController.Instance;
                // Enable Player Interact
                if (!!playerController.playerInteract)
                    playerController.playerInteract.enabled = true;
                // Enable Player Controller
                if (!!playerController)
                    playerController.enabled = true;
            }
        }

        // Toggle notebook UI
        public bool IsTogglingNotebookUI() => playerControls.Player.ToggleNotebook.triggered;
    }
}
