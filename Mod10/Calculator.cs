using System;
using System.Collections.Generic;
using System.Text;

namespace Mod10
{
    internal class Calculator : ICalculator
    {
        public double CalculateSum(double x, double y)
        {
            return x + y;
        }
    }
}
