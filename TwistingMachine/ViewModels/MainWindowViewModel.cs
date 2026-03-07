using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using TwistingMachine.Dialogs;
using MahApps.Metro.Controls;
using Serilog;
using System;

namespace TwistingMachine.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            CloseCommand = new DelegateCommand(Close);
            MinimizeCommand = new DelegateCommand(Minimize);
            OpenTestDialogCommand = new DelegateCommand(OpenTestDialog);

            //初始化导航栏
            PageViewModels = new ObservableCollection<BindableBase>
            {
                new ProductionViewModel { Title = "正在生产" },
                new RecipeViewModel { Title = "配方" },
                new SampleProductionViewModel { Title = "样品生产" },
                new SettingsViewModel { Title = "设置" },
                new DebugViewModel { Title = "调试" },
                new IOStatusViewModel { Title = "IO状态" }
            };

            CurrentViewModel = PageViewModels.First();
        }

        private void OpenTestDialog()
        {
            try
            {
                MetroWindow? wd = Application.Current.MainWindow as MetroWindow;
                var dlg = new TestDialog(wd);
                TestDialogViewModel dlgModel = new TestDialogViewModel();
                dlg.DataContext = dlgModel;
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error($"打开测试弹窗出错：{ex.Message}");
            }
        }

        /// <summary>
        /// 关闭应用程序
        /// </summary>
        private void Close()
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// 最小化程序
        /// </summary>
        private void Minimize()
        {
            var mainWindow = Application.Current.MainWindow;
            if (mainWindow != null)
            {
                mainWindow.WindowState = WindowState.Minimized;
            }
        }

        #region 变量

        public ObservableCollection<BindableBase> PageViewModels { get; set; }

        private BindableBase _currentViewModel = null!;
        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }
        #endregion

        #region 命令

        public ICommand CloseCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }
        public ICommand OpenTestDialogCommand { get; private set; }
        #endregion
    }
}
