using UnityEngine;

namespace _app.Scripts.Managers {
    public class EnvironmentTintManager : MonoBehaviour {
        // ===== Fields =====

        public enum Stages { None, Traditional, Simple, Intermediate, Complex }

        [Header("Singleton Reference")]
        public static EnvironmentTintManager Instance { get; private set; }

        [Header("Environment Materials")]
        public Material[] envMaterials;

        [Header("Game Stage")]
        public Stages stage;

        // ===== Unity Lifecycle Events =====

        // Awake is called once before the first execution of Start after the MonoBehaviour is created
        void Awake() {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        public void Start() {
            switch(stage) {
                case Stages.Traditional:
                    AddTint(new Color(135, 211, 255));
                    break;
                case Stages.Simple:
                    AddTint(new Color(207, 255, 215));
                    break;
                case Stages.Intermediate:
                    AddTint(new Color(252, 255, 189));
                    break;
                case Stages.Complex:
                    AddTint(new Color(255, 148, 143));
                    break;
                default:
                    RemoveTint();
                    break;
            }
        }

        // ===== Methods =====

        public void AddTint(Color tint) {
            for (int i = 0; i < envMaterials.Length; i++)
                envMaterials[i].SetColor("_BaseColor", tint);
        }

        public void RemoveTint() => AddTint(Color.white);
    }
}
