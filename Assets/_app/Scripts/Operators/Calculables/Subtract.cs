namespace _app.Scripts.Operators.Calculables
{
    public class Subtract : BasicCalculable
    {
        public Subtract() : base() {}
        public Subtract(ICalculable _x, ICalculable _y) : base(_x, _y) {}

        public override double Calculate()
        {
            return x.Calculate() - y.Calculate();
        }
    }
}