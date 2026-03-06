using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using MahApps.Metro.IconPacks;
using TwistingMachine.Entities;
using TwistingMachine.DbHelpers;

namespace TwistingMachine.ViewModels
{
    public class ProductionViewModel : BindableBase
    {
        public ProductionViewModel()
        {
            LoosenJawsCommand = new DelegateCommand(LoosenJaws);
            ResetCommand = new DelegateCommand(Reset);
            ApplyTapeCommand = new DelegateCommand(ApplyTape);

            LoadParametersFromDatabase();
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        private void LoadParametersFromDatabase()
        {
            try
            {
                var db = DbContext.Db;
                var param = db.Queryable<ProductParameters>().First();

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
        public PackIconMaterialKind IconKind
        {
            get { return _iconKind; }
            set { SetProperty(ref _iconKind, value); }
        }

        #region 方法

        private void LoosenJaws()
        {
        }

        private void Reset()
        {
        }

        private void ApplyTape()
        {
        }

        #endregion

        #region 属性

        private ProductParameters _productParameters = new ProductParameters();
        public ProductParameters ProductParameters
        {
            get { return _productParameters; }
            set { SetProperty(ref _productParameters, value); }
        }

        private string _wire1Color = "Green";
        public string Wire1Color
        {
            get { return _wire1Color; }
            set { SetProperty(ref _wire1Color, value); }
        }

        private string _wire2Color = "Blue";
        public string Wire2Color
        {
            get { return _wire2Color; }
            set { SetProperty(ref _wire2Color, value); }
        }

        private string _currentProductionQuantity = "0";
        public string CurrentProductionQuantity
        {
            get { return _currentProductionQuantity; }
            set { SetProperty(ref _currentProductionQuantity, value); }
        }

        private string _ct = "0";
        public string CT
        {
            get { return _ct; }
            set { SetProperty(ref _ct, value); }
        }

        #endregion

        #region 命令

        public ICommand LoosenJawsCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand ApplyTapeCommand { get; private set; }

        #endregion

        #region 绘制双绞线属性

        public string Wire1Path
        {
            get
            {
                return "M 50,40 C 100,20 150,60 200,40 C 250,20 300,60 350,40 C 400,20 450,60 500,40";
            }
        }

        public string Wire2Path
        {
            get
            {
                return "M 50,50 C 100,70 150,30 200,50 C 250,70 300,30 350,50 C 400,70 450,30 500,50";
            }
        }

        #endregion

        #region 前后选择区方块颜色

        private string _frontBackColor1 = "LightGray";
        public string FrontBackColor1
        {
            get { return _frontBackColor1; }
            set { SetProperty(ref _frontBackColor1, value); }
        }

        private string _frontBackColor2 = "LightGray";
        public string FrontBackColor2
        {
            get { return _frontBackColor2; }
            set { SetProperty(ref _frontBackColor2, value); }
        }

        private string _frontBackColor3 = "LightGray";
        public string FrontBackColor3
        {
            get { return _frontBackColor3; }
            set { SetProperty(ref _frontBackColor3, value); }
        }

        private string _frontBackColor4 = "LightGray";
        public string FrontBackColor4
        {
            get { return _frontBackColor4; }
            set { SetProperty(ref _frontBackColor4, value); }
        }

        private string _frontBackColor5 = "LightGray";
        public string FrontBackColor5
        {
            get { return _frontBackColor5; }
            set { SetProperty(ref _frontBackColor5, value); }
        }

        private string _frontBackColor6 = "LightGray";
        public string FrontBackColor6
        {
            get { return _frontBackColor6; }
            set { SetProperty(ref _frontBackColor6, value); }
        }

        private string _frontBackColor7 = "LightGray";
        public string FrontBackColor7
        {
            get { return _frontBackColor7; }
            set { SetProperty(ref _frontBackColor7, value); }
        }

        private string _frontBackColor8 = "LightGray";
        public string FrontBackColor8
        {
            get { return _frontBackColor8; }
            set { SetProperty(ref _frontBackColor8, value); }
        }

        #endregion
    }
}
