using System;
using Random = UnityEngine.Random;
using _app.Scripts.Operators.Calculables;

namespace _app.Scripts.Operators.CustomOperators
{
    public class IntermediateOperator : CustomOperator
    {
        private int maxLiteralValue = 5;

        public IntermediateOperator() : base()
        {
            ICalculable _x = x;
            ICalculable _y = y;

            // 25% to multiply both numbers on the left side of the equation
            // 25% to multiply both numbers on the right side of the equation
            // 50% chance to do nothing
            int randInt = Random.Range(0, 4);
            switch (randInt) {
                case 0:
                    _x = new Multiply(_x, _y);
                    break;
                case 1:
                    _y = new Multiply(_x, _y);
                    break;
            }

            // Multiply, Add OR Subtract a small literal on both sides of the equation
            _x = GetRandomCalculation<Multiply, Add, Subtract>(
                _x,
                new Literal(Random.Range(2, maxLiteralValue + 1))
            );
            _y = GetRandomCalculation<Multiply, Add, Subtract>(
                _y,
                new Literal(Random.Range(2, maxLiteralValue + 1))
            );

            // Add OR Subtract both sides of the equation
            equation = GetRandomCalculation<Add, Subtract>(_x, _y);
        }
    }
}