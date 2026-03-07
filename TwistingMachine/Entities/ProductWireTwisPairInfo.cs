using System.Windows.Media;

namespace TwistingMachine.Entities
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
}