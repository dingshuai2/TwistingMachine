using Prism.Mvvm;
using MahApps.Metro.IconPacks;

namespace TwistingMachine.ViewModels
{
    public class RecipeViewModel : BindableBase
    {
        private string _title = "配方";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private PackIconMaterialKind _iconKind = PackIconMaterialKind.BookOpenPageVariant;
        public PackIconMaterialKind IconKind
        {
            get { return _iconKind; }
            set { SetProperty(ref _iconKind, value); }
        }
    }
}
