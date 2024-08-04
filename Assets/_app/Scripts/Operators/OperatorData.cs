using UnityEngine;
using _app.Scripts.Operators.CustomOperators;

namespace _app.Scripts.Operators
{
    [CreateAssetMenu(fileName = "OperatorData", menuName = "Scriptable Objects/OperatorData")]
    public class OperatorData : ScriptableObject
    {
        public CustomOperator[] operatorArray;
        public int opsCount;
        public string[] usedNames;
        public int nameCount;
        public string[] usedSymbols;
        public int symbolCount;
    }
}
