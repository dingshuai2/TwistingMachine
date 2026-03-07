using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using MahApps.Metro.IconPacks;
using TwistingMachine.Entities;
using TwistingMachine.DbHelpers;
using System.Collections.Generic;
using Serilog;
using System.Windows.Media;
using System.Windows;
using System.Text;

namespace TwistingMachine.ViewModels
{
    /// <summary>
    /// 绞线参数类
    /// </summary>
    public class ProductWireTwisPairInfo
    {
        /// <summary>
        /// 显示线径
        /// </summary>
        public double ShowWireDiam { get; set; }

        /// <summary>
        /// 线颜色(左右两端的线的颜色)
        /// </summary>
        public Color ColorStroke { get; set; }

        /// <summary>
        /// 线颜色1
        /// </summary>
        public Color ColorStroke1 { get; set; }

        /// <summary>
        /// 线颜色2
        /// </summary>
        public Color ColorStroke2 { get; set; }
    }

    public class ProductionViewModel : BindableBase
    {
        public ProductionViewModel()
        {
            LoosenJawsCommand = new DelegateCommand(LoosenJaws);
            ResetCommand = new DelegateCommand(Reset);
            ApplyTapeCommand = new DelegateCommand(ApplyTape);
            SaveParametersCommand = new DelegateCommand(SaveParameters);

            LoadParametersFromDatabase();
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        private void LoadParametersFromDatabase()
        {
            try
            {
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

                var param = DbManager.Inst.QueryDatas<ProductParameters>().Where(p => p.RecipeName == "AAA").First();

                if (param != null)
                {
                    ProductParameters = param;
                }

                // 初始化线缆绘制
                var wire1 = new ProductWireTwisPairInfo
                {
                    ShowWireDiam = 10,
                    ColorStroke = Colors.Blue,
                    ColorStroke1 = Colors.Blue,
                    ColorStroke2 = Colors.Blue
                };

                var wire2 = new ProductWireTwisPairInfo
                {
                    ShowWireDiam = 10,
                    ColorStroke = Colors.Green,
                    ColorStroke1 = Colors.Green,
                    ColorStroke2 = Colors.Green
                };

                DrawTwistedPair(wire1, wire2);
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

        #region 画线
        /// <summary>
        /// 画双绞线缆
        /// </summary>
        /// <param name="wireParam1">线1参数</param>
        /// <param name="wireParam2">线2参数</param>
        private void DrawTwistedPair(ProductWireTwisPairInfo wireParam1, ProductWireTwisPairInfo wireParam2)
        {
            try
            {
                //清空画线
                LeftLineList.Clear();
                LineList.Clear();
                RightLineList.Clear();

                double leftStartX = 0; //左侧起始X位置
                double threadResidueW = 80; //线头宽度（直线）
                double threadResidueW2 = 80; //线头宽度（曲线）
                double threadResidueH = 40; //线头高度（曲线）
                double lineLen = 480; //线长
                double y1 = 5; //上起始位置1
                double y2 = Math.Max(wireParam1.ShowWireDiam, wireParam2.ShowWireDiam) + 10; //上起始位置2
                double line1ShowDiam = wireParam1.ColorStroke != Colors.White ? wireParam1.ShowWireDiam : wireParam1.ShowWireDiam + 2;
                double line2ShowDiam = wireParam2.ColorStroke != Colors.White ? wireParam2.ShowWireDiam : wireParam2.ShowWireDiam + 2;
                double firstLineLen = threadResidueW + threadResidueW2 + lineLen; //线左侧+线长

                #region 线头（直线）
                //线1左侧直线（中线以上）
                if (wireParam1.ColorStroke == Colors.White) //白线追加显示黑边
                {
                    System.Windows.Shapes.Path line1LMainPathB = PaintLine(new List<Point> { new Point(leftStartX, y1), new Point(leftStartX + threadResidueW, y1) }, new SolidColorBrush(Colors.Black), line1ShowDiam + 2);
                    LeftLineList.Add(line1LMainPathB);
                }
                System.Windows.Shapes.Path line1LMainPath = PaintLine(new List<Point> { new Point(leftStartX, y1), new Point(leftStartX + threadResidueW, y1) }, new SolidColorBrush(wireParam2.ColorStroke), line1ShowDiam);
                LeftLineList.Add(line1LMainPath);
                System.Windows.Shapes.Path line1LSubPath = PaintLine(new List<Point> { new Point(leftStartX, y1), new Point(leftStartX + threadResidueW, y1) }, new SolidColorBrush(wireParam2.ColorStroke), line1ShowDiam);
                LeftLineList.Add(line1LSubPath);
                //线1右侧直线（中线以下）
                if (wireParam1.ColorStroke == Colors.White) //白线追加显示黑边
                {
                    System.Windows.Shapes.Path line1RMainPathB = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y2 + threadResidueH * 2), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW * 2, y2 + threadResidueH * 2) }, new SolidColorBrush(Colors.Black), line1ShowDiam + 2);
                    RightLineList.Add(line1RMainPathB);
                }
                System.Windows.Shapes.Path line1RMainPath = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y2 + threadResidueH * 2), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW * 2, y2 + threadResidueH * 2) }, new SolidColorBrush(wireParam1.ColorStroke), line1ShowDiam);
                RightLineList.Add(line1RMainPath);
                System.Windows.Shapes.Path line1RSubPath = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y2 + threadResidueH * 2), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW * 2, y2 + threadResidueH * 2) }, new SolidColorBrush(wireParam1.ColorStroke), line1ShowDiam);
                RightLineList.Add(line1RSubPath);
                //线2左侧直线（中线以下）
                if (wireParam2.ColorStroke == Colors.White) //白线追加显示黑边
                {
                    System.Windows.Shapes.Path line2LMainPathB = PaintLine(new List<Point> { new Point(leftStartX, y2 + threadResidueH * 2), new Point(leftStartX + threadResidueW, y2 + threadResidueH * 2) }, new SolidColorBrush(Colors.Black), line2ShowDiam + 2);
                    LeftLineList.Add(line2LMainPathB);
                }
                System.Windows.Shapes.Path line2LMainPath = PaintLine(new List<Point> { new Point(leftStartX, y2 + threadResidueH * 2), new Point(leftStartX + threadResidueW, y2 + threadResidueH * 2) }, new SolidColorBrush(wireParam1.ColorStroke), line2ShowDiam);
                LeftLineList.Add(line2LMainPath);
                System.Windows.Shapes.Path line2LSubPath = PaintLine(new List<Point> { new Point(leftStartX, y2 + threadResidueH * 2), new Point(leftStartX + threadResidueW, y2 + threadResidueH * 2) }, new SolidColorBrush(wireParam1.ColorStroke), line2ShowDiam);
                LeftLineList.Add(line2LSubPath);
                //线2右侧直线（中线以上）
                if (wireParam2.ColorStroke == Colors.White) //白线追加显示黑边
                {
                    System.Windows.Shapes.Path line2RMainPathB = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y1), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW * 2, y1) }, new SolidColorBrush(Colors.Black), line2ShowDiam + 2);
                    RightLineList.Add(line2RMainPathB);
                }
                System.Windows.Shapes.Path line2RMainPath = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y1), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW * 2, y1) }, new SolidColorBrush(wireParam2.ColorStroke), line2ShowDiam);
                RightLineList.Add(line2RMainPath);
                System.Windows.Shapes.Path line2RSubPath = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y1), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW * 2, y1) }, new SolidColorBrush(wireParam2.ColorStroke), line2ShowDiam);
                RightLineList.Add(line2RSubPath);
                #endregion

                #region 线头（曲线）
                //线2左侧曲线（中线以上，由上向下）
                if (wireParam2.ColorStroke == Colors.White) //白线追加显示黑边
                {
                    System.Windows.Shapes.Path line2LMainPath2B = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW, y1), new Point(leftStartX + threadResidueW + threadResidueW2, y1 + 40) }, new SolidColorBrush(Colors.Black), line2ShowDiam + 2);
                    LeftLineList.Add(line2LMainPath2B);
                }
                System.Windows.Shapes.Path line2LMainPath2 = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW, y1), new Point(leftStartX + threadResidueW + threadResidueW2, y1 + 40) }, new SolidColorBrush(wireParam2.ColorStroke), line2ShowDiam);
                LeftLineList.Add(line2LMainPath2);
                System.Windows.Shapes.Path line2LSubPath2 = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW, y1), new Point(leftStartX + threadResidueW + threadResidueW2, y1 + 40) }, new SolidColorBrush(wireParam2.ColorStroke), line2ShowDiam);
                LeftLineList.Add(line2LSubPath2);
                //线1左侧曲线（中线以下，由下向上）
                if (wireParam1.ColorStroke == Colors.White) //白线追加显示黑边
                {
                    System.Windows.Shapes.Path line1LMainPath2B = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW, y2 + threadResidueH * 2), new Point(leftStartX + threadResidueW + threadResidueW2, y2 + 40) }, new SolidColorBrush(Colors.Black), line1ShowDiam + 2);
                    LeftLineList.Add(line1LMainPath2B);
                }
                System.Windows.Shapes.Path line1LMainPath2 = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW, y2 + threadResidueH * 2), new Point(leftStartX + threadResidueW + threadResidueW2, y2 + 40) }, new SolidColorBrush(wireParam1.ColorStroke), line1ShowDiam);
                LeftLineList.Add(line1LMainPath2);
                System.Windows.Shapes.Path line1LSubPath2 = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW, y2 + threadResidueH * 2), new Point(leftStartX + threadResidueW + threadResidueW2, y2 + 40) }, new SolidColorBrush(wireParam1.ColorStroke), line1ShowDiam);
                LeftLineList.Add(line1LSubPath2);
                //线2右侧曲线（中线以上，由下向上）
                if (wireParam2.ColorStroke == Colors.White) //白线追加显示黑边
                {
                    System.Windows.Shapes.Path line2RMainPath2B = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen, y1 + 40), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y1) }, new SolidColorBrush(Colors.Black), line2ShowDiam + 2);
                    RightLineList.Add(line2RMainPath2B);
                }
                System.Windows.Shapes.Path line2RMainPath2 = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen, y1 + 40), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y1) }, new SolidColorBrush(wireParam2.ColorStroke), line2ShowDiam);
                RightLineList.Add(line2RMainPath2);
                System.Windows.Shapes.Path line2RSubPath2 = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen, y1 + 40), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y1) }, new SolidColorBrush(wireParam2.ColorStroke), line2ShowDiam);
                RightLineList.Add(line2RSubPath2);
                //线1右侧曲线（中线以下，由上向下）
                if (wireParam1.ColorStroke == Colors.White) //白线追加显示黑边
                {
                    System.Windows.Shapes.Path line1RMainPath2B = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen, y2 + 40), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y2 + threadResidueH * 2) }, new SolidColorBrush(Colors.Black), line1ShowDiam + 2);
                    RightLineList.Add(line1RMainPath2B);
                }
                System.Windows.Shapes.Path line1RMainPath2 = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen, y2 + 40), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y2 + threadResidueH * 2) }, new SolidColorBrush(wireParam1.ColorStroke), line1ShowDiam);
                RightLineList.Add(line1RMainPath2);
                System.Windows.Shapes.Path line1RSubPath2 = PaintLine(new List<Point> { new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen, y2 + 40), new Point(leftStartX + threadResidueW + threadResidueW2 + lineLen + threadResidueW, y2 + threadResidueH * 2) }, new SolidColorBrush(wireParam1.ColorStroke), line1ShowDiam);
                RightLineList.Add(line1RSubPath2);
                #endregion

                #region 线长
                double startX = leftStartX + threadResidueW + threadResidueW2; //双绞样式线长起始位
                y1 += 40; //上起始位置1
                y2 += 40; //上起始位置2
                for (int i = 0; i < 6; i++)
                {
                    if (i % 2 == 0)
                    {
                        //线2曲线前半部分
                        if (wireParam2.ColorStroke2 == Colors.White) //白线追加显示黑边
                        {
                            System.Windows.Shapes.Path line2MainPath1B = PaintLine(new List<Point> { new Point(startX + i * 80, y1), new Point(startX + (i + 1) * 80, y2) }, new SolidColorBrush(Colors.Black), line2ShowDiam + 2);
                            LineList.Add(line2MainPath1B);
                        }
                        System.Windows.Shapes.Path line2MainPath1 = PaintLine(new List<Point> { new Point(startX + i * 80, y1), new Point(startX + (i + 1) * 80, y2) }, new SolidColorBrush(wireParam2.ColorStroke2), line2ShowDiam);
                        LineList.Add(line2MainPath1);
                        System.Windows.Shapes.Path line2SubPath1 = PaintLine(new List<Point> { new Point(startX + i * 80, y1), new Point(startX + (i + 1) * 80, y2) }, new SolidColorBrush(wireParam2.ColorStroke2), line2ShowDiam);
                        LineList.Add(line2SubPath1);
                        //线1曲线后半部分
                        if (wireParam1.ColorStroke1 == Colors.White) //白线追加显示黑边
                        {
                            System.Windows.Shapes.Path line1MainPath1B = PaintLine(new List<Point> { new Point(startX + i * 80, y2), new Point(startX + (i + 1) * 80, y1) }, new SolidColorBrush(Colors.Black), line1ShowDiam + 2);
                            LineList.Add(line1MainPath1B);
                        }
                        System.Windows.Shapes.Path line1MainPath1 = PaintLine(new List<Point> { new Point(startX + i * 80, y2), new Point(startX + (i + 1) * 80, y1) }, new SolidColorBrush(wireParam1.ColorStroke1), line1ShowDiam);
                        LineList.Add(line1MainPath1);
                        System.Windows.Shapes.Path line1SubPath1 = PaintLine(new List<Point> { new Point(startX + i * 80, y2), new Point(startX + (i + 1) * 80, y1) }, new SolidColorBrush(wireParam1.ColorStroke1), line1ShowDiam);
                        LineList.Add(line1SubPath1);
                        //线1曲线前半部分
                        if (wireParam1.ColorStroke1 == Colors.White) //白线追加显示黑边
                        {
                            System.Windows.Shapes.Path line1MainPath2B = PaintLine(new List<Point> { new Point(startX + (i + 1) * 80, y1), new Point(startX + (i + 2) * 80, y2) }, new SolidColorBrush(Colors.Black), line1ShowDiam + 2);
                            LineList.Add(line1MainPath2B);
                        }
                        System.Windows.Shapes.Path line1MainPath2 = PaintLine(new List<Point> { new Point(startX + (i + 1) * 80, y1), new Point(startX + (i + 2) * 80, y2) }, new SolidColorBrush(wireParam1.ColorStroke1), line1ShowDiam);
                        LineList.Add(line1MainPath2);
                        System.Windows.Shapes.Path line1SubPath2 = PaintLine(new List<Point> { new Point(startX + (i + 1) * 80, y1), new Point(startX + (i + 2) * 80, y2) }, new SolidColorBrush(wireParam1.ColorStroke1), line1ShowDiam);
                        LineList.Add(line1SubPath2);
                        //线2曲线后半部分
                        if (wireParam2.ColorStroke2 == Colors.White) //白线追加显示黑边
                        {
                            System.Windows.Shapes.Path line2MainPath2B = PaintLine(new List<Point> { new Point(startX + (i + 1) * 80, y2), new Point(startX + (i + 2) * 80, y1) }, new SolidColorBrush(Colors.Black), line2ShowDiam + 2);
                            LineList.Add(line2MainPath2B);
                        }
                        System.Windows.Shapes.Path line2MainPath2 = PaintLine(new List<Point> { new Point(startX + (i + 1) * 80, y2), new Point(startX + (i + 2) * 80, y1) }, new SolidColorBrush(wireParam2.ColorStroke2), line2ShowDiam);
                        LineList.Add(line2MainPath2);
                        System.Windows.Shapes.Path line2SubPath2 = PaintLine(new List<Point> { new Point(startX + (i + 1) * 80, y2), new Point(startX + (i + 2) * 80, y1) }, new SolidColorBrush(wireParam2.ColorStroke2), line2ShowDiam);
                        LineList.Add(line2SubPath2);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("绘制双绞线缆出错: {0}", ex.Message);
            }
        }

        /// <summary>
        /// 绘制贝塞尔曲线
        /// </summary>
        /// <param name="points">点集合</param>
        /// <param name="brush">线颜色</param>
        /// <param name="thickness">线粗</param>
        /// <returns></returns>
        private System.Windows.Shapes.Path PaintLine(List<Point> points, Brush brush, double thickness = 8)
        {
            try
            {
                if (points.Count < 2)
                    return null;

                StringBuilder data = new StringBuilder("M");
                data.AppendFormat(" {0},{1}", points[0].X, points[0].Y);

                for (int i = 1; i < points.Count; i++)
                {
                    double midX = (points[i - 1].X + points[i].X) / 2;
                    Point control1 = new Point(midX, points[i - 1].Y);
                    Point control2 = new Point(midX, points[i].Y);
                    data.AppendFormat(" C {0},{1} {2},{3} {4},{5}", control1.X, control1.Y, control2.X, control2.Y, points[i].X, points[i].Y);
                }

                return new System.Windows.Shapes.Path { Stroke = brush, StrokeThickness = thickness, Data = Geometry.Parse(data.ToString()) };
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("绘制贝塞尔曲线出错: {0}", ex.Message);
                return null;
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

        private List<System.Windows.Shapes.Path> _leftLineList = new List<System.Windows.Shapes.Path>();
        /// <summary>
        /// 左侧线段列表
        /// </summary>
        public List<System.Windows.Shapes.Path> LeftLineList
        {
            get { return _leftLineList; }
            set { SetProperty(ref _leftLineList, value); }
        }

        private List<System.Windows.Shapes.Path> _lineList = new List<System.Windows.Shapes.Path>();
        /// <summary>
        /// 中间绞合线段列表
        /// </summary>
        public List<System.Windows.Shapes.Path> LineList
        {
            get { return _lineList; }
            set { SetProperty(ref _lineList, value); }
        }

        private List<System.Windows.Shapes.Path> _rightLineList = new List<System.Windows.Shapes.Path>();
        /// <summary>
        /// 右侧线段列表
        /// </summary>
        public List<System.Windows.Shapes.Path> RightLineList
        {
            get { return _rightLineList; }
            set { SetProperty(ref _rightLineList, value); }
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
