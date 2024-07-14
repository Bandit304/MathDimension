namespace _app.Scripts.Operators
{
    public class Subtract : ICalculable
    {
        public ICalculable x;
        public ICalculable y;

        public Subtract(ICalculable _x, ICalculable _y)
        {
            x = _x;
            y = _y;
        }

        public double Calculate()
        {
            return x.Calculate() - y.Calculate();
        }
    }
}