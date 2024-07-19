using TMPro;
using UnityEngine;

namespace _app.Scripts.Managers {
    public class NotebookManager : MonoBehaviour {
        // ===== Fields =====
        [Header("Singleton Reference")]
        public static NotebookManager Instance { get; private set; }

        [Header("Notebook UI")]
        [SerializeField] private Canvas notebookUI;
        private TMP_InputField notebookText;

        [Header("UI Toggle Flags")]
        // Fields that determine if the notebook UI can be toggled or not.
        public bool CanToggle { 
            get {
                bool _canToggle = !!notebookText && !notebookText.isFocused;
                if (!!DialogueBoxManager.Instance)
                    _canToggle = _canToggle && !DialogueBoxManager.Instance.IsDisplaying;
                return _canToggle;
            }
        }

        // ===== Unity Lifecycle Events =====

        // Awake is called once before the first execution of Start after the MonoBehaviour is created
        void Awake() {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        private void Start() {
            // Hide notebook UI on startup
            if (!!notebookUI) {
                notebookUI.enabled = false;
                notebookText = notebookUI.GetComponentInChildren<TMP_InputField>();
            }
        }

        // ===== Methods =====

        private void Display() {
            // Disable player movement
            InputManager.Instance.DisablePlayer();
            // Allow use of mouse
            Cursor.lockState = CursorLockMode.Confined;
            // Display notebook UI
            if (!!notebookUI)
                notebookUI.enabled = true;
        }
        
        private void Close() {
            // Disable player movement
            InputManager.Instance.EnablePlayer();
            // Allow use of mouse
            Cursor.lockState = CursorLockMode.Locked;
            // Display notebook UI
            if (!!notebookUI)
                notebookUI.enabled = false;
        }

        public void Toggle() {
            // If notebook is not displaying, display notebook
            if (!!notebookUI && !notebookUI.enabled) {
                Display();
                // Disable other UI elements
                if (!!UIManager.Instance)
                    UIManager.Instance.enabled = false;
            }
            // If notebook is displaying, hide notebook
            else if (!!notebookUI && notebookUI.enabled) {
                Close();
                // Enable other UI elements
                if (!!UIManager.Instance)
                    UIManager.Instance.enabled = true;
            }
        }
    }
}
