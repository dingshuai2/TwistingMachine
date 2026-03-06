using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace TwistingMachine.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 1. 获取工作区大小（不包含任务栏）
            var workArea = SystemParameters.WorkArea;

            // 2. 精确设置窗口位置和尺寸（匹配工作区）
            this.WindowState = WindowState.Normal;
            this.Left = workArea.Left;
            this.Top = workArea.Top;
            this.Width = workArea.Width;
            this.Height = workArea.Height;

            // 3. 强制刷新布局，确保设置生效
            this.UpdateLayout();
        }
    }
}