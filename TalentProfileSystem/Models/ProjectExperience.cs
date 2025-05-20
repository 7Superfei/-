using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentProfileSystem.Models
{
    /// <summary>
    /// 项目经验实体类，对应数据库中的项目经验表
    /// 记录员工参与的项目信息和在项目中的角色
    /// </summary>
    [Table("project_experiences")]
    public class ProjectExperience
    {
        /// <summary>
        /// 经验记录ID，主键
        /// </summary>
        [Key]
        [Column("experience_id")]
        public int ExperienceId { get; set; }

        /// <summary>
        /// 关联的员工ID，外键
        /// </summary>
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 项目级别，如关键项目、普通项目等
        /// </summary>
        [Column("project_level")]
        public string ProjectLevel { get; set; } = string.Empty;

        /// <summary>
        /// 项目中担任的角色，如项目经理、开发人员等
        /// </summary>
        [Column("project_role")]
        public string ProjectRole { get; set; } = string.Empty;

        /// <summary>
        /// 关联的员工对象（导航属性）
        /// </summary>
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
} 