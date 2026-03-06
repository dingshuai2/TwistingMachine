using SqlSugar;
using TwistingMachine.Entities;

namespace TwistingMachine.DbHelpers
{
    /// <summary>
    /// 数据库上下文类
    /// 负责管理数据库连接和初始化数据库结构
    /// </summary>
    public static class DbContext
    {
        /// <summary>
        /// SqlSugar客户端实例
        /// </summary>
        private static SqlSugarClient? _db;

        /// <summary>
        /// 获取数据库客户端实例
        /// 如果实例为null，会自动初始化
        /// </summary>
        public static SqlSugarClient Db
        {
            get
            {
                if (_db == null)
                {
                    InitDb();
                }
                return _db!;
            }
        }

        /// <summary>
        /// 初始化数据库
        /// 1. 创建SqlSugarClient实例
        /// 2. 创建数据库文件（如果不存在）
        /// 3. 初始化表结构
        /// </summary>
        public static void InitDb()
        {
            // 创建SqlSugarClient实例并配置连接信息
            _db = new SqlSugarClient(new ConnectionConfig()
            {
                // 连接字符串：SQLite数据库文件路径
                // AppDomain.CurrentDomain.BaseDirectory 表示应用程序的根目录
                ConnectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}TwistingMachine.db",
                // 数据库类型：SQLite
                DbType = DbType.Sqlite,
                // 是否自动关闭连接
                IsAutoCloseConnection = true,
                // 主键初始化方式：通过特性
                InitKeyType = InitKeyType.Attribute
            });

            // 创建数据库文件（如果不存在）
            _db.DbMaintenance.CreateDatabase();

            // 使用CodeFirst模式，根据ProductParameters实体类自动创建表结构
            _db.CodeFirst.InitTables<ProductParameters>();
        }
    }
}
