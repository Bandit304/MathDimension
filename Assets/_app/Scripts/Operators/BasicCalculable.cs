using UnityEngine;

namespace _app.Scripts.Operators {
    public class BasicCalculable : ICalculable {
        // ===== Fields =====

        public ICalculable x;
        public ICalculable y;

        // ===== Constructors =====

        public BasicCalculable() {
            x = null;
            y = null;
        }

        public BasicCalculable(ICalculable _x, ICalculable _y) {
            x = _x;
            y = _y;
        }
        
        // ===== Methods =====

        // Override in subclasses
        public virtual double Calculate() => -1;
    }
}
