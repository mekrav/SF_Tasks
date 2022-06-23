using System;
using System.Collections.Generic;
using System.Text;

namespace Mod17
{
    internal class SalaryAccount : IAccount
    {
        // тип учетной записи теперь определяется используемым классом

        // баланс учетной записи
        public double Balance { get; set; }

        // процентная ставка
        public double Interest { get; private set; }

        public void CalculateInterest()
        {
            // расчет процентной ставк зарплатного аккаунта по правилам банка
            Interest = Balance * 0.5;
        }
    }
}
