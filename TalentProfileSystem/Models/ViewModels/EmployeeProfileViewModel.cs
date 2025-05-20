namespace TalentProfileSystem.Models.ViewModels
{
    /// <summary>
    /// 员工画像视图模型
    /// 包含员工个人画像的所有数据，用于在前端展示员工画像
    /// </summary>
    public class EmployeeProfileViewModel
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmployeeId { get; set; }
        
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// 工号，格式为6位数字
        /// </summary>
        public string WorkId { get; set; } = string.Empty; // 工号，暂时用EmployeeId代替
        
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; } = string.Empty;
        
        /// <summary>
        /// 所属部门
        /// </summary>
        public string Department { get; set; } = string.Empty;
        
        /// <summary>
        /// 职位级别（如：基层、中层、高层）
        /// </summary>
        public string PositionLevel { get; set; } = string.Empty;
        
        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime HireDate { get; set; }
        
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; } = string.Empty;
        
        /// <summary>
        /// 出生地
        /// </summary>
        public string Birthplace { get; set; } = string.Empty;
        
        /// <summary>
        /// 教育背景描述
        /// </summary>
        public string Education { get; set; } = string.Empty;
        
        /// <summary>
        /// 学历水平（如：高中、专科、本科、硕士、博士）
        /// </summary>
        public string AcademicLevel { get; set; } = string.Empty;
        
        /// <summary>
        /// 具体专业
        /// </summary>
        public string SpecificMajor { get; set; } = string.Empty;
        
        /// <summary>
        /// 工作年限
        /// </summary>
        public int WorkYears { get; set; }
        
        /// <summary>
        /// 员工标签列表
        /// </summary>
        public List<TagViewModel> Tags { get; set; } = new List<TagViewModel>();
        
        /// <summary>
        /// 综合能力评分（0-100）
        /// </summary>
        public double OverallScore { get; set; }
        
        /// <summary>
        /// 雷达图数据，用于展示员工六个维度的能力评估
        /// </summary>
        public RadarChartViewModel RadarChartData { get; set; } = new RadarChartViewModel();
        
        /// <summary>
        /// 绩效数据点列表，用于展示员工历史绩效
        /// </summary>
        public List<PerformanceDataPoint> PerformanceData { get; set; } = new List<PerformanceDataPoint>();
        
        /// <summary>
        /// 晋升推荐评分（0-100），评估员工是否适合晋升
        /// </summary>
        public double PromotionRecommendationScore { get; set; }
        
        /// <summary>
        /// 岗位匹配度评分（0-100），评估员工与当前岗位的匹配程度
        /// </summary>
        public double JobMatchScore { get; set; }
        
        /// <summary>
        /// 人才稀缺度评分（0-100），评估员工所拥有技能在公司内的稀缺程度
        /// </summary>
        public double TalentScarcityScore { get; set; }
        
        /// <summary>
        /// 人才保留评分（0-100），评估员工的离职风险和保留重要性
        /// </summary>
        public double TalentRetentionScore { get; set; }
    }

    /// <summary>
    /// 标签视图模型
    /// 表示员工的一个标签，包含标签名称、类别和颜色
    /// </summary>
    public class TagViewModel
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// 标签类别（如：技能、性格、绩效等）
        /// </summary>
        public string Category { get; set; } = string.Empty;
        
        /// <summary>
        /// 标签颜色，用于前端展示
        /// </summary>
        public string Color { get; set; } = string.Empty;
    }

    /// <summary>
    /// 雷达图视图模型
    /// 包含员工六个维度的能力评估得分，用于生成雷达图
    /// </summary>
    public class RadarChartViewModel
    {
        /// <summary>
        /// 教育背景维度得分（0-100）
        /// </summary>
        public double EducationBackground { get; set; }
        
        /// <summary>
        /// 关键经验维度得分（0-100）
        /// </summary>
        public double KeyExperience { get; set; }
        
        /// <summary>
        /// 个人能力维度得分（0-100）
        /// </summary>
        public double PersonalAbility { get; set; }
        
        /// <summary>
        /// 性格特质维度得分（0-100）
        /// </summary>
        public double PersonalityTrait { get; set; }
        
        /// <summary>
        /// 工作态度维度得分（0-100）
        /// </summary>
        public double WorkAttitude { get; set; }
        
        /// <summary>
        /// 发展潜力维度得分（0-100）
        /// </summary>
        public double DevelopmentPotential { get; set; }
    }

    /// <summary>
    /// 绩效数据点
    /// 表示员工某一时间段的绩效数据
    /// </summary>
    public class PerformanceDataPoint
    {
        /// <summary>
        /// 月份或时间段名称
        /// </summary>
        public string Month { get; set; } = string.Empty;
        
        /// <summary>
        /// 绩效得分值，通常将A+/A/B/C等级转换为数值（如：A+=5, A=4, B=3, C=2, D=1）
        /// </summary>
        public double Value { get; set; }
    }
} 