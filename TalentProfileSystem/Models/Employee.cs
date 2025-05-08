using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentProfileSystem.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("gender")]
        public string Gender { get; set; } = string.Empty;

        [Column("phone")]
        public string Phone { get; set; } = string.Empty;

        [Column("age")]
        public int Age { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Column("birthplace")]
        public string Birthplace { get; set; } = string.Empty;

        [Column("academic_level")]
        public string AcademicLevel { get; set; } = string.Empty;

        [Column("education")]
        public string Education { get; set; } = string.Empty;

        [Column("major_category")]
        public string MajorCategory { get; set; } = string.Empty;

        [Column("specific_major")]
        public string SpecificMajor { get; set; } = string.Empty;

        [Column("second_major_category")]
        public string? SecondMajorCategory { get; set; }

        [Column("second_specific_major")]
        public string? SecondSpecificMajor { get; set; }

        [Column("company_type")]
        public string CompanyType { get; set; } = string.Empty;

        [Column("work_years")]
        public int WorkYears { get; set; }

        [Column("department")]
        public string Department { get; set; } = string.Empty;

        [Column("project_level")]
        public string ProjectLevel { get; set; } = string.Empty;

        [Column("project_role")]
        public string ProjectRole { get; set; } = string.Empty;

        [Column("performance_month1")]
        public string PerformanceMonth1 { get; set; } = string.Empty;

        [Column("performance_month2")]
        public string PerformanceMonth2 { get; set; } = string.Empty;

        [Column("performance_month3")]
        public string PerformanceMonth3 { get; set; } = string.Empty;

        [Column("personality_type")]
        public string PersonalityType { get; set; } = string.Empty;

        [Column("position_level")]
        public string PositionLevel { get; set; } = string.Empty;

        [Column("marital_status")]
        public string MaritalStatus { get; set; } = string.Empty;

        [Column("mortgage_pressure")]
        public string MortgagePressure { get; set; } = string.Empty;

        [Column("work_environment_satisfaction")]
        public string WorkEnvironmentSatisfaction { get; set; } = string.Empty;

        [Column("salary_satisfaction")]
        public string SalarySatisfaction { get; set; } = string.Empty;

        // 导航属性
        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
        public virtual ICollection<PositionChange> PositionChanges { get; set; } = new List<PositionChange>();
    }
} 