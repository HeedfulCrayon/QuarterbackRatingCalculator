using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using QuarterbackRating.Model;
using System.Threading.Tasks;

namespace QuarterbackRating.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand calculateCommand;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            PasserStats = new PasserStats();
        }

        public PasserStats PasserStats { get; private set; }
        public League SelectedLeague { get; set; }
        public RelayCommand CalculateCommand
        {
            get
            {
                return calculateCommand ?? (calculateCommand = new RelayCommand(
                    async () =>
                    {
                        await Calculate(PasserStats);
                    }, () => CanExecuteCalculation()));
            }
        }

        private bool CanExecuteCalculation()
        {
            if (PasserStats.PassAttempts != 0)
            {
                if (PasserStats.PassAttempts != null && PasserStats.PassCompletions != null && PasserStats.PassYards != null && PasserStats.Interceptions != null && PasserStats.Touchdowns != null)
                {
                    return true;
                }
                }
            return false;
        }

        private async Task Calculate(PasserStats passerStats)
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
            PasserStats.Rating = await calculationService.Calculate(passerStats);
        }
    }
}