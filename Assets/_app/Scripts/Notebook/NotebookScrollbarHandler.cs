using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _app.Scripts.Notebook {
    [RequireComponent(typeof(TMP_InputField))]
    public class NotebookScrollbarHandler : MonoBehaviour {
        // ===== Fields =====

        [Header("Components")]
        [SerializeField] private Scrollbar scrollbar;

        // ===== Unity Lifecycle Events =====

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            // Get text area from game object
            TMP_InputField textArea = GetComponent<TMP_InputField>();
            // Get text area's scrollbar
            if (!!textArea) {
                scrollbar = textArea.verticalScrollbar;
            }
            // Check if scrollbar should be hidden every time it changes
            if (!!scrollbar) {
                AutoHideScrollbar();
                textArea.onValueChanged.AddListener(OnTextAreaChange);
            }

        }

        // ===== Methods =====

        private void OnTextAreaChange(string value) {
            if (!!scrollbar)
                AutoHideScrollbar();
        }

        private void AutoHideScrollbar() {
            // If text too small to scroll, hide scrollbar
            if (scrollbar.size == 1) {
                scrollbar.value = 0;
                scrollbar.gameObject.SetActive(false);
            }
            // If text can be scrolled, display scrollbar
            else
                scrollbar.gameObject.SetActive(true);
        }
    }
}
