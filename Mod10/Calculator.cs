using System;
using System.Collections.Generic;
using System.Text;

namespace Mod10
{
    internal class Calculator : ICalculator
    {
        ILogger Logger {get;}
        public Calculator(ILogger logger)
        {
            Logger = logger;
        }

        public double CalculateSum(double x, double y)
        {
            Logger.Event("Выполняется сложение");
            return x + y;
        }
    }
}
