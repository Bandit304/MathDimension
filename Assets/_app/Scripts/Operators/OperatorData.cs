using UnityEngine;
using _app.Scripts.Operators.CustomOperators;
using System.Collections.Generic;

namespace _app.Scripts.Operators
{
    [CreateAssetMenu(fileName = "OperatorData", menuName = "Scriptable Objects/OperatorData")]
    public class OperatorData : ScriptableObject
    {
        public List<CustomOperator> operatorArray;
        public int opsCount;
        public List<string> usedNames;
        public List<string> usedSymbols;
    }
}
