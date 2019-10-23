using System.Threading.Tasks;

namespace QuarterbackRating.Model
{
    public interface ICalculationService
    {
        Task<decimal> Calculate(PasserStats passerStats);
    }
}
