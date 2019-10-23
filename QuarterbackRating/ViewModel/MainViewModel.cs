using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using QuarterbackRating.Model;
using System.ComponentModel;
using System.Threading.Tasks;

namespace QuarterbackRating.ViewModel
{
    public class MainViewModel : ObservableObject, IDataErrorInfo
    {
        private readonly IValidationService validationService;
        private RelayCommand calculateCommand;

        private string error;
        private decimal? passAttempts;
        private decimal? passCompletions;
        private decimal? passYards;
        private decimal? touchdowns;
        private decimal? interceptions;
        private decimal? rating;
        private League selectedLeague;

        public MainViewModel(IValidationService validationService)
        {
            this.validationService = validationService;
        }

        public decimal? PassAttempts
        {
            get => passAttempts;
            set => Set(() => PassAttempts, ref passAttempts, value);
        }

        public decimal? PassCompletions
        {
            get => passCompletions;
            set => Set(() => PassCompletions, ref passCompletions, value);
        }

        public decimal? PassYards
        {
            get => passYards;
            set => Set(() => PassYards, ref passYards, value);
        }

        public decimal? Touchdowns
        {
            get => touchdowns;
            set => Set(() => Touchdowns, ref touchdowns, value);
        }

        public decimal? Interceptions
        {
            get => interceptions;
            set => Set(() => Interceptions, ref interceptions, value);
        }

        public decimal? Rating
        {
            get => rating;
            set => Set(() => Rating, ref rating, value);
        }

        public League SelectedLeague
        {
            get => selectedLeague;
            set => Set(() => SelectedLeague, ref selectedLeague, value);
        }


        public string Error
        {
            get => error;
            set => Set(() => Error, ref error, value);
        }

        public string this[string columnName]
        {
            get => Validate(columnName);
        }
        public RelayCommand CalculateCommand
        {
            get
            {
                return calculateCommand ?? (calculateCommand = new RelayCommand(
                    async () =>
                    {
                        await Calculate();
                    }, () => CanExecuteCalculation()));
            }
        }

        private bool CanExecuteCalculation()
        {
            RaisePropertyChanged(null);
            Error = validationService.ValidateEntries(PassAttempts, PassCompletions, Touchdowns, Interceptions);
            return !validationService.Errors;
        }

        private async Task Calculate()
        {
            ICalculationService calculationService;
            if (SelectedLeague == League.NFL)
            {
                calculationService = new NFLCalculationService();
            }
            else
            {
                calculationService = new NCAACalculationService();
            }
            Rating = await calculationService.Calculate(PassAttempts.Value, PassCompletions.Value, PassYards.Value, Touchdowns.Value, Interceptions.Value);
        }

        private string Validate(string propertyName)
        {
            string validationMessage = validationService.ValidateProperty(propertyName, PassAttempts, PassCompletions, PassYards, Touchdowns, Interceptions);
            return validationMessage;
        }
    }
}