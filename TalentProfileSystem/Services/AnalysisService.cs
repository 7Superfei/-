using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;
using TalentProfileSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace TalentProfileSystem.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly ApplicationDbContext _context;

        public AnalysisService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<double> CalculateOverallScoreAsync(Employee employee)
        {
            // 获取雷达图数据
            var radarData = await CalculateRadarChartDataAsync(employee);
            
            // 综合能力评分计算：六个维度的加权平均值
            double overallScore = (
                radarData.EducationBackground * 0.15 +  // 学历背景权重15%
                radarData.KeyExperience * 0.20 +        // 关键历练权重20%
                radarData.PersonalAbility * 0.25 +      // 个人能力权重25%
                radarData.PersonalityTrait * 0.10 +     // 性格特点权重10%
                radarData.WorkAttitude * 0.15 +         // 工作态度权重15%
                radarData.DevelopmentPotential * 0.15   // 发展潜力权重15%
            );
            
            return Math.Round(overallScore, 1);
        }
        
        public async Task<RadarChartViewModel> CalculateRadarChartDataAsync(Employee employee)
        {
            var attendanceRecords = await _context.AttendanceRecords
                .Where(a => a.EmployeeId == employee.EmployeeId)
                .ToListAsync();
            
            return new RadarChartViewModel
            {
                EducationBackground = CalculateEducationBackground(employee),
                KeyExperience = CalculateKeyExperience(employee),
                PersonalAbility = CalculatePersonalAbility(employee),
                PersonalityTrait = CalculatePersonalityTrait(employee),
                WorkAttitude = CalculateWorkAttitude(attendanceRecords),
                DevelopmentPotential = CalculateDevelopmentPotential(employee)
            };
        }
        
        // 学历背景计算（满分100）
        private double CalculateEducationBackground(Employee employee)
        {
            // 院校级别占50分
            double academicLevelScore = employee.AcademicLevel switch
            {
                "985" => 50.0,
                "211" => 40.0,
                "普通" => 25.0,
                _ => 0.0
            };
            
            // 学历占50分
            double educationScore = employee.Education switch
            {
                "博士" => 50.0,
                "硕士" => 45.0,
                "本科" => 25.0,
                _ => 0.0
            };
            
            return academicLevelScore + educationScore;
        }
        
        // 关键历练计算（满分100）
        private double CalculateKeyExperience(Employee employee)
        {
            // 从业经历占20分
            double workExperienceScore = 0.0;
            bool isCompanyTypeMatch = IsCompanyTypeMatch(employee.CompanyType);
            
            if (isCompanyTypeMatch)
            {
                workExperienceScore = employee.WorkYears switch
                {
                    >= 3 => 20.0,
                    2 => 15.0,
                    1 => 10.0,
                    _ => 0.0
                };
            }
            
            // 项目经历占80分
            double projectScore = CalculateProjectScore(employee);
            
            return workExperienceScore + projectScore;
        }
        
        // 判断公司类型是否匹配
        private bool IsCompanyTypeMatch(string companyType)
        {
            // 根据要求的匹配规则
            string[] matchingTypes = { 
                "互联网科技公司", 
                "软件科技公司", 
                "数字内容创作公司", 
                "互联网金融公司" 
            };
            return matchingTypes.Contains(companyType);
        }
        
        // 计算项目分数
        private double CalculateProjectScore(Employee employee)
        {
            double totalProjectScore = 0.0;
            
            // 获取员工的所有项目经历
            var projectExperiences = employee.ProjectExperiences.ToList();
            
            // 如果没有项目经历，返回0分
            if (projectExperiences.Count == 0)
            {
                return 0.0;
            }
            
            // 计算每个项目的得分并累加
            foreach (var project in projectExperiences)
            {
                double projectLevelScore = project.ProjectLevel switch
                {
                    "重点项目" => 20.0,
                    "一般项目" => 17.0,
                    "轻量级项目" => 15.0,
                    _ => 0.0
                };
                
                double projectRoleScore = 0.0;
                if (IsHighLevelRole(project.ProjectRole))
                {
                    projectRoleScore = 20.0;
                }
                else if (IsMidLevelRole(project.ProjectRole))
                {
                    projectRoleScore = 17.0;
                }
                else
                {
                    projectRoleScore = 15.0; // 基层
                }
                
                // 累加当前项目得分
                totalProjectScore += (projectLevelScore + projectRoleScore);
            }
            
            // 上限80分
            return Math.Min(totalProjectScore, 80.0);
        }
        
        // 判断是否为高层角色
        private bool IsHighLevelRole(string projectRole)
        {
            return projectRole == "项目总负责人" || projectRole == "技术或业务顾问";
        }
        
        // 判断是否为中层角色
        private bool IsMidLevelRole(string projectRole)
        {
            return projectRole == "项目经理" || projectRole == "团队负责人" || 
                   projectRole == "技术或业务专家";
        }
        
        // 判断是否为基层角色
        private bool IsBaseLevelRole(string projectRole)
        {
            return projectRole == "技术或业务执行岗" || projectRole == "支持保障岗";
        }
        
        // 个人能力计算（满分100）
        private double CalculatePersonalAbility(Employee employee)
        {
            // 三个月绩效评估的平均值
            double month1Score = ConvertPerformanceToScore(employee.PerformanceMonth1);
            double month2Score = ConvertPerformanceToScore(employee.PerformanceMonth2);
            double month3Score = ConvertPerformanceToScore(employee.PerformanceMonth3);
            
            return (month1Score + month2Score + month3Score) / 3.0;
        }
        
        // 将绩效等级转换为分数
        private double ConvertPerformanceToScore(string performance)
        {
            return performance switch
            {
                "A+" => 100.0,
                "A" => 90.0,
                "A-" => 80.0,
                "B+" => 70.0,
                "B" => 60.0,
                "C" => 40.0,
                _ => 0.0
            };
        }
        
        // 性格特点计算（满分100，根据MBTI与岗位匹配度计算）
        private double CalculatePersonalityTrait(Employee employee)
        {
            // MBTI与岗位匹配度计算
            var personalityType = employee.PersonalityType; // MBTI类型
            var department = employee.Department; // 部门
            
            // 根据部门和MBTI类型判断匹配程度
            return CalculateMbtiMatchScore(department, personalityType);
        }
        
        // 计算MBTI与岗位匹配度
        private double CalculateMbtiMatchScore(string department, string mbtiType)
        {
            // 定义各部门与MBTI类型的匹配度
            var departmentMbtiMatch = new Dictionary<string, Dictionary<string, double>>
            {
                {
                    "技术部", new Dictionary<string, double>
                    {
                        // 高度匹配 (100分)
                        { "INTJ", 100.0 }, { "INTP", 100.0 }, { "ISTP", 100.0 }, { "ISTJ", 100.0 },
                        // 较好匹配 (85分)
                        { "ENTJ", 85.0 }, { "ENTP", 85.0 }, { "ESTP", 85.0 }, { "ESTJ", 85.0 },
                        // 中等匹配 (70分)
                        { "INFJ", 70.0 }, { "INFP", 70.0 }, { "ISFP", 70.0 }, { "ISFJ", 70.0 },
                        // 较低匹配 (55分)
                        { "ENFJ", 55.0 }, { "ENFP", 55.0 }, { "ESFP", 55.0 }, { "ESFJ", 55.0 }
                    }
                },
                {
                    "设计部", new Dictionary<string, double>
                    {
                        // 高度匹配 (100分)
                        { "INFP", 100.0 }, { "ENFP", 100.0 }, { "ISFP", 100.0 }, { "ESFP", 100.0 },
                        // 较好匹配 (85分)
                        { "INFJ", 85.0 }, { "ENFJ", 85.0 }, { "INTP", 85.0 }, { "ENTP", 85.0 },
                        // 中等匹配 (70分)
                        { "INTJ", 70.0 }, { "ENTJ", 70.0 }, { "ISFJ", 70.0 }, { "ESFJ", 70.0 },
                        // 较低匹配 (55分)
                        { "ISTP", 55.0 }, { "ESTP", 55.0 }, { "ISTJ", 55.0 }, { "ESTJ", 55.0 }
                    }
                },
                {
                    "市场部", new Dictionary<string, double>
                    {
                        // 高度匹配 (100分)
                        { "ENFJ", 100.0 }, { "ESFJ", 100.0 }, { "ENFP", 100.0 }, { "ESFP", 100.0 },
                        // 较好匹配 (85分)
                        { "ENTJ", 85.0 }, { "ESTJ", 85.0 }, { "ENTP", 85.0 }, { "ESTP", 85.0 },
                        // 中等匹配 (70分)
                        { "INFJ", 70.0 }, { "ISFJ", 70.0 }, { "INFP", 70.0 }, { "ISFP", 70.0 },
                        // 较低匹配 (55分)
                        { "INTJ", 55.0 }, { "ISTJ", 55.0 }, { "INTP", 55.0 }, { "ISTP", 55.0 }
                    }
                },
                {
                    "产品部", new Dictionary<string, double>
                    {
                        // 高度匹配 (100分)
                        { "ENTJ", 100.0 }, { "INTJ", 100.0 }, { "ENTP", 100.0 }, { "INTP", 100.0 },
                        // 较好匹配 (85分)
                        { "ENFJ", 85.0 }, { "INFJ", 85.0 }, { "ENFP", 85.0 }, { "INFP", 85.0 },
                        // 中等匹配 (70分)
                        { "ESTJ", 70.0 }, { "ISTJ", 70.0 }, { "ESTP", 70.0 }, { "ISTP", 70.0 },
                        // 较低匹配 (55分)
                        { "ESFJ", 55.0 }, { "ISFJ", 55.0 }, { "ESFP", 55.0 }, { "ISFP", 55.0 }
                    }
                },
                {
                    "运营部", new Dictionary<string, double>
                    {
                        // 高度匹配 (100分)
                        { "ESTJ", 100.0 }, { "ESFJ", 100.0 }, { "ISTJ", 100.0 }, { "ISFJ", 100.0 },
                        // 较好匹配 (85分)
                        { "ENTJ", 85.0 }, { "ENFJ", 85.0 }, { "INTJ", 85.0 }, { "INFJ", 85.0 },
                        // 中等匹配 (70分)
                        { "ESTP", 70.0 }, { "ESFP", 70.0 }, { "ISTP", 70.0 }, { "ISFP", 70.0 },
                        // 较低匹配 (55分)
                        { "ENTP", 55.0 }, { "ENFP", 55.0 }, { "INTP", 55.0 }, { "INFP", 55.0 }
                    }
                },
                {
                    "销售部", new Dictionary<string, double>
                    {
                        // 高度匹配 (100分)
                        { "ESTP", 100.0 }, { "ESFP", 100.0 }, { "ESTJ", 100.0 }, { "ESFJ", 100.0 },
                        // 较好匹配 (85分)
                        { "ENTP", 85.0 }, { "ENFP", 85.0 }, { "ENTJ", 85.0 }, { "ENFJ", 85.0 },
                        // 中等匹配 (70分)
                        { "ISTP", 70.0 }, { "ISFP", 70.0 }, { "ISTJ", 70.0 }, { "ISFJ", 70.0 },
                        // 较低匹配 (55分)
                        { "INTP", 55.0 }, { "INFP", 55.0 }, { "INTJ", 55.0 }, { "INFJ", 55.0 }
                    }
                }
            };
            
            // 如果找到部门和MBTI类型的匹配记录，返回对应分数
            if (departmentMbtiMatch.ContainsKey(department) && 
                departmentMbtiMatch[department].ContainsKey(mbtiType))
            {
                return departmentMbtiMatch[department][mbtiType];
            }
            
            // 如果没有找到匹配记录，默认返回60分（基本匹配）
            return 60.0;
        }
        
        // 工作态度计算（满分100）
        private double CalculateWorkAttitude(List<AttendanceRecord> attendanceRecords)
        {
            double baseScore = 100.0;
            
            // 总记录数量
            int totalRecords = attendanceRecords.Count;
            if (totalRecords == 0)
                return baseScore;
                
            // 迟到或早退一次扣5分，请假扣3分，迟到且早退扣10分
            foreach (var record in attendanceRecords)
            {
                switch (record.Status)
                {
                    case "迟到":
                        baseScore -= 5.0;
                        break;
                    case "早退":
                        baseScore -= 5.0;
                        break;
                    case "请假":
                        baseScore -= 3.0;
                        break;
                    case "迟到且早退":
                        baseScore -= 10.0;
                        break;
                    // 正常出勤不扣分
                    case "正常":
                    default:
                        break;
                }
            }
            
            // 确保分数不小于0
            return Math.Max(0.0, baseScore);
        }
        
        // 发展潜力计算（满分100）
        private double CalculateDevelopmentPotential(Employee employee)
        {
            double baseScore = 70.0;
            
            // 获取绩效等级
            int[] performanceLevels = new int[3] {
                ConvertPerformanceToLevel(employee.PerformanceMonth1),
                ConvertPerformanceToLevel(employee.PerformanceMonth2),
                ConvertPerformanceToLevel(employee.PerformanceMonth3)
            };
            
            // 计算月度间绩效变化
            int change1To2 = performanceLevels[1] - performanceLevels[0]; // 第一个月到第二个月
            int change2To3 = performanceLevels[2] - performanceLevels[1]; // 第二个月到第三个月
            
            // 根据变化调整分数
            baseScore += CalculateScoreAdjustmentForChange(change1To2);
            baseScore += CalculateScoreAdjustmentForChange(change2To3);
            
            // 确保分数在0-100之间
            return Math.Max(0.0, Math.Min(100.0, baseScore));
        }
        
        // 将绩效等级转换为数字等级（用于比较）
        private int ConvertPerformanceToLevel(string performance)
        {
            return performance switch
            {
                "A+" => 6,
                "A" => 5,
                "A-" => 4,
                "B+" => 3,
                "B" => 2,
                "C" => 1,
                _ => 0
            };
        }
        
        // 根据绩效变化计算分数调整
        private double CalculateScoreAdjustmentForChange(int change)
        {
            if (change >= 3)
                return 15.0;  // 跨三个等级及以上加15分
            else if (change == 2)
                return 10.0;  // 跨两个等级加10分
            else if (change == 1)
                return 5.0;   // 跨一个等级加5分
            else if (change <= -3)
                return -15.0; // 跨三个等级及以上扣15分
            else if (change == -2)
                return -10.0; // 跨两个等级扣10分
            else if (change == -1)
                return -5.0;  // 跨一个等级扣5分
            else
                return 0.0;   // 无变化不调整分数
        }
        
        // 辅助方法：将绩效等级转换为数值（用于排序）
        private double ConvertPerformanceToValue(string performance)
        {
            return performance switch
            {
                "A+" => 5.0,
                "A" => 4.5,
                "A-" => 4.0,
                "B+" => 3.5,
                "B" => 3.0,
                "C" => 2.0,
                _ => 0.0
            };
        }
        
        // 以下方法保持原样
        public async Task<double> CalculateJobMatchScoreAsync(Employee employee)
        {
            // 岗位匹配度计算：专业匹配度(40%) + MBTI匹配度(30%) + 公司匹配度(30%)
            
            // 1. 获取专业与岗位的匹配度 (40%)
            double majorMatchScore = CalculateMajorMatchScore(employee.Department, employee.SpecificMajor, employee.MajorCategory);
            
            // 2. 获取MBTI与岗位的匹配度 (30%)
            double mbtiMatchScore = CalculateMbtiMatchScore(employee.Department, employee.PersonalityType);
            
            // 3. 从业历史公司与本公司的匹配度 (30%)
            double companyMatchScore = CalculateCompanyMatchScore(employee.CompanyType);
            
            // 加权平均计算
            double jobMatchScore = (
                majorMatchScore * 0.4 +
                mbtiMatchScore * 0.3 +
                companyMatchScore * 0.3
            );
            
            return Math.Round(jobMatchScore, 1);
        }
        
        // 计算专业与岗位匹配度
        private double CalculateMajorMatchScore(string department, string specificMajor, string majorCategory)
        {
            // 首先尝试直接匹配专业名称
            double directMatchScore = CheckDirectMajorMatch(department, specificMajor);
            if (directMatchScore > 0)
            {
                return directMatchScore;
            }
            
            // 如果直接匹配失败，尝试检查大类匹配
            if (majorCategory.Contains("工科") || majorCategory.Contains("理科"))
            {
                // 工科/理科类专业
                if (department == "技术部" || department == "产品部")
                {
                    return 80.0;
                }
                else if (department == "设计部" && majorCategory.Contains("工科"))
                {
                    return 80.0;
                }
                else if ((department == "市场部" || department == "运营部") && majorCategory.Contains("理科"))
                {
                    return 80.0;
                }
                else if (department == "销售部" && majorCategory.Contains("理科"))
                {
                    return 80.0;
                }
            }
            else if (majorCategory.Contains("文科"))
            {
                // 文科专业
                if (department == "设计部" || department == "市场部" || 
                    department == "运营部" || department == "销售部")
                {
                    return 80.0;
                }
                else if (department == "产品部" && specificMajor.Contains("管理"))
                {
                    return 80.0;
                }
            }
            else
            {
                // 使用specificMajor进行更细粒度的判断
                return CheckMajorCategoryBySpecificName(department, specificMajor);
            }
            
            // 如果没有找到匹配记录，默认返回60分（基本匹配）
            return 60.0;
        }
        
        // 通过具体专业名称检查大类匹配
        private double CheckMajorCategoryBySpecificName(string department, string specificMajor)
        {
            // 从上面的CalculateMajorMatchScore方法中提取的逻辑
            if (specificMajor.Contains("计算机") || specificMajor.Contains("软件") || 
                specificMajor.Contains("信息") || specificMajor.Contains("电子") || 
                specificMajor.Contains("通信") || specificMajor.Contains("数据") || 
                specificMajor.Contains("网络") || specificMajor.Contains("人工智能") ||
                specificMajor.Contains("统计") || specificMajor.Contains("数学"))
            {
                // 工科/理科类专业
                if (department == "技术部" || department == "产品部")
                {
                    return 80.0;
                }
            }
            else if (specificMajor.Contains("设计") || specificMajor.Contains("艺术") || 
                    specificMajor.Contains("广告") || specificMajor.Contains("传播") ||
                    specificMajor.Contains("建筑") || specificMajor.Contains("规划"))
            {
                // 设计类专业
                if (department == "设计部")
                {
                    return 80.0;
                }
            }
            else if (specificMajor.Contains("管理") || specificMajor.Contains("市场") ||
                    specificMajor.Contains("营销") || specificMajor.Contains("经济") ||
                    specificMajor.Contains("金融") || specificMajor.Contains("法学") ||
                    specificMajor.Contains("社会") || specificMajor.Contains("心理") ||
                    specificMajor.Contains("教育"))
            {
                // 文科/管理类专业
                if (department == "市场部" || department == "产品部" || 
                    department == "运营部" || department == "销售部")
                {
                    return 80.0;
                }
            }
            
            return 60.0;
        }
        
        // 直接专业匹配检查
        private double CheckDirectMajorMatch(string department, string specificMajor)
        {
            // 定义各部门的专业匹配度
            var departmentMajorMatch = new Dictionary<string, List<string>>
            {
                {
                    "技术部", new List<string>
                    {
                        "计算机科学与技术", "软件工程", "人工智能", "大数据技术", 
                        "物联网工程", "网络工程", "网络安全", "电子信息工程", 
                        "通信工程", "数据科学与大数据技术", "区块链工程",
                        "数学与应用数学", "信息与计算科学", "统计学", "应用统计学"
                    }
                },
                {
                    "设计部", new List<string>
                    {
                        "广告学", "传播学", "艺术设计", "工业设计",
                        "建筑学", "城乡规划"
                    }
                },
                {
                    "市场部", new List<string>
                    {
                        "新闻学", "传播学", "广告学", "市场营销", 
                        "社会学", "心理学", "应用心理学"
                    }
                },
                {
                    "产品部", new List<string>
                    {
                        "计算机", "软件工程", "管理学", "法学", "数据科学", "传播学"
                    }
                },
                {
                    "运营部", new List<string>
                    {
                        "教育学", "教育技术学", "管理学", "新闻学", "传播学",
                        "统计学", "应用心理学", "大数据技术", "网络工程"
                    }
                },
                {
                    "销售部", new List<string>
                    {
                        "法学", "社会学", "政治学", "管理学", "心理学"
                    }
                }
            };
            
            // 如果找到部门和专业的匹配记录
            if (departmentMajorMatch.ContainsKey(department))
            {
                foreach (var majorKeyword in departmentMajorMatch[department])
                {
                    // 检查专业名称是否包含匹配项
                    if (specificMajor.Contains(majorKeyword) || 
                        (majorKeyword.Length > 2 && specificMajor.Contains(majorKeyword.Substring(0, majorKeyword.Length - 1))))
                    {
                        return 100.0;
                    }
                }
            }
            
            return 0.0; // 没有直接匹配
        }
        
        // 计算公司类型匹配度
        private double CalculateCompanyMatchScore(string companyType)
        {
            // 与本公司（互联网公司）匹配的公司类型
            string[] matchingCompanyTypes = { 
                "互联网科技公司", "软件科技公司", "顶级互联网公司", 
                "数字内容创作公司", "互联网金融公司" 
            };
            
            // 不太匹配但相关的公司类型
            string[] partialMatchingCompanyTypes = { 
                "传统零售企业电商部门", "线上平台", "在线教育公司",
                "广告营销公司" 
            };
            
            // 完全不匹配的公司类型
            string[] nonMatchingCompanyTypes = { 
                "物流企业", "传统制造业公司", "农业企业",
                "实体餐饮企业", "传统服务机构" 
            };
            
            // 匹配度评分
            if (matchingCompanyTypes.Any(type => companyType.Contains(type) || type.Contains(companyType)))
            {
                return 100.0; // 完全匹配
            }
            else if (partialMatchingCompanyTypes.Any(type => companyType.Contains(type) || type.Contains(companyType)))
            {
                return 70.0; // 部分匹配
            }
            else if (nonMatchingCompanyTypes.Any(type => companyType.Contains(type) || type.Contains(companyType)))
            {
                return 40.0; // 不匹配
            }
            else
            {
                return 60.0; // 默认中等匹配度
            }
        }
        
        public async Task<double> CalculatePromotionRecommendationScoreAsync(Employee employee)
        {
            // 获取雷达图数据
            var radarData = await CalculateRadarChartDataAsync(employee);
            
            // 晋升推荐度计算：关键历练(30%),个人能力(35%),发展潜力(20%),工作态度(15%)
            double promotionScore = (
                radarData.KeyExperience * 0.30 +     // 关键历练权重30%
                radarData.PersonalAbility * 0.35 +   // 个人能力权重35%
                radarData.DevelopmentPotential * 0.20 + // 发展潜力权重20%
                radarData.WorkAttitude * 0.15        // 工作态度权重15%
            );
            
            return Math.Round(promotionScore, 1);
        }
        
        public async Task<double> CalculateTalentScarcityScoreAsync(Employee employee)
        {
            // 获取综合能力评分
            double overallScore = await CalculateOverallScoreAsync(employee);
            
            // 获取所有员工
            var allEmployees = await _context.Employees.ToListAsync();
            int totalEmployeeCount = allEmployees.Count;
            
            // 各部门健康比例
            var departmentHealthyRatio = new Dictionary<string, double>
            {
                { "技术部", 0.30 },
                { "设计部", 0.08 },
                { "市场部", 0.12 },
                { "产品部", 0.10 },
                { "运营部", 0.20 },
                { "销售部", 0.20 }
            };
            
            // 计算当前部门实际比例
            int departmentEmployeeCount = allEmployees.Count(e => e.Department == employee.Department);
            double actualRatio = (double)departmentEmployeeCount / totalEmployeeCount;
            
            // 获取该部门的健康比例
            double healthyRatio = departmentHealthyRatio.ContainsKey(employee.Department) 
                ? departmentHealthyRatio[employee.Department] 
                : 0.15; // 默认值
            
            // 计算人才稀缺度基础分数
            double baseScarcityScore = 70.0; // 基础分为70分
            
            // 计算部门比例差异系数
            double ratioDifference = healthyRatio - actualRatio;
            double ratioFactor;
            
            if (ratioDifference > 0)
            {
                // 部门人员不足，稀缺性更高
                ratioFactor = Math.Min(30.0, 30.0 * (ratioDifference / healthyRatio));
            }
            else
            {
                // 部门人员过剩，稀缺性更低
                ratioFactor = Math.Max(-30.0, 30.0 * (ratioDifference / healthyRatio));
            }
            
            // 优秀员工稀缺性加成（根据综合能力评分）
            double performanceFactor = 0.0;
            if (overallScore >= 90.0)
            {
                performanceFactor = 20.0; // 顶级人才
            }
            else if (overallScore >= 80.0)
            {
                performanceFactor = 15.0; // 优秀人才
            }
            else if (overallScore >= 70.0)
            {
                performanceFactor = 10.0; // 良好人才
            }
            else if (overallScore >= 60.0)
            {
                performanceFactor = 5.0; // 一般人才
            }
            
            // 综合计算人才稀缺度分数
            double scarcityScore = baseScarcityScore + ratioFactor + performanceFactor;
            
            // 确保分数在0-100区间内
            return Math.Max(0.0, Math.Min(100.0, Math.Round(scarcityScore, 1)));
        }
        
        public async Task<double> CalculateTalentRetentionScoreAsync(Employee employee)
        {
            // 基础保有率得分
            double baseRetentionScore = 75.0;
            
            // 1. 绩效评估因素（30%）
            double performanceFactor = CalculatePerformanceRetentionFactor(employee);
            
            // 2. 考勤情况因素（15%）
            double attendanceFactor = CalculateAttendanceRetentionFactor(employee.AttendanceRecords.ToList());
            
            // 3. 调查问卷因素（40%）
            double surveyFactor = CalculateSurveyRetentionFactor(employee);
            
            // 4. 职位变动因素（15%）
            double positionChangeFactor = await CalculatePositionChangeRetentionFactor(employee);
            
            // 组合计算总保有率分数
            double retentionScore = baseRetentionScore + 
                                   (performanceFactor * 0.30) + 
                                   (attendanceFactor * 0.15) + 
                                   (surveyFactor * 0.40) + 
                                   (positionChangeFactor * 0.15);
            
            // 确保分数在0-100区间内
            return Math.Max(0.0, Math.Min(100.0, Math.Round(retentionScore, 1)));
        }
        
        // 计算绩效对保有率的影响
        private double CalculatePerformanceRetentionFactor(Employee employee)
        {
            // 获取三个月绩效的平均分数
            double month1Value = ConvertPerformanceToValue(employee.PerformanceMonth1);
            double month2Value = ConvertPerformanceToValue(employee.PerformanceMonth2);
            double month3Value = ConvertPerformanceToValue(employee.PerformanceMonth3);
            
            double avgPerformance = (month1Value + month2Value + month3Value) / 3.0;
            
            // 绩效越高，保有率越高
            if (avgPerformance >= 4.5) // A+/A区间
                return 20.0;
            else if (avgPerformance >= 4.0) // A-区间
                return 15.0;
            else if (avgPerformance >= 3.5) // B+区间
                return 10.0;
            else if (avgPerformance >= 3.0) // B区间
                return 0.0;
            else
                return -15.0; // C区间
        }
        
        // 计算考勤对保有率的影响
        private double CalculateAttendanceRetentionFactor(List<AttendanceRecord> attendanceRecords)
        {
            // 如果没有考勤记录，返回中性影响
            if (attendanceRecords.Count == 0)
                return 0.0;
            
            // 统计各类型考勤情况
            int normalCount = attendanceRecords.Count(r => r.Status == "正常");
            int lateCount = attendanceRecords.Count(r => r.Status == "迟到");
            int leaveEarlyCount = attendanceRecords.Count(r => r.Status == "早退");
            int absentCount = attendanceRecords.Count(r => r.Status == "请假");
            int bothLateAndLeaveCount = attendanceRecords.Count(r => r.Status == "迟到且早退");
            
            // 计算正常出勤率
            double totalRecords = attendanceRecords.Count;
            double normalRatio = normalCount / totalRecords;
            
            // 基于正常出勤率和异常情况计算考勤因素
            if (normalRatio >= 0.95)
                return 15.0;
            else if (normalRatio >= 0.90)
                return 10.0;
            else if (normalRatio >= 0.85)
                return 5.0;
            else if (normalRatio >= 0.80)
                return 0.0;
            else if (bothLateAndLeaveCount > 3 || absentCount > 5)
                return -15.0;
            else
                return -10.0;
        }
        
        // 计算调查问卷对保有率的影响
        private double CalculateSurveyRetentionFactor(Employee employee)
        {
            // 1. 生存压力因素（婚姻状况和房贷压力）
            double survivalPressureFactor = CalculateSurvivalPressureFactor(employee.MaritalStatus, employee.MortgagePressure);
            
            // 2. 工作满意度因素（工作环境满意度和薪资满意度）
            double satisfactionFactor = CalculateSatisfactionFactor(employee.WorkEnvironmentSatisfaction, employee.SalarySatisfaction);
            
            // 组合生存压力和满意度因素
            return (survivalPressureFactor + satisfactionFactor) / 2.0;
        }
        
        // 计算生存压力对保有率的影响
        private double CalculateSurvivalPressureFactor(string maritalStatus, string mortgagePressure)
        {
            // 转换为数值评分
            double maritalFactor = maritalStatus switch
            {
                "已婚已育" => 10.0,  // 家庭责任较重，稳定性需求高
                "已婚未育" => 5.0,   // 有一定家庭责任
                "未婚" => -5.0,      // 家庭责任较轻，流动性较大
                _ => 0.0
            };
            
            double mortgageFactor = mortgagePressure switch
            {
                "高" => 15.0,       // 压力大，需要稳定工作
                "中" => 5.0,        // 有一定压力
                "低" => -5.0,       // 压力小，灵活性高
                "无" => -10.0,      // 无压力，高度灵活
                _ => 0.0
            };
            
            return maritalFactor + mortgageFactor;
        }
        
        // 计算工作满意度对保有率的影响
        private double CalculateSatisfactionFactor(string workEnvironmentSatisfaction, string salarySatisfaction)
        {
            // 转换为数值评分
            double workEnvFactor = workEnvironmentSatisfaction switch
            {
                "很满意" => 15.0,
                "满意" => 10.0,
                "一般" => 0.0,
                "较差" => -15.0,
                "很差" => -25.0,
                _ => 0.0
            };
            
            double salaryFactor = salarySatisfaction switch
            {
                "很满意" => 15.0,
                "满意" => 10.0,
                "一般" => 0.0,
                "较差" => -20.0,  // 薪资不满意是离职的重要因素
                "很差" => -30.0,
                _ => 0.0
            };
            
            // 薪资满意度权重稍高
            return (workEnvFactor * 0.4) + (salaryFactor * 0.6);
        }
        
        // 计算职位变动对保有率的影响
        private async Task<double> CalculatePositionChangeRetentionFactor(Employee employee)
        {
            var positionChanges = employee.PositionChanges.OrderByDescending(pc => pc.ChangeDate).ToList();
            
            // 如果没有职位变动记录，返回中性影响
            if (positionChanges.Count == 0)
                return 0.0;
            
            // 获取最近一次职位变动
            var latestChange = positionChanges.First();
            
            // 计算距今时间（月份）
            int monthsSinceChange = (DateTime.Now.Year - latestChange.ChangeDate.Year) * 12 + 
                                   (DateTime.Now.Month - latestChange.ChangeDate.Month);
            
            // 时间因素：随着时间推移，职位变动的影响会减弱
            double timeFactor = 1.0;
            if (monthsSinceChange > 24) // 两年以上
                timeFactor = 0.2;
            else if (monthsSinceChange > 12) // 一到两年
                timeFactor = 0.5;
            else if (monthsSinceChange > 6) // 半年到一年
                timeFactor = 0.8;
            
            // 职位变动类型因素
            double changeTypeFactor = 0.0;
            if (latestChange.PositionChangeDescription.Contains("->"))
            {
                string[] parts = latestChange.PositionChangeDescription.Split("->");
                if (parts.Length == 2)
                {
                    string from = parts[0].Trim();
                    string to = parts[1].Trim();
                    
                    // 晋升
                    if ((from == "基层" && to == "中层") || (from == "中层" && to == "高层"))
                        changeTypeFactor = 20.0;
                    // 降职
                    else if ((from == "中层" && to == "基层") || (from == "高层" && to == "中层"))
                        changeTypeFactor = -25.0;
                }
            }
            
            // 调岗但非晋升/降职
            else if (latestChange.PositionChangeDescription.Contains("调岗") || 
                    latestChange.PositionChangeDescription.Contains("转岗"))
            {
                changeTypeFactor = 5.0; // 通常调岗也有积极影响
            }
            
            return changeTypeFactor * timeFactor;
        }
        
        public async Task<List<TalentStructureAnalysis>> AnalyzeTalentStructureAsync(List<Employee> employees)
        {
            // 人才结构分析算法占位实现
            var result = new List<TalentStructureAnalysis>();
            
            // 添加一些示例数据
            result.Add(new TalentStructureAnalysis
            {
                Position = "技术部-高级开发工程师",
                Status = "过剩",
                CurrentCount = 10,
                IdealCount = 8,
                Difference = 2
            });
            
            result.Add(new TalentStructureAnalysis
            {
                Position = "产品部-产品经理",
                Status = "不足",
                CurrentCount = 3,
                IdealCount = 5,
                Difference = -2
            });
            
            return result;
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetStarEmployeesAsync(List<Employee> employees)
        {
            var result = new List<OutstandingEmployeeViewModel>();
            
            foreach (var employee in employees)
            {
                // 1. 判断近三个月绩效是否均为A-及以上
                bool hasGoodPerformance = 
                    (employee.PerformanceMonth1 == "A+" || employee.PerformanceMonth1 == "A" || employee.PerformanceMonth1 == "A-") &&
                    (employee.PerformanceMonth2 == "A+" || employee.PerformanceMonth2 == "A" || employee.PerformanceMonth2 == "A-") &&
                    (employee.PerformanceMonth3 == "A+" || employee.PerformanceMonth3 == "A" || employee.PerformanceMonth3 == "A-");
                
                // 2. 考勤异常情况小于等于两次
                int attendanceIssueCount = employee.AttendanceRecords
                    .Count(a => a.Status != "正常");
                bool hasGoodAttendance = attendanceIssueCount <= 2;
                
                // 3. 有重点项目经历
                bool hasKeyProject = employee.ProjectExperiences
                    .Any(p => p.ProjectLevel == "重点项目");
                
                // 判断是否符合明星员工条件
                if (hasGoodPerformance && hasGoodAttendance && hasKeyProject)
                {
                    // 计算评分：绩效、考勤和项目经历的综合评分
                    double performanceScore = 
                        (ConvertPerformanceToValue(employee.PerformanceMonth1) + 
                         ConvertPerformanceToValue(employee.PerformanceMonth2) +
                         ConvertPerformanceToValue(employee.PerformanceMonth3)) / 3.0;
                    
                    // 根据考勤记录计算考勤分数，使用与CalculateWorkAttitude一致的扣分规则
                    double attendanceScore = 100.0;
                    foreach (var record in employee.AttendanceRecords)
                    {
                        switch (record.Status)
                        {
                            case "迟到":
                            case "早退":
                                attendanceScore -= 5.0;
                                break;
                            case "请假":
                                attendanceScore -= 3.0;
                                break;
                            case "迟到且早退":
                                attendanceScore -= 10.0;
                                break;
                        }
                    }
                    // 确保分数不小于0
                    attendanceScore = Math.Max(0.0, attendanceScore);
                    
                    double projectScore = 90.0;
                    
                    double overallScore = 
                        (performanceScore * 0.6) + 
                        (attendanceScore * 0.2) + 
                        (projectScore * 0.2);
                    
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = Math.Round(overallScore, 1)
                    });
                }
            }
            
            // 按评分从高到低排序
            return result.OrderByDescending(e => e.Score).ToList();
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetPotentialEmployeesAsync(List<Employee> employees)
        {
            var result = new List<OutstandingEmployeeViewModel>();
            
            foreach (var employee in employees)
            {
                // 获取三个月的绩效值
                double month1Value = ConvertPerformanceToValue(employee.PerformanceMonth1);
                double month2Value = ConvertPerformanceToValue(employee.PerformanceMonth2);
                double month3Value = ConvertPerformanceToValue(employee.PerformanceMonth3);
                
                // 判断绩效是否连续增加
                bool isPerformanceIncreasing = month1Value < month2Value && month2Value < month3Value;
                
                if (isPerformanceIncreasing)
                {
                    // 计算评分：绩效提升幅度、最新绩效水平的综合评估
                    double improvementRate = (month3Value - month1Value) / month1Value;
                    double latestPerformanceScore = month3Value * 20; // 转换为100分制
                    
                    // 考虑绩效提升幅度和最终水平
                    double overallScore = 
                        (latestPerformanceScore * 0.6) + 
                        (Math.Min(improvementRate * 100, 100) * 0.4);
                    
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = Math.Round(overallScore, 1)
                    });
                }
            }
            
            // 按评分从高到低排序
            return result.OrderByDescending(e => e.Score).ToList();
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetTransferRecommendationsAsync(List<Employee> employees)
        {
            // 调职推荐算法占位实现
            return new List<OutstandingEmployeeViewModel>();
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetUnderperformingEmployeesAsync(List<Employee> employees)
        {
            var result = new List<OutstandingEmployeeViewModel>();
            
            foreach (var employee in employees)
            {
                // 计算综合能力评分
                double overallScore = await CalculateOverallScoreAsync(employee);
                
                // 判断综合能力评分是否小于60
                if (overallScore < 60.0)
                {
                    // 将评分转换为"表现欠佳"得分
                    // 综合能力越低，表现欠佳评分越高
                    double underperformingScore = 100.0 - overallScore;
                    
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = Math.Round(underperformingScore, 1)
                    });
                }
            }
            
            // 按评分从高到低排序（表现越差，评分越高）
            return result.OrderByDescending(e => e.Score).ToList();
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetAttritionRiskEmployeesAsync(List<Employee> employees)
        {
            var result = new List<OutstandingEmployeeViewModel>();
            
            foreach (var employee in employees)
            {
                // 计算人才保有率
                double talentRetentionScore = await CalculateTalentRetentionScoreAsync(employee);
                
                // 判断人才保有率是否小于60
                if (talentRetentionScore < 60.0)
                {
                    // 保有率越低，离职风险越高，评分越高
                    double riskScore = 100.0 - talentRetentionScore;
                    
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = Math.Round(riskScore, 1)
                    });
                }
            }
            
            // 按评分从高到低排序（离职风险从高到低）
            return result.OrderByDescending(e => e.Score).ToList();
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetPromotionRecommendationsAsync(List<Employee> employees)
        {
            // 晋升推荐算法占位实现
            var result = new List<OutstandingEmployeeViewModel>();
            
            // 简单示例：连续三个月绩效都是A或以上的员工
            foreach (var employee in employees)
            {
                if ((employee.PerformanceMonth1 == "A+" || employee.PerformanceMonth1 == "A") &&
                    (employee.PerformanceMonth2 == "A+" || employee.PerformanceMonth2 == "A") &&
                    (employee.PerformanceMonth3 == "A+" || employee.PerformanceMonth3 == "A"))
                {
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = 90.0
                    });
                }
            }
            
            return result;
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetHighPerformanceEmployeesAsync(List<Employee> employees)
        {
            var result = new List<OutstandingEmployeeViewModel>();
            
            foreach (var employee in employees)
            {
                // 判断近三个月绩效是否均为A及以上
                bool hasExcellentPerformance = 
                    (employee.PerformanceMonth1 == "A+" || employee.PerformanceMonth1 == "A") &&
                    (employee.PerformanceMonth2 == "A+" || employee.PerformanceMonth2 == "A") &&
                    (employee.PerformanceMonth3 == "A+" || employee.PerformanceMonth3 == "A");
                
                if (hasExcellentPerformance)
                {
                    // 计算评分：绩效的平均值
                    double month1Score = ConvertPerformanceToValue(employee.PerformanceMonth1);
                    double month2Score = ConvertPerformanceToValue(employee.PerformanceMonth2);
                    double month3Score = ConvertPerformanceToValue(employee.PerformanceMonth3);
                    
                    // 均转换为100分制
                    double overallScore = ((month1Score + month2Score + month3Score) / 3.0) * 20;
                    
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = Math.Round(overallScore, 1)
                    });
                }
            }
            
            // 按评分从高到低排序
            return result.OrderByDescending(e => e.Score).ToList();
        }
    }
} 