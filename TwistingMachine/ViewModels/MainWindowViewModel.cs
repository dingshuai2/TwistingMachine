using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;

namespace TwistingMachine.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            // 初始化命令
            LoosenJawsCommand = new DelegateCommand(LoosenJaws);
            ResetCommand = new DelegateCommand(Reset);
            ApplyTapeCommand = new DelegateCommand(ApplyTape);
            CloseCommand = new DelegateCommand(Close);
            MinimizeCommand = new DelegateCommand(Minimize);
        }


        #region 方法

        private void LoosenJaws()
        {
            // 实现松开夹爪的逻辑
        }

        private void Reset()
        {
            // 实现重置的逻辑
        }

        private void ApplyTape()
        {
            // 实现上胶带的逻辑
        }

        private void Close()
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Minimize()
        {
            var mainWindow = System.Windows.Application.Current.MainWindow;
            if (mainWindow != null)
            {
                mainWindow.WindowState = System.Windows.WindowState.Minimized;
            }
        }


        #endregion

        #region 属性
        // 配方名称
        private string _recipeName = "配方测试名称";
        public string RecipeName
        {
            get { return _recipeName; }
            set { SetProperty(ref _recipeName, value); }
        }

        // 线1颜色
        private string _wire1Color = "Green";
        public string Wire1Color
        {
            get { return _wire1Color; }
            set { SetProperty(ref _wire1Color, value); }
        }

        // 线2颜色
        private string _wire2Color = "Blue";
        public string Wire2Color
        {
            get { return _wire2Color; }
            set { SetProperty(ref _wire2Color, value); }
        }

        // 线芯面积
        private string _coreArea = "1.5";
        public string CoreArea
        {
            get { return _coreArea; }
            set { SetProperty(ref _coreArea, value); }
        }

        // 导线外径
        private string _wireOuterDiameter = "2.5";
        public string WireOuterDiameter
        {
            get { return _wireOuterDiameter; }
            set { SetProperty(ref _wireOuterDiameter, value); }
        }

        // 绞后长度
        private string _twistedLength = "3500";
        public string TwistedLength
        {
            get { return _twistedLength; }
            set { SetProperty(ref _twistedLength, value); }
        }

        // 绞合节距
        private string _twistPitch = "35";
        public string TwistPitch
        {
            get { return _twistPitch; }
            set { SetProperty(ref _twistPitch, value); }
        }

        // 节距补偿
        private string _pitchCompensation = "-1";
        public string PitchCompensation
        {
            get { return _pitchCompensation; }
            set { SetProperty(ref _pitchCompensation, value); }
        }

        // 设定生产数量
        private string _setProductionQuantity = "";
        public string SetProductionQuantity
        {
            get { return _setProductionQuantity; }
            set { SetProperty(ref _setProductionQuantity, value); }
        }

        // 当前生产数量
        private string _currentProductionQuantity = "0";
        public string CurrentProductionQuantity
        {
            get { return _currentProductionQuantity; }
            set { SetProperty(ref _currentProductionQuantity, value); }
        }

        // 左端开口
        private string _leftEndOpening = "35";
        public string LeftEndOpening
        {
            get { return _leftEndOpening; }
            set { SetProperty(ref _leftEndOpening, value); }
        }

        // 右端开口
        private string _rightEndOpening = "35";
        public string RightEndOpening
        {
            get { return _rightEndOpening; }
            set { SetProperty(ref _rightEndOpening, value); }
        }

        // 过绞合量
        private string _overTwistAmount = "15";
        public string OverTwistAmount
        {
            get { return _overTwistAmount; }
            set { SetProperty(ref _overTwistAmount, value); }
        }

        // 绞线缆数
        private string _twistWireCount = "2";
        public string TwistWireCount
        {
            get { return _twistWireCount; }
            set { SetProperty(ref _twistWireCount, value); }
        }

        // 绞合方向
        private string _twistDirection = "逆时针";
        public string TwistDirection
        {
            get { return _twistDirection; }
            set { SetProperty(ref _twistDirection, value); }
        }

        // 线前长度
        private string _wireFrontLength = "5500";
        public string WireFrontLength
        {
            get { return _wireFrontLength; }
            set { SetProperty(ref _wireFrontLength, value); }
        }

        // 大拉气压
        private string _largePullPressure = "0.08";
        public string LargePullPressure
        {
            get { return _largePullPressure; }
            set { SetProperty(ref _largePullPressure, value); }
        }

        // 小拉气压
        private string _smallPullPressure = "0.22";
        public string SmallPullPressure
        {
            get { return _smallPullPressure; }
            set { SetProperty(ref _smallPullPressure, value); }
        }

        // 修正系数
        private string _correctionFactor = "1";
        public string CorrectionFactor
        {
            get { return _correctionFactor; }
            set { SetProperty(ref _correctionFactor, value); }
        }

        // CT
        private string _ct = "0";
        public string CT
        {
            get { return _ct; }
            set { SetProperty(ref _ct, value); }
        }
        #endregion

        #region 命令

        // 松开夹爪命令
        public ICommand LoosenJawsCommand { get; private set; }

        // 重置命令
        public ICommand ResetCommand { get; private set; }

        // 上胶带命令
        public ICommand ApplyTapeCommand { get; private set; }

        // 关闭命令
        public ICommand CloseCommand { get; private set; }

        // 最小化命令
        public ICommand MinimizeCommand { get; private set; }

        #endregion

        #region 绘制双绞线属性
        public string Wire1Path
        {
            get {
                // 生成线1的路径数据
                return "M 50,40 C 100,20 150,60 200,40 C 250,20 300,60 350,40 C 400,20 450,60 500,40";
            }
        }

        public string Wire2Path
        {
            get {
                // 生成线2的路径数据
                return "M 50,50 C 100,70 150,30 200,50 C 250,70 300,30 350,50 C 400,70 450,30 500,50";
            }
        }
        #endregion
    }
}