using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _app.Scripts.Managers
{
    public class TitleScreen : MonoBehaviour
    {
        public void StartGame()
        {
            // Play Audio
            AudioManager.Instance.PlayRandomAudioFromKey("Audio_MsInfo_Math");
            StartCoroutine(delayStart());
        }

        public void QuitGame()
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }

        IEnumerator delayStart()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(sceneName: "Level1");
        }

        public void ReturnToTitle()
        {
            SceneManager.LoadScene(sceneName: "TitleScreen");
        }
    }
}
