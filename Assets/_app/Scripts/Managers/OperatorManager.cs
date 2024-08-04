using System;
using System.Collections.Generic;
using System.Numerics;
using _app.Scripts.Operators;
using _app.Scripts.Operators.Calculables;
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
        public CustomOperator currentOperator { get; private set; }
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
            if (!!data)
            {
                if (currentLevel == 1)
                    currentOperator = new TraditionalOperator<Add>();
                else if (currentLevel == 2)
                    currentOperator = new TraditionalOperator<Subtract>();
                else if (currentLevel == 3)
                    currentOperator = new TraditionalOperator<Multiply>();
                else if (currentLevel == 4)
                    currentOperator = new TraditionalOperator<Divide>();
                else if (currentLevel >= 5 && currentLevel <= 6)
                    currentOperator = new SimpleOperator();
                else if (currentLevel >= 7 && currentLevel <= 8)
                    currentOperator = new IntermediateOperator();
                else if (currentLevel == 9)
                    currentOperator = new ComplexOperator();

                data.operatorArray.Add(currentOperator);
                
                // In case the randomly selected name is taken already, a new one will be generated until
                // a new one is found
                while (data.usedNames.IndexOf(currentOperator.name) > -1)
                {
                    currentOperator.SelectNewName();
                }
                // The same is done for the symbol
                while (data.usedSymbols.IndexOf(currentOperator.symbol) > -1)
                {
                    currentOperator.SelectNewSymbol();
                }
                
                // Add Symbol and Name to respective arrays and increment counters
                data.usedNames.Add(currentOperator.name);
                data.usedSymbols.Add(currentOperator.symbol);
                
                data.opsCount++;
            }
        }
        
        // In case level needs to be restarted, generate a new operator
        public void NewOperator()
        {
            if (!!data)
            {
                data.opsCount--;
                data.operatorArray.Remove(data.operatorArray[data.opsCount]);
                data.usedNames[data.opsCount] = "";
                data.usedSymbols[data.opsCount] = "";
                
                GenerateOperator();
            }
        }

        // This version of Calculate will default to using the most recently added Operator
        public double Calculate(double x, double y)
        {
            if (currentOperator != null)
            {
                return currentOperator.RunCalculation(x, y);
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
            if (currentOperator != null)
            {
                return currentOperator.name;
            }
            return " ";
        }

        // Specifies op
        public string GetName(int opNum)
        {
            if (!!data && (0 < opNum))
            {
                return data.operatorArray[opNum - 1].name;
            }
            return " ";
        }
    
        // Defaults to most recent op
        public string GetSymbol()
        {
            if (currentOperator != null)
            {
                return currentOperator.symbol;
            }
            return " ";
        }
    
        // Specifies op
        public string GetSymbol(int opNum)
        {
            if (!!data && (0 < opNum))
            {
                return data.operatorArray[opNum - 1].symbol;
            }
            return " ";
        }

        public void InitializeArr()
        {
            data.operatorArray = new List<CustomOperator>();
            data.opsCount = 0;
            data.usedNames = new List<string>();
            data.usedSymbols = new List<string>();
        }
        
        // Returns Current Level for use of picking operators
        public int GetLevel()
        {
            return currentLevel;
        }
    }
}
