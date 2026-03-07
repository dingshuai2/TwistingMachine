using SqlSugar;
using Prism.Mvvm;

namespace TwistingMachine.Entities.Data
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    public class BaseEntity : BindableBase
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
        /// 创建时间
        /// </summary>
        private DateTime _createTime;
        [SugarColumn(ColumnName = "create_time", ColumnDataType = "DATETIME", IsNullable = true, DefaultValue = "CURRENT_TIMESTAMP")]
        public DateTime CreateTime
        {
            get => _createTime;
            set => SetProperty(ref _createTime, value);
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        private DateTime _updateTime;
        [SugarColumn(ColumnName = "update_time", ColumnDataType = "DATETIME", IsNullable = true, DefaultValue = "CURRENT_TIMESTAMP")]
        public DateTime UpdateTime
        {
            get => _updateTime;
            set => SetProperty(ref _updateTime, value);
        }
    }
}