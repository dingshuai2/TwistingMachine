using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;

namespace TwistingMachine.ViewModels
{
    public class ProductionViewModel : BindableBase
    {
        public ProductionViewModel()
        {
            LoosenJawsCommand = new DelegateCommand(LoosenJaws);
            ResetCommand = new DelegateCommand(Reset);
            ApplyTapeCommand = new DelegateCommand(ApplyTape);
        }

        private string _title = "正在生产";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
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

        private string _recipeName = "配方测试名称";
        public string RecipeName
        {
            get { return _recipeName; }
            set { SetProperty(ref _recipeName, value); }
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

        private string _coreArea = "1.5";
        public string CoreArea
        {
            get { return _coreArea; }
            set { SetProperty(ref _coreArea, value); }
        }

        private string _wireOuterDiameter = "2.5";
        public string WireOuterDiameter
        {
            get { return _wireOuterDiameter; }
            set { SetProperty(ref _wireOuterDiameter, value); }
        }

        private string _twistedLength = "3500";
        public string TwistedLength
        {
            get { return _twistedLength; }
            set { SetProperty(ref _twistedLength, value); }
        }

        private string _twistPitch = "35";
        public string TwistPitch
        {
            get { return _twistPitch; }
            set { SetProperty(ref _twistPitch, value); }
        }

        private string _pitchCompensation = "-1";
        public string PitchCompensation
        {
            get { return _pitchCompensation; }
            set { SetProperty(ref _pitchCompensation, value); }
        }

        private string _setProductionQuantity = "";
        public string SetProductionQuantity
        {
            get { return _setProductionQuantity; }
            set { SetProperty(ref _setProductionQuantity, value); }
        }

        private string _currentProductionQuantity = "0";
        public string CurrentProductionQuantity
        {
            get { return _currentProductionQuantity; }
            set { SetProperty(ref _currentProductionQuantity, value); }
        }

        private string _leftEndOpening = "35";
        public string LeftEndOpening
        {
            get { return _leftEndOpening; }
            set { SetProperty(ref _leftEndOpening, value); }
        }

        private string _rightEndOpening = "35";
        public string RightEndOpening
        {
            get { return _rightEndOpening; }
            set { SetProperty(ref _rightEndOpening, value); }
        }

        private string _overTwistAmount = "15";
        public string OverTwistAmount
        {
            get { return _overTwistAmount; }
            set { SetProperty(ref _overTwistAmount, value); }
        }

        private string _twistWireCount = "2";
        public string TwistWireCount
        {
            get { return _twistWireCount; }
            set { SetProperty(ref _twistWireCount, value); }
        }

        private string _twistDirection = "逆时针";
        public string TwistDirection
        {
            get { return _twistDirection; }
            set { SetProperty(ref _twistDirection, value); }
        }

        private string _wireFrontLength = "5500";
        public string WireFrontLength
        {
            get { return _wireFrontLength; }
            set { SetProperty(ref _wireFrontLength, value); }
        }

        private string _largePullPressure = "0.08";
        public string LargePullPressure
        {
            get { return _largePullPressure; }
            set { SetProperty(ref _largePullPressure, value); }
        }

        private string _smallPullPressure = "0.22";
        public string SmallPullPressure
        {
            get { return _smallPullPressure; }
            set { SetProperty(ref _smallPullPressure, value); }
        }

        private string _correctionFactor = "1";
        public string CorrectionFactor
        {
            get { return _correctionFactor; }
            set { SetProperty(ref _correctionFactor, value); }
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
