using System;
using System.Threading.Tasks;

namespace QuarterbackRating.Model
{
    public class NFLCalculationService : ICalculationService
    {
        public Task<decimal> Calculate(PasserStats passerStats)
        {
            return Task.Run(() => PerformCalculation(passerStats));
        }

        private decimal PerformCalculation(PasserStats passerStats)
        {
            var a = CheckMaxAndMin(((passerStats.PassCompletions / passerStats.PassAttempts) - .3M) * 5);
            var b = CheckMaxAndMin(((passerStats.PassYards / passerStats.PassAttempts) - 3) * .25M);
            var c = CheckMaxAndMin((passerStats.Touchdowns / passerStats.PassAttempts) * 20);
            var d = CheckMaxAndMin(2.375M - ((passerStats.Interceptions / passerStats.PassAttempts) * 25));

            var rating = ((a + b + c + d) / 6) * 100;
            return rating;
        }

        private decimal CheckMaxAndMin(decimal? value)
        {
            if (value > 0)
            {
                return Math.Min(value.Value, 2.375M);
            }
            else
            {
                return Math.Max(value.Value, 0);
            }
        }
    }
}
