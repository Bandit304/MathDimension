using _app.Scripts.Notebook;
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

        [Header("Notebook Data Storage")]
        public NotebookData data;

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

        // Stores cursor lock state for opening notebook UI over other UI
        private CursorLockMode originalLockState;

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

            if (!!data && !!notebookText) {
                // Retrieve notebook contents
                notebookText.text = data.notebookContents;
                // Set TextArea to save contents when done editing
                notebookText.onEndEdit.AddListener(SaveNotebookContents);
            }
        }

        // ===== Methods =====

        private void Display() {
            // Disable player movement
            InputManager.Instance.DisablePlayer();
            // Store current lock state
            originalLockState = Cursor.lockState;
            // Allow use of mouse
            Cursor.lockState = CursorLockMode.Confined;
            // Display notebook UI
            if (!!notebookUI)
                notebookUI.enabled = true;
        }
        
        private void Close() {
            // Disable player movement
            InputManager.Instance.EnablePlayer();
            // Restore cursor lock state
            Cursor.lockState = originalLockState;
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

        // For use in the TMP_InputField's OnEditEnd event
        public void SaveNotebookContents(string contents) {
            if (!!data)
                data.notebookContents = contents;
        }
    }
}
