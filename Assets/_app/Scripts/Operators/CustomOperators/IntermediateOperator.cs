using System;
using Random = UnityEngine.Random;
using _app.Scripts.Operators.Calculables;

namespace _app.Scripts.Operators.CustomOperators
{
    public class IntermediateOperator : CustomOperator
    {
        private int maxTypes = 3;

        public IntermediateOperator() : base()
        {

            int selectOp = Random.Range(0, maxTypes);

            // Select Operation function
            switch (selectOp)
            {
                // Doubles both numbers and adds them together
                case 0:
                    equation = new Add(new Multiply(x, new Literal(2)), new Multiply(y, new Literal(2)));
                    break;
                // Doubles both numbers and subtracts the second from the first
                case 1:
                    equation = new Subtract(new Multiply(x, new Literal(2)), new Multiply(y, new Literal(2)));
                    break;
                // Adds both numbers and divides result by a random number between 2 and 6
                case 2:
                    equation = new Divide(new Add(x, y), new Literal(Random.Range(2, 7)));
                    break;
                // Defaults to the first custom in case of invalid value
                default:
                    equation = new Add(new Multiply(x, new Literal(2)), new Multiply(y, new Literal(2)));
                    break;
            }
        }
    }
}