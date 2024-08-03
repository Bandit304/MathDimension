using Random = UnityEngine.Random;

namespace _app.Scripts.Operators
{
    public class SimpleOperator : CustomOperator
    {
        private int maxTypes = 8;

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
                // Doubles the second number and adds the first
                case 2:
                    equation = new Add(new Multiply(y, new Literal(2)), x);
                    break;
                // Doubles the second number and subtracts it from the first
                case 3:
                    equation = new Subtract(x, new Multiply(y, new Literal(2)));
                    break;
                // Halves the first number and add the second
                case 4:
                    equation = new Add(new Divide(x, new Literal(2)), y);
                    break;
                // Halves the second number and add the first
                case 5:
                    equation = new Add(new Divide(y, new Literal(2)), x);
                    break;
                // Halves the first number and subtracts the second
                case 6:
                    equation = new Subtract(new Divide(x, new Literal(2)), y);
                    break;
                // Halves the second number and subtracts from the first
                case 7:
                    equation = new Subtract(x, new Divide(y, new Literal(2)));
                    break;
                // Defaults to the first custom in case of invalid value
                default:
                    equation = new Add(new Multiply(x, new Literal(2)), y);
                    break;
            }
        }
    }
}