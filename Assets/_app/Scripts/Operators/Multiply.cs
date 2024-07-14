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
            return Math.Round((x.Calculate() * y.Calculate()), 2, MidpointRounding.AwayFromZero);
        }
    }
}