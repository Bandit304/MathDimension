using UnityEngine;

namespace _app.Scripts.Managers {
    public class EnvironmentTintManager : MonoBehaviour {
        // ===== Fields =====

        public enum Stages { None, Traditional, Simple, Intermediate, Complex }

        [Header("Singleton Reference")]
        public static EnvironmentTintManager Instance { get; private set; }

        [Header("Environment Materials")]
        public Renderer EnvRenderer;
        private Material[] envMaterials;

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
            if (!!EnvRenderer)
                envMaterials = EnvRenderer.materials;
            
            switch(stage) {
                case Stages.Traditional:
                    AddTint(new Color(135f / 255f, 211f / 255f, 255f / 255f));
                    break;
                case Stages.Simple:
                    AddTint(new Color(207f / 255f, 255f / 255f, 215f / 255f));
                    break;
                case Stages.Intermediate:
                    AddTint(new Color(252f / 255f, 255f / 255f, 189f / 255f));
                    break;
                case Stages.Complex:
                    AddTint(new Color(255f / 255f, 148f / 255f, 143f / 255f));
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
