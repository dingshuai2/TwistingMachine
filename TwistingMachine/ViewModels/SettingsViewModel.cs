using Prism.Mvvm;
using MahApps.Metro.IconPacks;

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

        private PackIconMaterialKind _iconKind = PackIconMaterialKind.Cog;
        public PackIconMaterialKind IconKind
        {
            get { return _iconKind; }
            set { SetProperty(ref _iconKind, value); }
        }
    }
}
