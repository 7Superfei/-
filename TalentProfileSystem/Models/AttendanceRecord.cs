using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentProfileSystem.Models
{
    [Table("attendance_records")]
    public class AttendanceRecord
    {
        [Key]
        [Column("record_id")]
        public int RecordId { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("status")]
        public string Status { get; set; } = string.Empty;

        // 导航属性
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
} 