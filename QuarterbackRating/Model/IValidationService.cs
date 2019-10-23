namespace QuarterbackRating.Model
{
    public interface IValidationService
    {
        string ValidateProperty(string propertyName, decimal? passAttempts, decimal? passCompletions, decimal? passYards, decimal? touchdowns, decimal? interceptions);
        string ValidateEntries(decimal? passAttempts, decimal? passCompletions, decimal? touchdowns, decimal? interceptions);
        bool Errors { get; }
    }
}
