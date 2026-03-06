using SqlSugar;
using Prism.Mvvm;
using TwistingMachine.DbHelpers;
using Serilog;

namespace TwistingMachine.Entities
{
    /// <summary>
    /// 产品参数实体类
    /// </summary>
    [SugarTable("ProductParameters")]
    public class ProductParameters : BindableBase
    {


        /// <summary>
        /// 主键ID
        /// </summary>
        private int _id;
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// 胶带模式
        /// </summary>
        private int _tapeMode;
        [SugarColumn(ColumnName = "tape_mode", ColumnDataType = "INTEGER", IsNullable = true)]
        public int TapeMode
        {
            get => _tapeMode;
            set => SetProperty(ref _tapeMode, value);
        }

        /// <summary>
        /// 配方名称
        /// </summary>
        private string? _recipeName;
        [SugarColumn(ColumnName = "recipe_name", ColumnDataType = "NVARCHAR(100)", IsNullable = true)]
        public string? RecipeName
        {
            get => _recipeName;
            set => SetProperty(ref _recipeName, value);
        }

        /// <summary>
        /// 线芯面积
        /// </summary>
        private double _coreArea;
        [SugarColumn(ColumnName = "core_area", ColumnDataType = "REAL", IsNullable = true)]
        public double CoreArea
        {
            get => _coreArea;
            set => SetProperty(ref _coreArea, value);
        }

        /// <summary>
        /// 左端开口
        /// </summary>
        private double _leftEndOpening;
        [SugarColumn(ColumnName = "left_end_opening", ColumnDataType = "REAL", IsNullable = true)]
        public double LeftEndOpening
        {
            get => _leftEndOpening;
            set => SetProperty(ref _leftEndOpening, value);
        }

        /// <summary>
        /// 线前长度
        /// </summary>
        private double _wireFrontLength;
        [SugarColumn(ColumnName = "wire_front_length", ColumnDataType = "REAL", IsNullable = true)]
        public double WireFrontLength
        {
            get => _wireFrontLength;
            set => SetProperty(ref _wireFrontLength, value);
        }

        /// <summary>
        /// 导线外径
        /// </summary>
        private double _wireOuterDiameter;
        [SugarColumn(ColumnName = "wire_outer_diameter", ColumnDataType = "REAL", IsNullable = true)]
        public double WireOuterDiameter
        {
            get => _wireOuterDiameter;
            set => SetProperty(ref _wireOuterDiameter, value);
        }

        /// <summary>
        /// 右端开口
        /// </summary>
        private double _rightEndOpening;
        [SugarColumn(ColumnName = "right_end_opening", ColumnDataType = "REAL", IsNullable = true)]
        public double RightEndOpening
        {
            get => _rightEndOpening;
            set => SetProperty(ref _rightEndOpening, value);
        }

        /// <summary>
        /// 大拉气压
        /// </summary>
        private double _largePullPressure;
        [SugarColumn(ColumnName = "large_pull_pressure", ColumnDataType = "REAL", IsNullable = true)]
        public double LargePullPressure
        {
            get => _largePullPressure;
            set => SetProperty(ref _largePullPressure, value);
        }

        /// <summary>
        /// 绞后长度
        /// </summary>
        private double _twistedLength;
        [SugarColumn(ColumnName = "twisted_length", ColumnDataType = "REAL", IsNullable = true)]
        public double TwistedLength
        {
            get => _twistedLength;
            set => SetProperty(ref _twistedLength, value);
        }

        /// <summary>
        /// 过绞合量
        /// </summary>
        private double _overTwistAmount;
        [SugarColumn(ColumnName = "over_twist_amount", ColumnDataType = "REAL", IsNullable = true)]
        public double OverTwistAmount
        {
            get => _overTwistAmount;
            set => SetProperty(ref _overTwistAmount, value);
        }

        /// <summary>
        /// 小拉气压
        /// </summary>
        private double _smallPullPressure;
        [SugarColumn(ColumnName = "small_pull_pressure", ColumnDataType = "REAL", IsNullable = true)]
        public double SmallPullPressure
        {
            get => _smallPullPressure;
            set => SetProperty(ref _smallPullPressure, value);
        }

        /// <summary>
        /// 绞合节距
        /// </summary>
        private double _twistPitch;
        [SugarColumn(ColumnName = "twist_pitch", ColumnDataType = "REAL", IsNullable = true)]
        public double TwistPitch
        {
            get => _twistPitch;
            set => SetProperty(ref _twistPitch, value);
        }

        /// <summary>
        /// 绞线缆数
        /// </summary>
        private double _twistWireCount;
        [SugarColumn(ColumnName = "twist_wire_count", ColumnDataType = "REAL", IsNullable = true)]
        public double TwistWireCount
        {
            get => _twistWireCount;
            set => SetProperty(ref _twistWireCount, value);
        }

        /// <summary>
        /// 修正系数
        /// </summary>
        private double _correctionFactor;
        [SugarColumn(ColumnName = "correction_factor", ColumnDataType = "REAL", IsNullable = true)]
        public double CorrectionFactor
        {
            get => _correctionFactor;
            set => SetProperty(ref _correctionFactor, value);
        }

        /// <summary>
        /// 节距补偿
        /// </summary>
        private double _pitchCompensation;
        [SugarColumn(ColumnName = "pitch_compensation", ColumnDataType = "REAL", IsNullable = true)]
        public double PitchCompensation
        {
            get => _pitchCompensation;
            set => SetProperty(ref _pitchCompensation, value);
        }

        /// <summary>
        /// 绞合方向
        /// </summary>
        private int _twistDirection;
        [SugarColumn(ColumnName = "twist_direction", ColumnDataType = "INTEGER", IsNullable = true)]
        public int TwistDirection
        {
            get => _twistDirection;
            set => SetProperty(ref _twistDirection, value);
        }

        /// <summary>
        /// 设定生产数量
        /// </summary>
        private double _setProductionQuantity;
        [SugarColumn(ColumnName = "set_production_quantity", ColumnDataType = "REAL", IsNullable = true)]
        public double SetProductionQuantity
        {
            get => _setProductionQuantity;
            set => SetProperty(ref _setProductionQuantity, value);
        }
    }
}
