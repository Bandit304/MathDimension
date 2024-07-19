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
            PlayerController playerController = PlayerController.Instance;
            // Disable Player Interact
            if (!!playerController.playerInteract)
                playerController.playerInteract.enabled = false;
            // Disable Player Controller
            if (!!playerController)
                playerController.enabled = false;
        }

        // Enable player controller and player interact components
        public void EnablePlayer() {
            PlayerController playerController = PlayerController.Instance;
            // Enable Player Interact
            if (!!playerController.playerInteract)
                playerController.playerInteract.enabled = true;
            // Enable Player Controller
            if (!!playerController)
                playerController.enabled = true;
        }

        // Toggle notebook UI
        public bool IsTogglingNotebookUI() => playerControls.Player.ToggleNotebook.triggered;
    }
}
