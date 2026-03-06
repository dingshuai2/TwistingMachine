using Prism.Mvvm;
using MahApps.Metro.IconPacks;

namespace TwistingMachine.ViewModels
{
    public class IOStatusViewModel : BindableBase
    {
        private string _title = "IO状态";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private PackIconMaterialKind _iconKind = PackIconMaterialKind.ViewList;
        public PackIconMaterialKind IconKind
        {
            get { return _iconKind; }
            set { SetProperty(ref _iconKind, value); }
        }
    }
}
