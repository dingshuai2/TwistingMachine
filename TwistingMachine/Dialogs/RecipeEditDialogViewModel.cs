using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using TwistingMachine.Entities.Data;
using System.Windows;

namespace TwistingMachine.Dialogs
{
    public class RecipeEditDialogViewModel : BindableBase
    {
        private ProductParameters _recipe;
        public ProductParameters Recipe
        {
            get { return _recipe; }
            set { SetProperty(ref _recipe, value); }
        }

        private Window _dialog;

        public RecipeEditDialogViewModel(ProductParameters recipe, Window dialog)
        {
            Recipe = recipe;
            _dialog = dialog;
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private void Save()
        {
            // 保存修改
            _dialog.Close();
        }

        private void Cancel()
        {
            _dialog.Close();
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
    }
}