using System;
using Random = UnityEngine.Random;
using _app.Scripts.Operators.Calculables;

namespace _app.Scripts.Operators.CustomOperators
{
    public class ComplexOperator : CustomOperator
    {
        private int maxLiteralValue = 5;

        public ComplexOperator() : base()
        {
            ICalculable _x = x;
            ICalculable _y = y;

            // Square one or both sides of the equation
            int randInt = Random.Range(0, 3);
            switch(randInt) {
                case 0:
                    _x = new Exponent(_x, new Literal(2));
                    break;
                case 1:
                    _y = new Exponent(_y, new Literal(2));
                    break;
                default:
                    _x = new Exponent(_x, new Literal(2));
                    _y = new Exponent(_y, new Literal(2));
                    break;
            }

            // Add OR Subtract both sides of the equation
            ICalculable subEquation = GetRandomCalculation<Add, Subtract>(_x, _y);

            // If only one side of the equation was squared, Multiply OR Divide with small Literal
            if (randInt != 2)
                subEquation = GetRandomCalculation<Multiply, Divide>(
                    subEquation,
                    new Literal(Random.Range(2, maxLiteralValue + 1))
                );
            
            // Set equation equal to subEquation
            equation = subEquation;
        }
    }
}