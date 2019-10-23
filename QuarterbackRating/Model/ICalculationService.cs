using System.Threading.Tasks;

namespace QuarterbackRating.Model
{
    public interface ICalculationService
    {
        Task<decimal> Calculate(decimal passAttempts, decimal passCompletions, decimal passYards, decimal touchdowns, decimal interceptions);
    }
}
