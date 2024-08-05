using _app.Scripts.Managers;
using _app.Scripts.Operators;
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
            // If OperatorReset component present in scene, reset operator data
            if (!!OperatorReset.Instance)
                OperatorReset.Instance.ResetOperator();
            
            // Generate new operator
            OperatorManager.Instance.GenerateOperator();

            // Generate whiteboard lesson
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
                // checks if the operator is basic division to prevent /0
                if (symbol == "/")
                {
                    num2 = Random.Range(1, 13);
                }
                else
                {
                    num2 = Random.Range(0, 13);
                }
                solution = OperatorManager.Instance.Calculate(num1, num2);
                lesson += ("\n" + num1 + symbolText + num2 + " = " + solution);
                whiteboardText.text = lesson;
            }
        }
    }
}
