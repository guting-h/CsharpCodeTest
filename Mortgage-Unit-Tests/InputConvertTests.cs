using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CodeTestLocal;

namespace Mortgage_Unit_Tests
{
    [TestClass]
    public class InputConvertTests
    {
        [TestMethod]
        public void Convert_Normal_Inputs()
        {
            string input = @"Claes Månsson,1300.55,8.67,2";

            string[] converted = InputConverter.ConvertInput(input);

            Assert.AreEqual(converted.Length, 4);
            Assert.AreEqual(converted[0], "Claes Månsson");
        }


        [TestMethod]
        public void Convert_Input_With_Quotes()
        {
            string input = @"""Clarencé,Andersson"",2000,6,4";

            string [] converted = InputConverter.ConvertInput(input);

            Assert.AreEqual(converted.Length, 4);
        }


        [TestMethod]
        public void Convert_Empty_Lines()
        {
            string input = @"";

            string[] converted = InputConverter.ConvertInput(input);

            Assert.AreEqual(converted.Length, 1);
        }
    }
}
