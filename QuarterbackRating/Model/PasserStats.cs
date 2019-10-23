using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace QuarterbackRating.Model
{
    public class PasserStats : ObservableObject
    {
        private Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();
        private decimal? passAttempts;
        private decimal? passCompletions;
        private decimal? passYards;
        private decimal? touchdowns;
        private decimal? interceptions;
        private decimal? rating;

        public decimal? PassAttempts 
        {
            get
            {
                return passAttempts;
            }
            set
            {
                Set(() => PassAttempts, ref passAttempts, value);
            }
        }
        public decimal? PassCompletions
        {
            get
            {
                return passCompletions;
            }
            set
            {
                Set(() => PassCompletions, ref passCompletions, value);
            }
        }
        public decimal? PassYards
        {
            get
            {
                return passYards;
            }
            set
            {
                Set(() => PassYards, ref passYards, value);
            }
        }
        public decimal? Touchdowns
        {
            get
            {
                return touchdowns;
            }
            set
            {
                Set(() => Touchdowns, ref touchdowns, value);
            }
        }
        public decimal? Interceptions
        {
            get
            {
                return interceptions;
            }
            set
            {
                Set(() => Interceptions, ref interceptions, value);
            }
        }
        public decimal? Rating
        {
            get
            {
                return rating;
            }
            set
            {
                Set(() => Rating, ref rating, value);
            }
        }

        public bool HasErrors
        {
            get
            {
                return propErrors.Count > 0;
            }
        }
    }
}
