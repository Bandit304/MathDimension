namespace _app.Scripts.Operators
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