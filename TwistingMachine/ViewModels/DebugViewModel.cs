using Prism.Mvvm;
using MahApps.Metro.IconPacks;

namespace TwistingMachine.ViewModels
{
    public class DebugViewModel : BindableBase
    {
        private string _title = "调试";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private PackIconMaterialKind _iconKind = PackIconMaterialKind.Bug;
        public PackIconMaterialKind IconKind
        {
            get { return _iconKind; }
            set { SetProperty(ref _iconKind, value); }
        }
    }
}
