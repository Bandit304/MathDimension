using System;
using UnityEngine;
using Random = UnityEngine.Random;
using _app.Scripts.Operators.Calculables;

namespace _app.Scripts.Operators.CustomOperators
{
    public class CustomOperator
    {
        public ICalculable equation;
        public string name { get; set; }
        // public Material symbol { get; set; }
        public string symbol { get; set; }
        private string[] opSymbolArray =
        {
            "&@#", "<^>", ":^)", "&*&", "UIU", "(^)", "\\|/", "-+-", "$$$",
            ".'.", "!#!", ":.:", "OVO", ">^<", ")w(", "{*}", "{>}", "{<}",
            "','", "#!#", "#@#", "%*%", "-%-", ">-<", "\\./", "(*)", "/T\\"
        };
        protected Literal x;
        protected Literal y;
        private string[] opNamesArray =
        {
            "Glorbo", "ExSine", "John", "Leppa", "Skrep", "Blorange", "Tlabber", "RKS",
            "Maxim", "Brick", "Leital", "Cromp", "Blorgo", "Prum", "Zlide", "Ribble",
            "Ulpy", "Freb", "Querp", "Yulb", "Morp", "Belch", "Juandice"
        };
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

        public void SelectNewName()
        {
            int selectName = Random.Range(0, opNamesArray.Length);
            name = opNamesArray[selectName];
        }

        public void SelectNewSymbol()
        {
            int selectSymbol = Random.Range(0, opSymbolArray.Length);
            symbol = opSymbolArray[selectSymbol];
        }

        // ===== Calculation Generation Methods =====
        
        protected ICalculable GetRandomCalculation<TCalc1, TCalc2>(ICalculable _x, ICalculable _y)
            where TCalc1 : BasicCalculable, new()
            where TCalc2 : BasicCalculable, new()
        {
            // BasicCalculable guarantees x & y fields exist
            BasicCalculable output;

            // 50% Chance of each type
            if (Random.Range(0, 2) == 0)
                output = new TCalc1();
            else
                output = new TCalc2();
            
            // Set x & y fields
            output.x = _x;
            output.y = _y;

            return output;
        }

        protected ICalculable GetRandomCalculation<TCalc1, TCalc2, TCalc3>(ICalculable _x, ICalculable _y)
            where TCalc1 : BasicCalculable, new()
            where TCalc2 : BasicCalculable, new()
            where TCalc3 : BasicCalculable, new()
        {
            // BasicCalculable guarantees x & y fields exist
            BasicCalculable output;

            // 1/3 Chance of each type
            int randInt = Random.Range(0, 3);
            switch(randInt) {
                case 0:
                    output = new TCalc1();
                    break;
                case 1:
                    output = new TCalc2();
                    break;
                default:
                    output = new TCalc3();
                    break;
            }
            
            // Set x & y fields
            output.x = _x;
            output.y = _y;

            return output;
        }
    }
}