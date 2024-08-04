using System;
using Random = UnityEngine.Random;
using _app.Scripts.Operators.Calculables;

namespace _app.Scripts.Operators.CustomOperators
{
    public class ComplexOperator : CustomOperator
    {
        private int maxTypes = 1;

        public ComplexOperator() : base()
        {

            int selectOp = Random.Range(0, maxTypes);

            // Select Operation function
            switch (selectOp)
            {
                // Squares both numbers and adds them together
                case 0:
                    equation = new Add(new Multiply(x, x), new Multiply(y, y));
                    break;
                // Squares both numbers and subtracts the second from the first
                case 1:
                    equation = new Subtract(new Multiply(x, x), new Multiply(y, y));
                    break;
                // Adds both numbers (first squared) and divides result by a random number between 2 and 6
                case 2:
                    equation = new Divide(new Add(new Multiply(x, x), y), new Literal(Random.Range(2, 7)));
                    break;
                // Adds both numbers (first squared) and divides result by a random number between 2 and 6
                case 3:
                    equation = new Divide(new Add(new Multiply(y, y), x), new Literal(Random.Range(2, 7)));
                    break;
                // Defaults to the first custom in case of invalid value
                default:
                    equation = new Add(new Multiply(x, x), new Multiply(y, y));
                    break;
            }
        }
    }
}