namespace _app.Scripts.Operators.Calculables
{
    public class Add : BasicCalculable
    {
        public Add() : base() {}
        public Add(ICalculable _x, ICalculable _y) : base(_x, _y) {}

        public override double Calculate()
        {
            return x.Calculate() + y.Calculate();
        }
    }
}
