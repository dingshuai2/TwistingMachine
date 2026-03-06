using Prism.Mvvm;

namespace TwistingMachine.ViewModels
{
    public class DebugViewModel : BindableBase
    {
        private string _title = "调试";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
