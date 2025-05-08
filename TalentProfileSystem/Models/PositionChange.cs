using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentProfileSystem.Models
{
    [Table("position_changes")]
    public class PositionChange
    {
        [Key]
        [Column("change_id")]
        public int ChangeId { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("change_date")]
        public DateTime ChangeDate { get; set; }

        [Column("position_change")]
        public string PositionChangeDescription { get; set; } = string.Empty;

        // 导航属性
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
} 