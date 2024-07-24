using _app.Scripts.Operators;
using UnityEngine;

namespace _app.Scripts.Managers
{
    public class OperatorManager : MonoBehaviour
    {
        // Old Storage
        //private CustomOperator op;

        [Header("Operator Data Storage")] 
        public OperatorData data;
    
        // OperatorManager is a singleton, it stores and utilizes the stored equations when they are needed
        // so we don't want multiple
        private static OperatorManager _instance;
        public static OperatorManager Instance
        {
            get
            {
                return _instance;
            }
        }
        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                // this destroys the current instance if another one exists
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void GenerateSimpleOperator()
        {
            if (!!data && (data.opsCount < 5))
            {
                data.operatorArray[data.opsCount] = new SimpleOperator();
                data.opsCount++;
            }
        }

        // This version of Calculate will default to using the most recently added Operator
        public double Calculate(double x, double y)
        {
            if (!!data && (data.opsCount > 0))
            {
                return data.operatorArray[data.opsCount - 1].RunCalculation(x, y);
            }
            // In case of problems, return 0
            return 0;
        }

        // Defaults to most recent op
        public string GetName()
        {
            if (!!data)
            {
                return data.operatorArray[data.opsCount - 1].name;
            }
            return " ";
        }

        // Specifies op
        public string GetName(int opNum)
        {
            if (!!data && (0 < opNum) && (6 > opNum))
            {
                return data.operatorArray[opNum - 1].name;
            }
            return " ";
        }
    
        // Defaults to most recent op
        public string GetSymbol()
        {
            if (!!data)
            {
                return data.operatorArray[data.opsCount - 1].symbol;
            }
            return " ";
        }
    
        // Specifies op
        public string GetSymbol(int opNum)
        {
            if (!!data && (0 < opNum) && (6 > opNum))
            {
                return data.operatorArray[opNum - 1].symbol;
            }
            return " ";
        }

        public void InitializeArr()
        {
            data.operatorArray = new CustomOperator[5];
            data.opsCount = 0;
        }
    }
}
