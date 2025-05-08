namespace TalentProfileSystem.Models.ViewModels
{
    public class EmployeeProfileViewModel
    {
        // 基本信息
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string WorkId { get; set; } = string.Empty; // 工号，暂时用EmployeeId代替
        public string Gender { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string PositionLevel { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Birthplace { get; set; } = string.Empty;
        
        // 标签数据
        public List<TagViewModel> Tags { get; set; } = new List<TagViewModel>();
        
        // 综合能力评分和雷达图数据
        public double OverallScore { get; set; }
        public RadarChartViewModel RadarChartData { get; set; } = new RadarChartViewModel();
        
        // 绩效数据
        public List<PerformanceDataPoint> PerformanceData { get; set; } = new List<PerformanceDataPoint>();
        
        // 统计指标
        public double PromotionRecommendationScore { get; set; }
        public double JobMatchScore { get; set; }
        public double TalentScarcityScore { get; set; }
        public double TalentRetentionScore { get; set; }
    }

    public class TagViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class RadarChartViewModel
    {
        public double EducationBackground { get; set; }
        public double KeyExperience { get; set; }
        public double PersonalAbility { get; set; }
        public double PersonalityTrait { get; set; }
        public double WorkAttitude { get; set; }
        public double DevelopmentPotential { get; set; }
    }

    public class PerformanceDataPoint
    {
        public string Month { get; set; } = string.Empty;
        public double Value { get; set; }
    }
} 