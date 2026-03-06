using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using MahApps.Metro.IconPacks;
using TwistingMachine.Entities;
using TwistingMachine.DbHelpers;
using System.Collections.Generic;

namespace TwistingMachine.ViewModels
{
    public class ProductionViewModel : BindableBase
    {
        public ProductionViewModel()
        {
            LoosenJawsCommand = new DelegateCommand(LoosenJaws);
            ResetCommand = new DelegateCommand(Reset);
            ApplyTapeCommand = new DelegateCommand(ApplyTape);
            SaveParametersCommand = new DelegateCommand(SaveParameters);

            // 初始化胶带模式下拉框数据源
            TapeModeOptions = new Dictionary<int, string>
            {
                { 1, "选项1" },
                { 2, "选项2" },
                { 3, "选项3" }
            };

            // 初始化绞合方向下拉框数据源
            TwistDirectionOptions = new Dictionary<int, string>
            {
                { 1, "顺时针" },
                { 2, "逆时针" }
            };

            LoadParametersFromDatabase();
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        private void LoadParametersFromDatabase()
        {
            try
            {
                var param = DbManager.Inst.QueryDatas<ProductParameters>().Where(p => p.RecipeName == "AAA").First();

                if (param != null)
                {
                    ProductParameters = param;
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error($"ProductionViewModel:当前生产界面产品参数加载参数失败：{ex.Message}");
            }
        }

        private string _title = "正在生产";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private PackIconMaterialKind _iconKind = PackIconMaterialKind.Home;
        /// <summary>
        /// 导航图标
        /// </summary>
        public PackIconMaterialKind IconKind
        {
            get { return _iconKind; }
            set { SetProperty(ref _iconKind, value); }
        }

        #region 方法

        /// <summary>
        /// 松开夹爪
        /// </summary>
        private void LoosenJaws()
        {
        }

        /// <summary>
        /// 重置
        /// </summary>
        private void Reset()
        {
        }

        /// <summary>
        /// 上胶带
        /// </summary>
        private void ApplyTape()
        {
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        public void SaveParameters()
        {
            try
            {
                if (ProductParameters == null)
                    return;

                // 保存数据
                DbManager.Inst.UpdateData(ProductParameters);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error($"ProductionViewModel:参数保存失败：{ex.Message}");
            }
        }

        #endregion

        #region 属性

        private ProductParameters _productParameters = new ProductParameters();
        /// <summary>
        /// 当前产品参数
        /// </summary>
        public ProductParameters ProductParameters
        {
            get { return _productParameters; }
            set
            {
                SetProperty(ref _productParameters, value);
            }
        }

        /// <summary>
        /// 胶带模式下拉框数据源
        /// </summary>
        private Dictionary<int, string> _tapeModeOptions;
        public Dictionary<int, string> TapeModeOptions
        {
            get { return _tapeModeOptions; }
            set { SetProperty(ref _tapeModeOptions, value); }
        }

        /// <summary>
        /// 绞合方向下拉框数据源
        /// </summary>
        private Dictionary<int, string> _twistDirectionOptions;
        public Dictionary<int, string> TwistDirectionOptions
        {
            get { return _twistDirectionOptions; }
            set { SetProperty(ref _twistDirectionOptions, value); }
        }

        private string _wire1Color = "Green";
        /// <summary>
        /// 线色
        /// </summary>
        public string Wire1Color
        {
            get { return _wire1Color; }
            set { SetProperty(ref _wire1Color, value); }
        }

        private string _wire2Color = "Blue";
        /// <summary>
        /// 线色
        /// </summary>
        public string Wire2Color
        {
            get { return _wire2Color; }
            set { SetProperty(ref _wire2Color, value); }
        }

        private FrontBackColors _frontBackColors = new FrontBackColors();
        /// <summary>
        /// 前后选择区方块颜色
        /// </summary>
        public FrontBackColors FrontBackColors
        {
            get { return _frontBackColors; }
            set { SetProperty(ref _frontBackColors, value); }
        }

        /// <summary>
        /// 绞线路径
        /// </summary>
        public string Wire1Path
        {
            get
            {
                return "M 50,40 C 100,20 150,60 200,40 C 250,20 300,60 350,40 C 400,20 450,60 500,40";
            }
        }

        /// <summary>
        /// 绞线路径
        /// </summary>
        public string Wire2Path
        {
            get
            {
                return "M 50,50 C 100,70 150,30 200,50 C 250,70 300,30 350,50 C 400,70 450,30 500,50";
            }
        }

        #endregion

        #region 命令

        public ICommand LoosenJawsCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand ApplyTapeCommand { get; private set; }
        public ICommand SaveParametersCommand { get; private set; }

        #endregion
    }
}
