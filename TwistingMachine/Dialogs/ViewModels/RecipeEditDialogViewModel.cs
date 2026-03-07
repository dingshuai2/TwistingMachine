using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using TwistingMachine.Entities.Data;
using System.Windows;
using System.Collections.Generic;
using TwistingMachine.DbHelpers;

namespace TwistingMachine.Dialogs.ViewModels
{
    public class RecipeEditDialogViewModel : BindableBase
    {
        public RecipeEditDialogViewModel(ProductParameters recipe, Window dialog)
        {
            _originalRecipe = recipe;
            _dialog = dialog;

            // 初始化命令
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);

            // 初始化
            Initialize();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            // 创建配方对象的深拷贝，避免直接修改原始对象
            Recipe = new ProductParameters();
            // 复制所有属性值
            Recipe.Id = _originalRecipe.Id;
            Recipe.RecipeName = _originalRecipe.RecipeName;
            Recipe.CoreArea = _originalRecipe.CoreArea;
            Recipe.LeftEndOpening = _originalRecipe.LeftEndOpening;
            Recipe.WireOuterDiameter = _originalRecipe.WireOuterDiameter;
            Recipe.RightEndOpening = _originalRecipe.RightEndOpening;
            Recipe.TwistedLength = _originalRecipe.TwistedLength;
            Recipe.OverTwistAmount = _originalRecipe.OverTwistAmount;
            Recipe.WireFrontLength = _originalRecipe.WireFrontLength;
            Recipe.TwistWireCount = _originalRecipe.TwistWireCount;
            Recipe.LargePullPressure = _originalRecipe.LargePullPressure;
            Recipe.SmallPullPressure = _originalRecipe.SmallPullPressure;
            Recipe.TwistPitch = _originalRecipe.TwistPitch;
            Recipe.CorrectionFactor = _originalRecipe.CorrectionFactor;
            Recipe.PitchCompensation = _originalRecipe.PitchCompensation;
            Recipe.TwistDirection = _originalRecipe.TwistDirection;
            Recipe.TapeMode = _originalRecipe.TapeMode;

            // 初始化绞合方向选项
            TwistDirectionOptions = new Dictionary<int, string>
            {
                { 1, "顺时针" },
                { 2, "逆时针" }
            };
        }

        private void Save()
        {
            // 保存修改到数据库
            bool success = DbManager.Inst.UpdateData(Recipe);
            if (success)
            {
                // 保存成功，关闭对话框
                _dialog.Close();
            }
            else
            {
                // 保存失败，显示错误信息
                MessageBox.Show("修改失败！");
            }
        }

        private void Cancel()
        {
            _dialog.Close();
        }

        #region 属性
        private ProductParameters _originalRecipe; // 原始配方对象
        private ProductParameters _recipe; // 编辑用的配方对象
        public ProductParameters Recipe
        {
            get { return _recipe; }
            set { SetProperty(ref _recipe, value); }
        }

        private Window _dialog;

        // 绞合方向选项
        private Dictionary<int, string> _twistDirectionOptions;
        public Dictionary<int, string> TwistDirectionOptions
        {
            get { return _twistDirectionOptions; }
            set { SetProperty(ref _twistDirectionOptions, value); }
        }
        #endregion

        #region 命令

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        #endregion
    }
}