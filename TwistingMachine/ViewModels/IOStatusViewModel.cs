using Prism.Mvvm;

namespace TwistingMachine.ViewModels
{
    public class IOStatusViewModel : BindableBase
    {
        private string _title = "IO状态";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
