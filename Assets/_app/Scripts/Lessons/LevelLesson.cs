using _app.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace _app.Scripts.Lessons
{
    public class LevelLesson : MonoBehaviour
    {
        private string lesson;
        [SerializeField]private TextMeshPro whiteboardText;
    
        void Start()
        {
            OperatorManager.Instance.GenerateOperator();
            generateLesson();
        }
        
        public void generateLesson()
        {
            double num1, num2, solution;
            string symbol = OperatorManager.Instance.GetSymbol();
            string symbolText = " " + symbol + " ";
            lesson = "";
            lesson += "Let's learn about " + OperatorManager.Instance.GetName() + "!";
            
            for (int i = 0; i < 3; i++)
            {
                num1 = Random.Range(0, 13);
                num2 = Random.Range(0, 13);
                solution = OperatorManager.Instance.Calculate(num1, num2);
                lesson += ("\n" + num1 + symbolText + num2 + " = " + solution);
                whiteboardText.text = lesson;
            }
        }
    }
}
