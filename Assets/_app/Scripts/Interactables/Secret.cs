using UnityEngine;
using UnityEngine.SceneManagement;

// Gotta find this one, I don't know what to tell ya
namespace _app.Scripts.Interactables
{
    public class Secret : Interactable
    {
        protected override void Interact()
        {
            SceneManager.LoadScene(sceneName: "DialogueTesting");
        }
    }
}
