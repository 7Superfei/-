using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentProfileSystem.Models
{
    /// <summary>
    /// 考勤记录实体类，对应数据库中的考勤记录表
    /// 记录员工的出勤、迟到、早退、请假等情况
    /// </summary>
    [Table("attendance_records")]
    public class AttendanceRecord
    {
        /// <summary>
        /// 记录ID，主键
        /// </summary>
        [Key]
        [Column("record_id")]
        public int RecordId { get; set; }

        /// <summary>
        /// 关联的员工ID，外键
        /// </summary>
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 记录日期
        /// </summary>
        [Column("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 考勤状态（如：正常、迟到、早退、缺勤、请假等）
        /// </summary>
        [Column("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// 关联的员工对象（导航属性）
        /// </summary>
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
} 