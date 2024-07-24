using UnityEngine;

namespace _app.Scripts.Operators
{
    [CreateAssetMenu(fileName = "OperatorData", menuName = "Scriptable Objects/OperatorData")]
    public class OperatorData : ScriptableObject
    {
        public CustomOperator[] operatorArray;
        public int opsCount;
    }
}
