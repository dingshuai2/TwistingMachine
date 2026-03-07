using MahApps.Metro.Controls;
using TwistingMachine.Entities.Data;

namespace TwistingMachine.Dialogs
{
    /// <summary>
    /// RecipeEditDialog.xaml 的交互逻辑
    /// </summary>
    public partial class RecipeEditDialog : MetroWindow
    {
        public RecipeEditDialog(MetroWindow owner)
        {
            InitializeComponent();
            Owner = owner;
        }
    }
}