using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace RibbonMvvmPoC.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private int _clickCounter;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            DoSomethingCommand = new RelayCommand(DoSomething, () => true);
            IncrementCounterCommand = new RelayCommand(IncrementCounter, () => true);
            PrintCommand = new RelayCommand(PrintCanvas, () => true);
            ClickCounter = 0;
        }

        private void PrintCanvas()
        {
            MessengerInstance.Send(string.Empty, "PrintCanvas");
        }


        public RelayCommand DoSomethingCommand { get; private set; }
        public RelayCommand IncrementCounterCommand { get; private set; }
        public RelayCommand PrintCommand { get; private set; }

        public int ClickCounter
        {
            get { return _clickCounter; }
            set
            {
                _clickCounter = value;
                RaisePropertyChanged();
            }
        }

        private void IncrementCounter()
        {
            ClickCounter += 1;
        }

        private void DoSomething()
        {
            MessengerInstance.Send("New way message!");
        }
    }
}