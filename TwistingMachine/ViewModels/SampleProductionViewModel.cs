using Prism.Mvvm;

namespace TwistingMachine.ViewModels
{
    public class SampleProductionViewModel : BindableBase
    {
        private string _title = "样品生产";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
