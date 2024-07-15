using Random = UnityEngine.Random;

namespace _app.Scripts.Operators
{
    public class SimpleOperator : CustomOperator
    {
        private int maxTypes = 2;

        public SimpleOperator() : base()
        {

            int selectOp = Random.Range(0, maxTypes);

            // Select Operation function
            switch (selectOp)
            {
                // Doubles the first number and adds the second
                case 0:
                    equation = new Add(new Multiply(x, new Literal(2)), y);
                    break;
                // Doubles the first number and subtracts the second
                case 1:
                    equation = new Subtract(new Multiply(x, new Literal(2)), y);
                    break;
                // Defaults to the first custom in case of invalid value
                default:
                    equation = new Add(new Multiply(x, new Literal(2)), y);
                    break;
            }
        }
    }
}