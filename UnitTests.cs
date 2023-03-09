using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SE_1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void shouldReturnTrueBecauseEmptyString()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void shouldReturnASingleNumber()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void shouldSumTwoNumbersDelimitedByComa()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("2,5");
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void shouldSumTwoNumbersDelimitedByNewline()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("8\n8");
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Numbers can't be negative")]
        public void shouldThrowExceptionBecauseNumberIsNegative()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("-8");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Numbers can't be negative")]
        public void shouldThrowExceptionBecauseOneNumberIsNegative()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("-8,8");
        }

        [TestMethod]
        public void shouldIgnoreThousand()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1001");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void shouldIgnoreThousandInASum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1,1001");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void shouldUseHashtagAsDelimiter()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//#1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void shouldUseHashtagAsDelimiterAndSum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//#1#5");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void shouldUseArrowUpAsDelimiterAndSum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//^1^5");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void shouldUseStarAsDelimiter()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//*1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void shouldUseHashtagStringAsDelimiter()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//[###]1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void shouldUseHashtagStringAsDelimiterAndSum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//[###]1###609");
            Assert.AreEqual(610, result);
        }

        [TestMethod]
        public void shouldUseCharacterStringAsDelimiterAndSum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//[(){]1(){89");
            Assert.AreEqual(90, result);
        }
    }
}
