using Prism.Mvvm;

namespace TwistingMachine.ViewModels
{
    public class RecipeViewModel : BindableBase
    {
        private string _title = "配方";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
