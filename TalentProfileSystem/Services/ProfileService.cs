using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITagService _tagService;
        private readonly IAnalysisService _analysisService;

        public ProfileService(
            IEmployeeService employeeService,
            ITagService tagService,
            IAnalysisService analysisService)
        {
            _employeeService = employeeService;
            _tagService = tagService;
            _analysisService = analysisService;
        }

        public async Task<EmployeeProfileViewModel> GetEmployeeProfileAsync(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                return new EmployeeProfileViewModel();
            }

            // 临时简单实现，未来会根据标签体系和评分算法进行完善
            var profile = new EmployeeProfileViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                WorkId = $"{employee.EmployeeId:D6}", // 临时使用EmployeeId生成工号
                Gender = employee.Gender,
                Department = employee.Department,
                PositionLevel = employee.PositionLevel,
                HireDate = employee.HireDate,
                Phone = employee.Phone,
                Birthplace = employee.Birthplace,
                
                // 先使用简单的占位数据，后续完善
                OverallScore = 80.0,
                RadarChartData = new RadarChartViewModel
                {
                    EducationBackground = 75.0,
                    KeyExperience = 80.0,
                    PersonalAbility = 85.0,
                    PersonalityTrait = 70.0,
                    WorkAttitude = 90.0,
                    DevelopmentPotential = 80.0
                },
                
                PromotionRecommendationScore = 75.0,
                JobMatchScore = 85.0,
                TalentScarcityScore = 70.0,
                TalentRetentionScore = 80.0
            };

            // 添加绩效数据
            profile.PerformanceData = new List<PerformanceDataPoint>
            {
                new PerformanceDataPoint { Month = "第一月", Value = ConvertPerformanceToValue(employee.PerformanceMonth1) },
                new PerformanceDataPoint { Month = "第二月", Value = ConvertPerformanceToValue(employee.PerformanceMonth2) },
                new PerformanceDataPoint { Month = "第三月", Value = ConvertPerformanceToValue(employee.PerformanceMonth3) }
            };

            // 临时的标签数据，后续完善
            profile.Tags = GeneratePlaceholderTags(employee);

            return profile;
        }

        public async Task<CollectiveProfileViewModel> GetCollectiveProfileAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            
            // 临时简单实现，未来会根据分析算法完善
            var collectiveProfile = new CollectiveProfileViewModel();
            
            // 计算部门分布
            collectiveProfile.DepartmentDistribution = employees
                .GroupBy(e => e.Department)
                .Select(g => new DepartmentDistribution
                {
                    Department = g.Key,
                    Count = g.Count(),
                    Percentage = (double)g.Count() / employees.Count * 100
                })
                .ToList();

            // 计算性别分布
            var maleCount = employees.Count(e => e.Gender == "男");
            var femaleCount = employees.Count(e => e.Gender == "女");
            collectiveProfile.GenderDistribution = new GenderDistribution
            {
                MaleCount = maleCount,
                FemaleCount = femaleCount,
                MalePercentage = (double)maleCount / employees.Count * 100,
                FemalePercentage = (double)femaleCount / employees.Count * 100
            };
            
            // 临时简单实现，其他属性暂不填充，留待后续完善
            return collectiveProfile;
        }

        public async Task<List<EmployeeProfileViewModel>> GetHighPerformanceProfilesAsync()
        {
            var highPerformanceEmployees = await _employeeService.GetHighPerformanceEmployeesAsync();
            var profiles = new List<EmployeeProfileViewModel>();
            
            foreach (var employee in highPerformanceEmployees)
            {
                var profile = await GetEmployeeProfileAsync(employee.EmployeeId);
                profiles.Add(profile);
            }
            
            // 按综合能力评分排序
            return profiles.OrderByDescending(p => p.OverallScore).ToList();
        }

        // 辅助方法：将绩效等级转换为数值
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

        // 辅助方法：生成临时标签数据
        private List<TagViewModel> GeneratePlaceholderTags(Employee employee)
        {
            var tags = new List<TagViewModel>();
            
            // 学历标签
            tags.Add(new TagViewModel
            {
                Name = employee.Education,
                Category = "学历",
                Color = "#4CAF50"
            });
            
            // 院校级别标签
            tags.Add(new TagViewModel
            {
                Name = employee.AcademicLevel,
                Category = "院校",
                Color = "#2196F3"
            });
            
            // 专业标签
            tags.Add(new TagViewModel
            {
                Name = employee.SpecificMajor,
                Category = "专业",
                Color = "#FF9800"
            });
            
            // 性格标签
            tags.Add(new TagViewModel
            {
                Name = employee.PersonalityType,
                Category = "性格",
                Color = "#9C27B0"
            });
            
            // 绩效标签
            if (employee.PerformanceMonth3 == "A+" || employee.PerformanceMonth3 == "A")
            {
                tags.Add(new TagViewModel
                {
                    Name = "绩效优秀",
                    Category = "绩效",
                    Color = "#F44336"
                });
            }
            
            return tags;
        }
    }
} 