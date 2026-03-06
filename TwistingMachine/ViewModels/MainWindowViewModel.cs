using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;

namespace TwistingMachine.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            CloseCommand = new DelegateCommand(Close);
            MinimizeCommand = new DelegateCommand(Minimize);

            PageViewModels = new ObservableCollection<BindableBase>
            {
                new ProductionViewModel { Title = "正在生产" },
                new SampleProductionViewModel { Title = "样品生产" },
                new SettingsViewModel { Title = "设置" },
                new DebugViewModel { Title = "调试" },
                new IOStatusViewModel { Title = "IO状态" },
                new RecipeViewModel { Title = "配方" }
            };

            CurrentViewModel = PageViewModels.First();
        }

        public ObservableCollection<BindableBase> PageViewModels { get; set; }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public ICommand CloseCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }

        private void Close()
        {
            Application.Current.Shutdown();
        }

        private void Minimize()
        {
            var mainWindow = Application.Current.MainWindow;
            if (mainWindow != null)
            {
                mainWindow.WindowState = WindowState.Minimized;
            }
        }
    }
}
