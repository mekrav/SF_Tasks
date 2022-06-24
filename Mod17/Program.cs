using System;

namespace Mod17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var commonAccount = new CommonAccount();
            commonAccount.Balance = 100000;
            commonAccount.CalculateInterest();
            Console.WriteLine($"Обычный счёт: {commonAccount.Balance}, {commonAccount.Interest}");

            var salaryAccount = new SalaryAccount();
            salaryAccount.Balance = 100000;
            salaryAccount.CalculateInterest();
            Console.WriteLine($"Зарплатный счёт: {salaryAccount.Balance}, {salaryAccount.Interest}");


        }
    }
}
