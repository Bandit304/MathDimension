using System;

namespace _app.Scripts.Operators
{
    public class Divide : ICalculable
    {
        public ICalculable x;
        public ICalculable y;

        public Divide(ICalculable _x, ICalculable _y)
        {
            x = _x;
            y = _y;
        }

        public double Calculate()
        {
            return x.Calculate() / y.Calculate();
        }
    }
}