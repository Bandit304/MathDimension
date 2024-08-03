using _app.Scripts.Audio;
using UnityEngine;

namespace _app.Scripts.Managers {
    public class AudioManager : MonoBehaviour {
        // ===== Fields =====
        [Header("Singleton Reference")]
        public static AudioManager Instance { get; private set; }

        [Header("Audio Components")]
        public AudioSource GlobalAudioSource;

        [Header("Audio Data")]
        public AudioDictionary audioDictionary;

        // ===== Unity Lifecycle Events =====

        // Awake is called once before the first execution of Start after the MonoBehaviour is created
        void Awake() {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        void Start() {
            audioDictionary.clipDictionary.Initialize();
        }

        // ===== Methods =====

        public void PlayGlobalAudio(AudioClip audioClip) {
            if (!!GlobalAudioSource && !!audioClip) {
                GlobalAudioSource.clip = audioClip;
                GlobalAudioSource.Play();
            }
        }

        public void PlayRandomAudioFromKey(string audioKey) =>
            PlayGlobalAudio(audioDictionary.GetRandomClip(audioKey));
    }
}
