using TMPro;
using UnityEngine;

namespace _app.Scripts
{
    public class WhiteboardLesson : MonoBehaviour
    {
        private string lesson;
        [SerializeField]private TextMeshPro whiteboardText;
    
        void Start()
        {
            generateLesson();
        }
    
        // Unsure if this method will be retooled for future levels or if this will just be for 
        private void generateLesson()
        {
            int num1, num2, solution;
            lesson = "";
        
            // Set title line
            lesson += "Let's learn about Addition!";

            for (int i = 0; i < 3; i++)
            {
                num1 = Random.Range(0, 13);
                num2 = Random.Range(0, 13);
                solution = num1 + num2;
                lesson += ("\n" + num1 + " + " + num2 + " = " + solution);
                whiteboardText.text = lesson;
            }
        }
    }
}
