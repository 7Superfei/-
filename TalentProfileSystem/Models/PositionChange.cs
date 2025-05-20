using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentProfileSystem.Models
{
    /// <summary>
    /// 职位变更实体类，对应数据库中的职位变更记录表
    /// 记录员工的晋升、调岗、降职等职位变动情况
    /// </summary>
    [Table("position_changes")]
    public class PositionChange
    {
        /// <summary>
        /// 变更记录ID，主键
        /// </summary>
        [Key]
        [Column("change_id")]
        public int ChangeId { get; set; }

        /// <summary>
        /// 关联的员工ID，外键
        /// </summary>
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 变更日期
        /// </summary>
        [Column("change_date")]
        public DateTime ChangeDate { get; set; }

        /// <summary>
        /// 职位变更描述，如晋升、调岗等具体变动内容
        /// </summary>
        [Column("position_change")]
        public string PositionChangeDescription { get; set; } = string.Empty;

        /// <summary>
        /// 关联的员工对象（导航属性）
        /// </summary>
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
} 