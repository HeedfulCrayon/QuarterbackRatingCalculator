using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuarterbackRating.Model;
using System;

namespace CalculationTests
{
    [TestClass]
    public class NCAACalculationTests
    {
        private static NCAACalculationService calculator;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            calculator = new NCAACalculationService();
        }

        [TestMethod]
        public void PerfectScore()
        {
            var passAttempts = 1M;
            var passCompletions = 1M;
            var yards = 99M;
            var touchdowns = 1M;
            var interceptions = 0M;
            var result = calculator.Calculate(passAttempts, passCompletions, yards, touchdowns, interceptions).Result;
            Assert.AreEqual(126160M, Math.Truncate(result * 100));
        }

        [TestMethod]
        public void InterceptionsOnly()
        {
            var passAttempts = 1M;
            var passCompletions = 0M;
            var yards = 0M;
            var touchdowns = 0M;
            var interceptions = 1M;
            var result = calculator.Calculate(passAttempts, passCompletions, yards, touchdowns, interceptions).Result;
            Assert.AreEqual(-20000M, Math.Truncate(result * 100));
        }

        [TestMethod]
        public void MinimumScore()
        {
            var passAttempts = 1M;
            var passCompletions = 1M;
            var yards = -99M;
            var touchdowns = 0M;
            var interceptions = 0M;
            var result = calculator.Calculate(passAttempts, passCompletions, yards, touchdowns, interceptions).Result;
            Assert.AreEqual(-73160M, Math.Truncate(result * 100));
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
            Assert.AreEqual(126160M, Math.Truncate(result * 100));
        }

        [TestMethod]
        public void LowerNumbersStillMinimumScore()
        {
            var passAttempts = 1M;
            var passCompletions = 1M;
            var yards = -100M;
            var touchdowns = 0M;
            var interceptions = 0M;
            var result = calculator.Calculate(passAttempts, passCompletions, yards, touchdowns, interceptions).Result;
            Assert.AreEqual(-73160M, Math.Truncate(result * 100));
        }
    }
}
