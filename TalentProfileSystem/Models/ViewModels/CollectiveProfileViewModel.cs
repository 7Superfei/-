namespace TalentProfileSystem.Models.ViewModels
{
    public class CollectiveProfileViewModel
    {
        // 部门分布数据
        public List<DepartmentDistribution> DepartmentDistribution { get; set; } = new List<DepartmentDistribution>();
        
        // 年龄分布数据
        public List<AgeDistribution> AgeDistribution { get; set; } = new List<AgeDistribution>();
        
        // 司龄分布数据
        public List<CompanyAgeDistribution> CompanyAgeDistribution { get; set; } = new List<CompanyAgeDistribution>();
        
        // 学历分布数据
        public List<EducationDistribution> EducationDistribution { get; set; } = new List<EducationDistribution>();
        
        // 职级/层级分布数据
        public List<PositionLevelDistribution> PositionLevelDistribution { get; set; } = new List<PositionLevelDistribution>();
        
        // 性别分布数据
        public GenderDistribution GenderDistribution { get; set; } = new GenderDistribution();
        
        // 人才结构分析
        public List<TalentStructureAnalysis> TalentStructureAnalysis { get; set; } = new List<TalentStructureAnalysis>();
        
        // 人才稀缺部门和人才冗余部门
        public List<DepartmentTalentStatus> TalentShortages { get; set; } = new List<DepartmentTalentStatus>(); // 人才稀缺部门
        public List<DepartmentTalentStatus> TalentSurpluses { get; set; } = new List<DepartmentTalentStatus>(); // 人才冗余部门
        
        // 突出员工列表
        public List<OutstandingEmployeeViewModel> StarEmployees { get; set; } = new List<OutstandingEmployeeViewModel>(); // 明星员工
        public List<OutstandingEmployeeViewModel> PotentialEmployees { get; set; } = new List<OutstandingEmployeeViewModel>(); // 潜力股
        public List<OutstandingEmployeeViewModel> HighPerformanceEmployees { get; set; } = new List<OutstandingEmployeeViewModel>(); // 绩效优秀
        public List<OutstandingEmployeeViewModel> TransferRecommendations { get; set; } = new List<OutstandingEmployeeViewModel>(); // 调职推荐
        public List<OutstandingEmployeeViewModel> UnderperformingEmployees { get; set; } = new List<OutstandingEmployeeViewModel>(); // 表现欠佳
        public List<OutstandingEmployeeViewModel> AttritionRiskEmployees { get; set; } = new List<OutstandingEmployeeViewModel>(); // 离职风险
        public List<OutstandingEmployeeViewModel> PromotionRecommendations { get; set; } = new List<OutstandingEmployeeViewModel>(); // 晋升推荐
    }

    public class DepartmentDistribution
    {
        public string Department { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Percentage { get; set; }
    }

    public class AgeDistribution
    {
        public string AgeRange { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Percentage { get; set; }
    }

    public class CompanyAgeDistribution
    {
        public string CompanyAgeRange { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Percentage { get; set; }
    }

    public class EducationDistribution
    {
        public string Education { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Percentage { get; set; }
    }

    public class PositionLevelDistribution
    {
        public string Level { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Percentage { get; set; }
    }

    public class GenderDistribution
    {
        public int MaleCount { get; set; }
        public int FemaleCount { get; set; }
        public double MalePercentage { get; set; }
        public double FemalePercentage { get; set; }
    }

    public class TalentStructureAnalysis
    {
        public string Position { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // 过剩/不足/适中
        public int CurrentCount { get; set; }
        public int IdealCount { get; set; }
        public double Difference { get; set; }
    }

    public class OutstandingEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string PositionLevel { get; set; } = string.Empty;
        public double Score { get; set; } // 相关分数，不同类型的分数含义不同
    }

    public class DepartmentTalentStatus
    {
        public string Department { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // 较稀缺/稀缺/极度稀缺 或 较冗余/冗余/极度冗余
        public double CurrentPercentage { get; set; } // 当前占比
        public double MinIdealPercentage { get; set; } // 理想占比下限
        public double MaxIdealPercentage { get; set; } // 理想占比上限
        public double Deviation { get; set; } // 偏差百分比
    }
} 