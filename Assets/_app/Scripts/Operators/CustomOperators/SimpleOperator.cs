using System;
using Random = UnityEngine.Random;
using _app.Scripts.Operators.Calculables;

namespace _app.Scripts.Operators.CustomOperators
{
    public class SimpleOperator : CustomOperator
    {

        public SimpleOperator() : base()
        {
            ICalculable _x = x;
            ICalculable _y = y;

            // One operand has chance to multiply/divide by 2
            if (Random.Range(0, 2) == 0)
                _x = GetRandomCalculation<Multiply, Divide>(_x, new Literal(2));
            else
                _y = GetRandomCalculation<Multiply, Divide>(_y, new Literal(2));
            
            // 50% chance to add or subtract
            equation = GetRandomCalculation<Add, Subtract>(_x, _y);
        }

        private ICalculable GetRandomCalculation<TCalc1, TCalc2>(ICalculable _x, ICalculable _y)
            where TCalc1 : BasicCalculable, new()
            where TCalc2 : BasicCalculable, new()
        {
            // BasicCalculable guarantees x & y fields exist
            BasicCalculable output;

            // 50% Chance of each type
            if (Random.Range(0, 2) == 0)
                output = new TCalc1();
            else
                output = new TCalc2();
            
            // Set x & y fields
            output.x = _x;
            output.y = _y;

            return output;
        }
    }
}