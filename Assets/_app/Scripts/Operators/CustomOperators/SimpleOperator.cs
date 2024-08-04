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
    }
}