using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using TwistingMachine.Entities.Data;
using System.Windows;
using System.Collections.Generic;

namespace TwistingMachine.Dialogs.ViewModels
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

        // 绞合方向选项
        private Dictionary<int, string> _twistDirectionOptions;
        public Dictionary<int, string> TwistDirectionOptions
        {
            get { return _twistDirectionOptions; }
            set { SetProperty(ref _twistDirectionOptions, value); }
        }

        public RecipeEditDialogViewModel(ProductParameters recipe, Window dialog)
        {
            Recipe = recipe;
            _dialog = dialog;
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);

            // 初始化绞合方向选项
            TwistDirectionOptions = new Dictionary<int, string>
            {
                { 1, "顺时针" },
                { 2, "逆时针" }
            };
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