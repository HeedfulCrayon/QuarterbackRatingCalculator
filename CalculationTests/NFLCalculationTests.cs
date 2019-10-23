using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuarterbackRating.Model;

namespace CalculationTests
{
    [TestClass]
    public class NFLCalculationTests
    {
        private static NFLCalculationService calculator;
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            calculator = new NFLCalculationService();
        }

        [TestMethod]
        public void PerfectScore()
        {
            var passAttempts = 1M;
            var passCompletions = .775M;
            var yards = 12.5M;
            var touchdowns = .11875M;
            var interceptions = 0M;
            var result = calculator.Calculate(passAttempts, passCompletions, yards, touchdowns, interceptions).Result;
            Assert.AreEqual(15833M, Math.Truncate(result * 100));
        }

        [TestMethod]
        public void MinimumScore()
        {
            var passAttempts = 100M;
            var passCompletions = 30M;
            var yards = 30M;
            var touchdowns = 0M;
            var interceptions = 9.5M;
            var result = calculator.Calculate(passAttempts, passCompletions, yards, touchdowns, interceptions).Result;
            Assert.AreEqual(0M, Math.Truncate(result * 100));
        }

        [TestMethod]
        public void HigherNumbersStillPerfectScore()
        {
            var passAttempts = 1M;
            var passCompletions = 1M;
            var yards = 1000M;
            var touchdowns = 1M;
            var interceptions = 0M;
            var result = calculator.Calculate(passAttempts, passCompletions, yards, touchdowns, interceptions).Result;
            Assert.AreEqual(15833M, Math.Truncate(result * 100));
        }

        [TestMethod]
        public void LowerNumbersStillMinimumScore()
        {
            var passAttempts = 1M;
            var passCompletions = 0M;
            var yards = -100M;
            var touchdowns = 0M;
            var interceptions = 1M;
            var result = calculator.Calculate(passAttempts, passCompletions, yards, touchdowns, interceptions).Result;
            Assert.AreEqual(0M, Math.Truncate(result * 100));
        }
    }
}
