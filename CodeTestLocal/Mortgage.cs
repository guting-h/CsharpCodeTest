using System;

namespace CodeTestLocal
{
    public class Mortgage
    {

        public static double monthlyPay(double loan, double years, double interest)
        {
            if (loan < 0 || years < 0 || interest < 0)
            {
                throw new ArgumentOutOfRangeException("Inputs cannot be negative");
            }
            // convert to months
            double n = years * 12;

            // monthly interest rate
            double c = (interest / 100) / 12;

            double exponential = power(1 + c, n);
            double res = loan * (c * exponential) / (exponential - 1);
            return Math.Round(res, 2); 
        }

        public static double power(double x, double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n % 2 == 0)
            {
                return power(x * x, n / 2);
            }
            else
            {
                return x * power(x * x, (n - 1) / 2);
            }
        }
    }
}
