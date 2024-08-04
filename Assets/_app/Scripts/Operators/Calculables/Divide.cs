using System;

namespace _app.Scripts.Operators.Calculables
{
    public class Divide : BasicCalculable
    {
        public Divide() : base() {}
        public Divide(ICalculable _x, ICalculable _y) : base(_x, _y) {}

        public override double Calculate()
        {
            return x.Calculate() / y.Calculate();
        }
    }
}