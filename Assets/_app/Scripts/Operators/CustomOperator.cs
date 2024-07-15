using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _app.Scripts.Operators
{
    public class CustomOperator
    {
        public ICalculable equation;
        public string name { get; set; }
        // public Material symbol { get; set; }
        public string symbol { get; set; }
        private string[] opSymbolArray = { "&@#", "<^>", ":^)" };
        protected Literal x;
        protected Literal y;
        private string[] opNamesArray = {"Glorbo", "ExSine", "John"};
        // private int symbolCount = 3;

        public CustomOperator()
        {
            int selectName = Random.Range(0, opNamesArray.Length);
            name = opNamesArray[selectName];

            // Material needs accessed randomly and assigned to symbol
            // string materialPath = "Materials/Operators/Symbol_" + Random.Range(0, symbolCount) + ".mat";
            // symbol = Resources.Load(materialPath, typeof(Material)) as Material;
            int selectSymbol = Random.Range(0, opSymbolArray.Length);
            symbol = opSymbolArray[selectSymbol];
            
            x = new Literal();
            y = new Literal();
        }
        
        public double RunCalculation(double _x, double _y)
        {
            x.number = _x;
            y.number = _y;
            return Math.Round(equation.Calculate(), 2, MidpointRounding.AwayFromZero);
        }
    }
}