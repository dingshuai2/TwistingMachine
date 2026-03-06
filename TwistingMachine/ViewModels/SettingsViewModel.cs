using Prism.Mvvm;

namespace TwistingMachine.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private string _title = "设置";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
