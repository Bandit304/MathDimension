using System;

namespace _app.Scripts.Operators
{
    public class Multiply : BasicCalculable
    {
        public Multiply() : base() {}
        public Multiply(ICalculable _x, ICalculable _y) : base(_x, _y) {}

        public override double Calculate()
        {
            return x.Calculate() * y.Calculate();
        }
    }
}