using System;
using System.Threading.Tasks;

namespace QuarterbackRating.Model
{
    public class NCAACalculationService : ICalculationService
    {
        public Task<decimal> Calculate(PasserStats passerStats)
        {
            return Task.Run(() => PerformCalculation(passerStats));
        }
        private decimal PerformCalculation(PasserStats passerStats)
        {
            var a = passerStats.PassYards * 8.4M;
            var b = passerStats.Touchdowns * 330;
            var c = passerStats.PassCompletions * 100;
            var d = passerStats.Interceptions * 200;

            var rating = (a + b + c - d) / passerStats.PassAttempts;
            return rating.Value;
        }
    }
}
