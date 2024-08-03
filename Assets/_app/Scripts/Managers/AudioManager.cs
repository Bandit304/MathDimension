using UnityEngine;

namespace _app.Scripts.Managers {
    public class AudioManager : MonoBehaviour {
        // ===== Fields =====
        [Header("Singleton Reference")]
        public static AudioManager Instance { get; private set; }

        [Header("Audio Components")]
        public AudioSource GlobalAudioSource;

        // ===== Unity Lifecycle Events =====

        // Awake is called once before the first execution of Start after the MonoBehaviour is created
        void Awake() {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        // ===== Methods =====

        public void PlayGlobalAudio(AudioClip audioClip) {
            if (!!GlobalAudioSource) {
                GlobalAudioSource.clip = audioClip;
                GlobalAudioSource.Play();
            }
        }
    }
}
