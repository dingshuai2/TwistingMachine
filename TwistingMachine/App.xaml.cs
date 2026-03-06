using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Serilog;
using Serilog.Events;
using TwistingMachine.Views;

namespace TwistingMachine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            // 初始化 Serilog
            var logDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // 设置最低日志级别
                .WriteTo.File(
                    Path.Combine(logDir, "log.txt"),
                    rollingInterval: RollingInterval.Day, // 按天滚动
                    retainedFileCountLimit: 10, // 保留10天的日志
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}") // 日志格式
                .CreateLogger();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册服务
            containerRegistry.RegisterSingleton<CommHelpers.ModbusTcpClientHelper>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // 配置模块目录
        }
    }

}
