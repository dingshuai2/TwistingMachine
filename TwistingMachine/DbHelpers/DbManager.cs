using System;
using System.Collections.Generic;
using System.Linq;
using TwistingMachine.Entities;
using Serilog;

namespace TwistingMachine.DbHelpers
{
    /// <summary>
    /// 数据库操作管理类
    /// </summary>
    public class DbManager
    {
        #region 单例模式

        private static DbManager _instance;
        private static readonly object _lock = new object();

        private DbManager() { }

        /// <summary>
        /// 单例实例
        /// </summary>
        public static DbManager Inst
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DbManager();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region 数据库操作方法

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="whereExpression">查询条件</param>
        /// <returns>数据列表</returns>
        public List<T> QueryDatas<T>(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null) where T : class, new()
        {
            try
            {
                var db = DbContext.Db;
                if (whereExpression != null)
                {
                    return db.Queryable<T>().Where(whereExpression).ToList();
                }
                else
                {
                    return db.Queryable<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error($"DbManager:查询数据失败：{ex.Message}");
                return new List<T>();
            }
        }

        /// <summary>
        /// 查询单个数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="whereExpression">查询条件</param>
        /// <returns>单个数据</returns>
        public T QueryData<T>(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression = null) where T : class, new()
        {
            try
            {
                var db = DbContext.Db;
                if (whereExpression != null)
                {
                    return db.Queryable<T>().Where(whereExpression).First();
                }
                else
                {
                    return db.Queryable<T>().First();
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error($"DbManager:查询单个数据失败：{ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体对象</param>
        /// <returns>是否成功</returns>
        public bool InsertData<T>(T entity) where T : class, new()
        {
            try
            {
                var db = DbContext.Db;
                return db.Insertable(entity).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error($"DbManager:插入数据失败：{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体对象</param>
        /// <returns>是否成功</returns>
        public bool UpdateData<T>(T entity) where T : class, new()
        {
            try
            {
                var db = DbContext.Db;
                return db.Updateable(entity).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error($"DbManager:更新数据失败：{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="whereExpression">删除条件</param>
        /// <returns>是否成功</returns>
        public bool DeleteData<T>(System.Linq.Expressions.Expression<Func<T, bool>> whereExpression) where T : class, new()
        {
            try
            {
                var db = DbContext.Db;
                return db.Deleteable<T>().Where(whereExpression).ExecuteCommand() > 0;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error($"DbManager:删除数据失败：{ex.Message}");
                return false;
            }
        }

        #endregion
    }
}