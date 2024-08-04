using System;
using System.Numerics;
using _app.Scripts.Operators;
using _app.Scripts.Operators.CustomOperators;
using UnityEngine;

namespace _app.Scripts.Managers
{
    public class OperatorManager : MonoBehaviour
    {
        // Old Storage
        //private CustomOperator op;

        [Header("Operator Data Storage")] 
        public OperatorData data;

        [Header("Level Info")] 
        public int currentLevel;
        
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

        public void GenerateOperator()
        {
            if (!!data && (data.opsCount < 5))
            {
                switch (currentLevel)
                {
                    // Will generate an operator of varying difficulty based on the level
                    case 1:
                        data.operatorArray[data.opsCount] = new SimpleOperator();
                        break;
                    case 2:
                        data.operatorArray[data.opsCount] = new SimpleOperator();
                        break;
                    case 3:
                        data.operatorArray[data.opsCount] = new IntermediateOperator();
                        break;
                    case 4:
                        data.operatorArray[data.opsCount] = new IntermediateOperator();
                        break;
                    case 5:
                        data.operatorArray[data.opsCount] = new ComplexOperator();
                        break;
                    default:
                        data.operatorArray[data.opsCount] = new SimpleOperator();
                        break;
                }
                
                // In case the randomly selected name is taken already, a new one will be generated until
                // a new one is found
                while (Array.IndexOf(data.usedNames, data.operatorArray[data.opsCount].name) > -1)
                {
                    data.operatorArray[data.opsCount].SelectNewName();
                }
                // The same is done for the symbol
                while (Array.IndexOf(data.usedSymbols, data.operatorArray[data.opsCount].symbol) > -1)
                {
                    data.operatorArray[data.opsCount].SelectNewSymbol();
                }
                
                // Add Symbol and Name to respective arrays and increment counters
                data.usedNames[data.opsCount] = data.operatorArray[data.opsCount].name;
                data.usedSymbols[data.opsCount] = data.operatorArray[data.opsCount].symbol;
                data.nameCount++;
                data.symbolCount++;
                
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
        
        // Specifies op
        public double Calculate(double x, double y, int opNum)
        {
            if (!!data && (data.opsCount > 0) && (opNum <= data.opsCount))
            {
                return data.operatorArray[opNum - 1].RunCalculation(x, y);
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
            data.usedNames = new string[5];
            data.nameCount = 0;
            data.usedSymbols = new string[5];
            data.symbolCount = 0;
        }
        
        // Returns Current Level for use of picking operators
        public int GetLevel()
        {
            return currentLevel;
        }
    }
}
