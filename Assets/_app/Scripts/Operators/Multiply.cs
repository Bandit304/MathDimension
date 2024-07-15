using System;

namespace _app.Scripts.Operators
{
    public class Multiply : ICalculable
    {
        public ICalculable x;
        public ICalculable y;

        public Multiply(ICalculable _x, ICalculable _y)
        {
            x = _x;
            y = _y;
        }

        public double Calculate()
        {
            return x.Calculate() * y.Calculate();
        }
    }
}