using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentProfileSystem.Models
{
    /// <summary>
    /// 员工实体类，对应数据库中的employees表
    /// 包含员工的基本信息、工作信息和绩效信息
    /// </summary>
    [Table("employees")]
    public class Employee
    {
        /// <summary>
        /// 员工ID，主键
        /// </summary>
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 性别
        /// </summary>
        [Column("gender")]
        public string Gender { get; set; } = string.Empty;

        /// <summary>
        /// 联系电话
        /// </summary>
        [Column("phone")]
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// 年龄
        /// </summary>
        [Column("age")]
        public int Age { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        [Column("birthplace")]
        public string Birthplace { get; set; } = string.Empty;

        /// <summary>
        /// 学历水平（如：高中、专科、本科、硕士、博士）
        /// </summary>
        [Column("academic_level")]
        public string AcademicLevel { get; set; } = string.Empty;

        /// <summary>
        /// 教育背景描述
        /// </summary>
        [Column("education")]
        public string Education { get; set; } = string.Empty;

        /// <summary>
        /// 专业大类
        /// </summary>
        [Column("major_category")]
        public string MajorCategory { get; set; } = string.Empty;

        /// <summary>
        /// 具体专业
        /// </summary>
        [Column("specific_major")]
        public string SpecificMajor { get; set; } = string.Empty;

        /// <summary>
        /// 第二专业大类（可为空）
        /// </summary>
        [Column("second_major_category")]
        public string? SecondMajorCategory { get; set; }

        /// <summary>
        /// 第二具体专业（可为空）
        /// </summary>
        [Column("second_specific_major")]
        public string? SecondSpecificMajor { get; set; }

        /// <summary>
        /// 所在公司类型
        /// </summary>
        [Column("company_type")]
        public string CompanyType { get; set; } = string.Empty;

        /// <summary>
        /// 工作年限
        /// </summary>
        [Column("work_years")]
        public int WorkYears { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        [Column("department")]
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// 参与项目数量
        /// </summary>
        [Column("project_count")]
        public int ProjectCount { get; set; } = 0;

        /// <summary>
        /// 第一个月的绩效评级
        /// </summary>
        [Column("performance_month1")]
        public string PerformanceMonth1 { get; set; } = string.Empty;

        /// <summary>
        /// 第二个月的绩效评级
        /// </summary>
        [Column("performance_month2")]
        public string PerformanceMonth2 { get; set; } = string.Empty;

        /// <summary>
        /// 第三个月的绩效评级
        /// </summary>
        [Column("performance_month3")]
        public string PerformanceMonth3 { get; set; } = string.Empty;

        /// <summary>
        /// 性格类型（如：MBTI类型）
        /// </summary>
        [Column("personality_type")]
        public string PersonalityType { get; set; } = string.Empty;

        /// <summary>
        /// 职位级别（如：基层、中层、高层）
        /// </summary>
        [Column("position_level")]
        public string PositionLevel { get; set; } = string.Empty;

        /// <summary>
        /// 婚姻状况
        /// </summary>
        [Column("marital_status")]
        public string MaritalStatus { get; set; } = string.Empty;

        /// <summary>
        /// 房贷压力
        /// </summary>
        [Column("mortgage_pressure")]
        public string MortgagePressure { get; set; } = string.Empty;

        /// <summary>
        /// 工作环境满意度
        /// </summary>
        [Column("work_environment_satisfaction")]
        public string WorkEnvironmentSatisfaction { get; set; } = string.Empty;

        /// <summary>
        /// 薪资满意度
        /// </summary>
        [Column("salary_satisfaction")]
        public string SalarySatisfaction { get; set; } = string.Empty;

        /// <summary>
        /// 考勤记录集合（导航属性）
        /// </summary>
        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
        
        /// <summary>
        /// 职位变更记录集合（导航属性）
        /// </summary>
        public virtual ICollection<PositionChange> PositionChanges { get; set; } = new List<PositionChange>();
        
        /// <summary>
        /// 项目经验记录集合（导航属性）
        /// </summary>
        public virtual ICollection<ProjectExperience> ProjectExperiences { get; set; } = new List<ProjectExperience>();
    }
} 