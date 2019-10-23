using System.Collections.Generic;
using System.Linq;

namespace QuarterbackRating.Model
{
    public class ValidationService : IValidationService
    {
        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();

        public string ValidateEntries(decimal? passAttempts, decimal? passCompletions, decimal? touchdowns, decimal? interceptions)
        {
            string totalError = ValidateTotal(passAttempts, passCompletions, touchdowns, interceptions);
            return UpdateErrorTable("total", totalError);
        }

        public bool Errors => errors.Count > 0;

        public string ValidateProperty(string propertyName, decimal? passAttempts, decimal? passCompletions, decimal? passYards, decimal? touchdowns, decimal? interceptions)
        {
            switch (propertyName)
            {
                case "PassAttempts":
                    string passAttemptError = ValidateAttempts(passAttempts, passCompletions, touchdowns, interceptions);
                    return UpdateErrorTable(propertyName, passAttemptError);
                case "PassCompletions":
                    string passCompletionError = ValidatePassCompletions(passAttempts, passCompletions);
                    return UpdateErrorTable(propertyName, passCompletionError);
                case "Touchdowns":
                    string touchdownError = ValidateTouchdowns(passCompletions, touchdowns);
                    return UpdateErrorTable(propertyName, touchdownError);
                case "PassYards":
                    string yardsError = ValidateYards(passYards);
                    return UpdateErrorTable(propertyName, yardsError);
                case "Interceptions":
                    string interceptionsError = ValidateInterceptions(interceptions);
                    return UpdateErrorTable(propertyName, interceptionsError);
                default:
                    return string.Empty;
            }
        }

        private string UpdateErrorTable(string propertyName, string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                if (errors.ContainsKey(propertyName))
                {
                    errors.Remove(propertyName);
                }
                return string.Empty;
            }
            if (errors.ContainsKey(propertyName))
            {
                errors[propertyName] = error;
            }
            else
            {
                errors.Add(propertyName, error);
            }
            return error;
        }

        private string ValidatePassCompletions(decimal? passAttempts, decimal? passCompletions)
        {
            if (!passCompletions.HasValue)
            {
                return "Enter a value for completions";
            }
            if (passCompletions > passAttempts)
            {
                return "Pass Completions cannot be greater than Pass Attempts";
            }
            return string.Empty;
        }

        private string ValidateTouchdowns(decimal? passCompletions, decimal? touchdowns)
        {
            if (!touchdowns.HasValue)
            {
                return "Enter a value for touchdowns";
            }
            if (passCompletions< touchdowns)
            {
                return "Touchdowns cannot be greater than completions";
            }
            return string.Empty;
        }

        private string ValidateAttempts(decimal? passAttempts, decimal? passCompletions, decimal? touchdowns, decimal? interceptions)
        {
            if (!passAttempts.HasValue)
            {
                return "Pass Attempts must have a value";
            }
            if (passAttempts == 0)
            {
                return "Pass Attempts must be greater than zero";
            }
            return string.Empty;
        }

        private string ValidateInterceptions(decimal? interceptions)
        {
            if (!interceptions.HasValue)
            {
                return "Enter a value for interceptions";
            }
            return string.Empty;
        }

        private string ValidateYards(decimal? passYards)
        {
            if (!passYards.HasValue)
            {
                return "Enter a value for yards gained";
            }
            return string.Empty;
        }

        private string ValidateTotal(decimal? passAttempts, decimal? passCompletions, decimal? touchdowns, decimal? interceptions)
        {
            if (passAttempts < passCompletions + interceptions)
            {
                return "Pass Attempts must be greater than or equal to Completions + Interceptions";
            }
            return string.Empty;
        }
    }
}
