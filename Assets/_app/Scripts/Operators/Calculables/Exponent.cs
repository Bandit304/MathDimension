using System;
using UnityEngine;

namespace _app.Scripts.Operators.Calculables {
    public class Exponent : BasicCalculable {
        // ===== Constructors =====

        public Exponent() : base() {}
        public Exponent(ICalculable _x, ICalculable _y) : base(_x, _y) {}

        // ===== Methods =====
        public override double Calculate() => Math.Pow(x.Calculate(), y.Calculate());
    }
}
