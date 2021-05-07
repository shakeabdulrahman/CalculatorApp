using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public static class SimpleCalculator
    {
        public static double OnCalculate(double value1, double value2, string mathoperator)
        {
            double result = 0;

            switch(mathoperator)
            {
                case "+":
                    result = value1 + value2;
                    break;

                case "-":
                    result = value1 - value2;
                    break;

                case "÷":
                    result = value1 / value2;
                    break;

                case "×":
                    result = value1 * value2;
                    break;
            }
            return result;
        }
    }
}
