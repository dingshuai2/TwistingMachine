using MahApps.Metro.Controls;
using System.Windows;

namespace TwistingMachine.Dialogs
{
    /// <summary>
    /// TestDialog.xaml 的交互逻辑
    /// </summary>
    public partial class TestDialog : MahApps.Metro.Controls.MetroWindow
    {
        public TestDialogViewModel ViewModel { get; set; }

        public TestDialog(MetroWindow wd)
        {
            InitializeComponent();
            this.Owner = wd;
        }
    }
}
