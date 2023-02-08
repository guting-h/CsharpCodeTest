using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CodeTestLocal;

namespace Mortgage_Unit_Tests
{
    [TestClass]
    public class MortgageTests
    {
        [TestMethod]
        public void Test_Power_Method()
        {
            Random rnd = new Random();

            for (int i = 0;i < 100; i++) 
            {
                double b = rnd.NextDouble();
                double n = rnd.NextDouble();

                double res = Mortgage.power(b, b);

                Assert.AreEqual(Math.Pow(b, n), res);
            }

            for (int i = 0; i < 100; i++)
            {
                double b = rnd.Next();
                double n = rnd.Next();

                double res = Mortgage.power(b, b);

                Assert.AreEqual(Math.Pow(b, n), res);
            }

        }

        [TestMethod]
        public void Monthly_Payment_Good_Inputs() 
        {
            double[] loansFromFile = { 1000, 4356, 1300.55, 2000 };
            double[] yearsFromFile = { 2, 6, 2, 4 };
            double[] interestFromFile = { 5, 1.27, 8.67, 6 };

            double[] monthlyPayments = { 43.87, 62.87, 59.22, 46.97 };

            for (int i = 0; i < loansFromFile.Length; i++) 
            {
                double res = Mortgage.monthlyPay(loansFromFile[i], yearsFromFile[i], interestFromFile[i]);
                Assert.AreEqual(monthlyPayments[i], res);
            }
        }

        [TestMethod]
        public void Monthly_Payment_Negative_Inputs()
        {
            double[] res = {-1, 2, 3,
                            22.7, -2, 3,
                            1, 2, -3,
                            -1, 2, -3,
                            -0.1, -5, 3, 
                            50, -1, -3};

            for (int i = 0; i < 6; i++)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => Mortgage.monthlyPay(res[i * 3], res[i * 3 + 1], res[i * 3 + 2])
                );
            };
        }
    }
}
