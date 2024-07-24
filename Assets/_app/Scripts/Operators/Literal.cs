namespace _app.Scripts.Operators
{
    public class Literal : ICalculable
    {
        public double number;

        public Literal(double num)
        {
            number = num;
        }
    
        public Literal()
        {
            number = 1;
        }

        public double Calculate()
        {
            return number;
        }
    }
}
