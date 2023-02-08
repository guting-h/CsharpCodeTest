using System;

namespace CodeTestLocal
{
    class Mortgage
    {
        public static double monthlyPay(double L, double n, double c)
        {
            double res = power(1 + c, n);
            return L * (c * res) / (res - 1);
        }

        static double power(double x, double n)
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
