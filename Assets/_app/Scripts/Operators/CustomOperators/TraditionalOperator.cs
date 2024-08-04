using System;
using _app.Scripts.Operators.Calculables;
using UnityEngine;

namespace _app.Scripts.Operators.CustomOperators {
    // Custom Operator class to handle basic operations (Addition, Subtraction, etc.)
    public class TraditionalOperator<TCalc> : CustomOperator where TCalc : BasicCalculable, new() {
        // ===== Constructors =====
        
        public TraditionalOperator() {
            // Define x & y
            x = new Literal();
            y = new Literal();
            
            // Generate equation
            BasicCalculable _equation = new TCalc {
                x = x,
                y = y,
            };
            equation = _equation;

            // Get operation name & symbol
            switch(typeof(TCalc).ToString()) {
                case "_app.Scripts.Operators.Calculables.Add":
                    name = "Addition";
                    symbol = "+";
                    break;
                case "_app.Scripts.Operators.Calculables.Subtract":
                    name = "Subtraction";
                    symbol = "-";
                    break;
                case "_app.Scripts.Operators.Calculables.Multiply":
                    name = "Multiplication";
                    symbol = "*";
                    break;
                case "_app.Scripts.Operators.Calculables.Divide":
                    name = "Division";
                    symbol = "/";
                    break;
                case "_app.Scripts.Operators.Calculables.Exponent":
                    name = "Exponents";
                    symbol = "^";
                    break;
                default:
                    name = typeof(TCalc).ToString();
                    symbol = "?";
                    break;
            }
        }
    }
}
