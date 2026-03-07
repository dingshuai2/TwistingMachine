using Prism.Mvvm;
using Prism.Commands;
using MahApps.Metro.IconPacks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TwistingMachine.Entities.Data;
using TwistingMachine.Dialogs;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Interop;
using System.Linq;
using Serilog;

namespace TwistingMachine.ViewModels
{
    /// <summary>
    /// 配方管理视图模型
    /// </summary>
    public class RecipeViewModel : BindableBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RecipeViewModel()
        {
            // 初始化命令
            EditRecipeCommand = new DelegateCommand(EditRecipe);
            DownloadRecipeCommand = new DelegateCommand(DownloadRecipe);
            DeleteRecipeCommand = new DelegateCommand(DeleteRecipe);
            SearchCommand = new DelegateCommand(Search);

            // 初始化配方数据
            InitializeRecipes();
        }

        /// <summary>
        /// 加载配方数据
        /// </summary>
        private void LoadRecipes()
        {
            try
            {
                // 从数据库读取所有配方数据
                var recipesFromDb = TwistingMachine.DbHelpers.DbManager.Inst.QueryDatas<TwistingMachine.Entities.Data.ProductParameters>();

                // 根据搜索文本过滤配方数据
                if (!string.IsNullOrEmpty(SearchText))
                {
                    var filteredRecipes = recipesFromDb.Where(r => r.RecipeName.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
                    Recipes = new ObservableCollection<ProductParameters>(filteredRecipes);
                }
                else
                {
                    // 如果搜索文本为空，显示所有配方
                    Recipes = new ObservableCollection<ProductParameters>(recipesFromDb);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"RecipeViewModel:加载配方数据出错{ex.Message}");
            }
        }

        /// <summary>
        /// 初始化配方数据
        /// </summary>
        private void InitializeRecipes()
        {
            // 调用加载配方数据方法
            LoadRecipes();
        }

        /// <summary>
        /// 编辑配方
        /// </summary>
        private void EditRecipe()
        {
            if (SelectedRecipe != null)
            {
                MetroWindow? wd = Application.Current.MainWindow as MetroWindow;
                var dlg = new RecipeEditDialog(wd);
                dlg.DataContext = new RecipeEditDialogViewModel(SelectedRecipe, dlg);
                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择需要编辑的配方！");
            }
        }

        /// <summary>
        /// 下载配方
        /// </summary>
        private void DownloadRecipe()
        {
            // 实现下载配方功能
        }

        /// <summary>
        /// 删除配方
        /// </summary>
        private void DeleteRecipe()
        {
            // 实现删除配方功能
        }

        /// <summary>
        /// 搜索配方
        /// </summary>
        private void Search()
        {
            // 调用加载配方数据方法
            LoadRecipes();
        }

        #region 属性

        /// <summary>
        /// 标题
        /// </summary>
        private string _title = "配方";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// 图标
        /// </summary>
        private PackIconMaterialKind _iconKind = PackIconMaterialKind.BookOpenPageVariant;
        public PackIconMaterialKind IconKind
        {
            get { return _iconKind; }
            set { SetProperty(ref _iconKind, value); }
        }

        /// <summary>
        /// 配方列表
        /// </summary>
        private ObservableCollection<ProductParameters> _recipes;
        public ObservableCollection<ProductParameters> Recipes
        {
            get { return _recipes; }
            set { SetProperty(ref _recipes, value); }
        }

        /// <summary>
        /// 选中的配方
        /// </summary>
        private ProductParameters _selectedRecipe;
        public ProductParameters SelectedRecipe
        {
            get { return _selectedRecipe; }
            set { SetProperty(ref _selectedRecipe, value); }
        }

        /// <summary>
        /// 搜索文本
        /// </summary>
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        #endregion

        #region 命令

        /// <summary>
        /// 编辑配方命令
        /// </summary>
        public ICommand EditRecipeCommand { get; private set; }

        /// <summary>
        /// 下载配方命令
        /// </summary>
        public ICommand DownloadRecipeCommand { get; private set; }

        /// <summary>
        /// 删除配方命令
        /// </summary>
        public ICommand DeleteRecipeCommand { get; private set; }

        /// <summary>
        /// 搜索命令
        /// </summary>
        public ICommand SearchCommand { get; private set; }

        #endregion
    }
}
