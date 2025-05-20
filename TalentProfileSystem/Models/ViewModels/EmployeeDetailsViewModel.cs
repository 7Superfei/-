using TalentProfileSystem.Models;

namespace TalentProfileSystem.Models.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        // 员工基本模型
        public Employee Employee { get; set; } = null!;
        
        // 员工画像信息
        public EmployeeProfileViewModel Profile { get; set; } = null!;
    }
} 