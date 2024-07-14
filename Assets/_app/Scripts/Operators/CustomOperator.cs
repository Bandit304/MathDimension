using UnityEngine;

namespace _app.Scripts.Operators
{
    public class CustomOperator
    {
        public ICalculable equation;
        protected string name;
        protected Material symbol { get; set; }
        protected Literal x;
        protected Literal y;
        private string[] opNamesArray = {"Glorbo", "ExSine", "John"};

        public CustomOperator()
        {
            int selectName = Random.Range(0, opNamesArray.Length);
            name = opNamesArray[selectName];

            // Material needs accessed randomly and assigned to symbol
            
            x = new Literal();
            y = new Literal();
        }
        
        public double RunCalculation(double _x, double _y)
        {
            x.number = _x;
            y.number = _y;
            return equation.Calculate();
        }
    }
}