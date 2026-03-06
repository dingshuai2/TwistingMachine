using Prism.Mvvm;
using MahApps.Metro.IconPacks;

namespace TwistingMachine.ViewModels
{
    public class SampleProductionViewModel : BindableBase
    {
        private string _title = "样品生产";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private PackIconMaterialKind _iconKind = PackIconMaterialKind.Package;
        public PackIconMaterialKind IconKind
        {
            get { return _iconKind; }
            set { SetProperty(ref _iconKind, value); }
        }
    }
}
