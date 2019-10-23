using System;
using System.Threading.Tasks;

namespace QuarterbackRating.Model
{
    public class NCAACalculationService : ICalculationService
    {
        public Task<decimal> Calculate(decimal passAttempts, decimal passCompletions, decimal passYards, decimal touchdowns, decimal interceptions)
        {
            return Task.Run(() => PerformCalculation(passAttempts, passCompletions, passYards, touchdowns, interceptions));
        }

        private decimal PerformCalculation(decimal passAttempts, decimal passCompletions, decimal passYards, decimal touchdowns, decimal interceptions)
        {
            passYards = Math.Min(passCompletions * 99, passYards);
            var a = passYards * 8.4M;
            var b = touchdowns * 330;
            var c = passCompletions * 100;
            var d = interceptions * 200;

            var rating = (a + b + c - d) / passAttempts;
            return rating;
        }
    }
}
