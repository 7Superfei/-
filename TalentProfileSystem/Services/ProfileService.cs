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

            // 创建员工画像视图模型
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
                
                // 添加社会信息相关属性赋值
                Education = employee.Education,
                AcademicLevel = employee.AcademicLevel,
                SpecificMajor = employee.SpecificMajor,
                WorkYears = employee.WorkYears
            };
            
            // 使用AnalysisService计算雷达图数据
            profile.RadarChartData = await _analysisService.CalculateRadarChartDataAsync(employee);
            
            // 使用AnalysisService计算综合能力评分
            profile.OverallScore = await _analysisService.CalculateOverallScoreAsync(employee);
            
            // 使用AnalysisService计算其他统计指标
            profile.PromotionRecommendationScore = await _analysisService.CalculatePromotionRecommendationScoreAsync(employee);
            profile.JobMatchScore = await _analysisService.CalculateJobMatchScoreAsync(employee);
            profile.TalentScarcityScore = await _analysisService.CalculateTalentScarcityScoreAsync(employee);
            profile.TalentRetentionScore = await _analysisService.CalculateTalentRetentionScoreAsync(employee);

            // 添加绩效数据
            profile.PerformanceData = new List<PerformanceDataPoint>
            {
                new PerformanceDataPoint { Month = "第一月", Value = ConvertPerformanceToValue(employee.PerformanceMonth1) },
                new PerformanceDataPoint { Month = "第二月", Value = ConvertPerformanceToValue(employee.PerformanceMonth2) },
                new PerformanceDataPoint { Month = "第三月", Value = ConvertPerformanceToValue(employee.PerformanceMonth3) }
            };

            // 使用TagService获取员工标签
            profile.Tags = await _tagService.GetEmployeeTagsAsync(employee);

            return profile;
        }

        public async Task<CollectiveProfileViewModel> GetCollectiveProfileAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            
            var collectiveProfile = new CollectiveProfileViewModel();
            
            // 计算部门分布
            collectiveProfile.DepartmentDistribution = employees
                .GroupBy(e => e.Department)
                .Select(g => new DepartmentDistribution
                {
                    Department = g.Key,
                    Count = g.Count(),
                    Percentage = Math.Round((double)g.Count() / employees.Count * 100, 1)
                })
                .ToList();

            // 计算人才稀缺部门和人才冗余部门
            var departmentIdealRanges = new Dictionary<string, (double Min, double Max)>
            {
                { "技术部", (25, 35) },
                { "设计部", (5, 10) },
                { "市场部", (10, 15) },
                { "产品部", (10, 15) },
                { "运营部", (10, 20) },
                { "销售部", (10, 20) }
            };

            collectiveProfile.TalentShortages = new List<DepartmentTalentStatus>();
            collectiveProfile.TalentSurpluses = new List<DepartmentTalentStatus>();

            foreach (var dept in collectiveProfile.DepartmentDistribution)
            {
                if (departmentIdealRanges.TryGetValue(dept.Department, out var idealRange))
                {
                    // 计算当前占比与理想范围的偏差
                    if (dept.Percentage < idealRange.Min)
                    {
                        // 人才稀缺
                        var deviation = idealRange.Min - dept.Percentage;
                        var status = DetermineTalentShortageStatus(deviation);
                        
                        collectiveProfile.TalentShortages.Add(new DepartmentTalentStatus
                        {
                            Department = dept.Department,
                            Status = status,
                            CurrentPercentage = dept.Percentage,
                            MinIdealPercentage = idealRange.Min,
                            MaxIdealPercentage = idealRange.Max,
                            Deviation = deviation
                        });
                    }
                    else if (dept.Percentage > idealRange.Max)
                    {
                        // 人才冗余
                        var deviation = dept.Percentage - idealRange.Max;
                        var status = DetermineTalentSurplusStatus(deviation);
                        
                        collectiveProfile.TalentSurpluses.Add(new DepartmentTalentStatus
                        {
                            Department = dept.Department,
                            Status = status,
                            CurrentPercentage = dept.Percentage,
                            MinIdealPercentage = idealRange.Min,
                            MaxIdealPercentage = idealRange.Max,
                            Deviation = deviation
                        });
                    }
                }
            }

            // 按偏差程度排序
            collectiveProfile.TalentShortages = collectiveProfile.TalentShortages
                .OrderByDescending(s => s.Deviation)
                .ToList();
                
            collectiveProfile.TalentSurpluses = collectiveProfile.TalentSurpluses
                .OrderByDescending(s => s.Deviation)
                .ToList();

            // 计算年龄分布
            collectiveProfile.AgeDistribution = new List<AgeDistribution>
            {
                new AgeDistribution 
                { 
                    AgeRange = "25以下", 
                    Count = employees.Count(e => e.Age < 25),
                    Percentage = Math.Round((double)employees.Count(e => e.Age < 25) / employees.Count * 100, 1)
                },
                new AgeDistribution 
                { 
                    AgeRange = "25-35", 
                    Count = employees.Count(e => e.Age >= 25 && e.Age <= 35),
                    Percentage = Math.Round((double)employees.Count(e => e.Age >= 25 && e.Age <= 35) / employees.Count * 100, 1)
                },
                new AgeDistribution 
                { 
                    AgeRange = "35-45", 
                    Count = employees.Count(e => e.Age > 35 && e.Age <= 45),
                    Percentage = Math.Round((double)employees.Count(e => e.Age > 35 && e.Age <= 45) / employees.Count * 100, 1)
                },
                new AgeDistribution 
                { 
                    AgeRange = "45以上", 
                    Count = employees.Count(e => e.Age > 45),
                    Percentage = Math.Round((double)employees.Count(e => e.Age > 45) / employees.Count * 100, 1)
                }
            };
            
            // 计算层级分布
            collectiveProfile.PositionLevelDistribution = new List<PositionLevelDistribution>
            {
                new PositionLevelDistribution
                {
                    Level = "基层",
                    Count = employees.Count(e => e.PositionLevel == "基层"),
                    Percentage = Math.Round((double)employees.Count(e => e.PositionLevel == "基层") / employees.Count * 100, 1)
                },
                new PositionLevelDistribution
                {
                    Level = "中层",
                    Count = employees.Count(e => e.PositionLevel == "中层"),
                    Percentage = Math.Round((double)employees.Count(e => e.PositionLevel == "中层") / employees.Count * 100, 1)
                },
                new PositionLevelDistribution
                {
                    Level = "高层",
                    Count = employees.Count(e => e.PositionLevel == "高层"),
                    Percentage = Math.Round((double)employees.Count(e => e.PositionLevel == "高层") / employees.Count * 100, 1)
                }
            };
            
            // 计算学历分布
            collectiveProfile.EducationDistribution = new List<EducationDistribution>
            {
                new EducationDistribution
                {
                    Education = "博士",
                    Count = employees.Count(e => e.Education == "博士"),
                    Percentage = Math.Round((double)employees.Count(e => e.Education == "博士") / employees.Count * 100, 1)
                },
                new EducationDistribution
                {
                    Education = "硕士",
                    Count = employees.Count(e => e.Education == "硕士"),
                    Percentage = Math.Round((double)employees.Count(e => e.Education == "硕士") / employees.Count * 100, 1)
                },
                new EducationDistribution
                {
                    Education = "本科",
                    Count = employees.Count(e => e.Education == "本科"),
                    Percentage = Math.Round((double)employees.Count(e => e.Education == "本科") / employees.Count * 100, 1)
                },
                new EducationDistribution
                {
                    Education = "其他",
                    Count = employees.Count(e => e.Education != "博士" && e.Education != "硕士" && e.Education != "本科"),
                    Percentage = Math.Round((double)employees.Count(e => e.Education != "博士" && e.Education != "硕士" && e.Education != "本科") / employees.Count * 100, 1)
                }
            };

            // 计算性别分布
            var maleCount = employees.Count(e => e.Gender == "男");
            var femaleCount = employees.Count(e => e.Gender == "女");
            collectiveProfile.GenderDistribution = new GenderDistribution
            {
                MaleCount = maleCount,
                FemaleCount = femaleCount,
                MalePercentage = Math.Round((double)maleCount / employees.Count * 100, 1),
                FemalePercentage = Math.Round((double)femaleCount / employees.Count * 100, 1)
            };
            
            // 计算明星员工和潜力股
            collectiveProfile.StarEmployees = await _analysisService.GetStarEmployeesAsync(employees);
            collectiveProfile.PotentialEmployees = await _analysisService.GetPotentialEmployeesAsync(employees);
            collectiveProfile.HighPerformanceEmployees = await _analysisService.GetHighPerformanceEmployeesAsync(employees);
            collectiveProfile.UnderperformingEmployees = await _analysisService.GetUnderperformingEmployeesAsync(employees);
            collectiveProfile.AttritionRiskEmployees = await _analysisService.GetAttritionRiskEmployeesAsync(employees);
            
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
            
            // 按综合能力评分排序并只返回前10名员工
            return profiles.OrderByDescending(p => p.OverallScore).Take(10).ToList();
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

        // 添加获取部门集体画像的方法
        public async Task<CollectiveProfileViewModel> GetDepartmentCollectiveProfileAsync(string department)
        {
            // 获取所有员工
            var allEmployees = await _employeeService.GetAllEmployeesAsync();
            
            // 获取指定部门的员工
            var departmentEmployees = allEmployees.Where(e => e.Department == department).ToList();
            
            if (!departmentEmployees.Any())
            {
                return new CollectiveProfileViewModel();
            }
            
            var collectiveProfile = new CollectiveProfileViewModel();
            
            // 计算部门分布 (对于单一部门，将显示该部门占100%)
            collectiveProfile.DepartmentDistribution = new List<DepartmentDistribution>
            {
                new DepartmentDistribution
                {
                    Department = department,
                    Count = departmentEmployees.Count,
                    Percentage = 100.0
                }
            };
            
            // 计算人才稀缺部门和人才冗余部门 (对于单个部门视图，计算在全公司中的占比)
            var departmentIdealRanges = new Dictionary<string, (double Min, double Max)>
            {
                { "技术部", (25, 35) },
                { "设计部", (5, 10) },
                { "市场部", (10, 15) },
                { "产品部", (10, 15) },
                { "运营部", (10, 20) },
                { "销售部", (10, 20) }
            };

            collectiveProfile.TalentShortages = new List<DepartmentTalentStatus>();
            collectiveProfile.TalentSurpluses = new List<DepartmentTalentStatus>();

            if (departmentIdealRanges.TryGetValue(department, out var idealRange))
            {
                // 计算该部门在全公司中的实际占比
                double actualPercentage = Math.Round((double)departmentEmployees.Count / allEmployees.Count * 100, 1);
                
                if (actualPercentage < idealRange.Min)
                {
                    // 人才稀缺
                    var deviation = idealRange.Min - actualPercentage;
                    var status = DetermineTalentShortageStatus(deviation);
                    
                    collectiveProfile.TalentShortages.Add(new DepartmentTalentStatus
                    {
                        Department = department,
                        Status = status,
                        CurrentPercentage = actualPercentage,
                        MinIdealPercentage = idealRange.Min,
                        MaxIdealPercentage = idealRange.Max,
                        Deviation = deviation
                    });
                }
                else if (actualPercentage > idealRange.Max)
                {
                    // 人才冗余
                    var deviation = actualPercentage - idealRange.Max;
                    var status = DetermineTalentSurplusStatus(deviation);
                    
                    collectiveProfile.TalentSurpluses.Add(new DepartmentTalentStatus
                    {
                        Department = department,
                        Status = status,
                        CurrentPercentage = actualPercentage,
                        MinIdealPercentage = idealRange.Min,
                        MaxIdealPercentage = idealRange.Max,
                        Deviation = deviation
                    });
                }
            }

            // 计算年龄分布
            collectiveProfile.AgeDistribution = new List<AgeDistribution>
            {
                new AgeDistribution 
                { 
                    AgeRange = "25以下", 
                    Count = departmentEmployees.Count(e => e.Age < 25),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.Age < 25) / departmentEmployees.Count * 100, 1) : 0
                },
                new AgeDistribution 
                { 
                    AgeRange = "25-35", 
                    Count = departmentEmployees.Count(e => e.Age >= 25 && e.Age <= 35),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.Age >= 25 && e.Age <= 35) / departmentEmployees.Count * 100, 1) : 0
                },
                new AgeDistribution 
                { 
                    AgeRange = "35-45", 
                    Count = departmentEmployees.Count(e => e.Age > 35 && e.Age <= 45),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.Age > 35 && e.Age <= 45) / departmentEmployees.Count * 100, 1) : 0
                },
                new AgeDistribution 
                { 
                    AgeRange = "45以上", 
                    Count = departmentEmployees.Count(e => e.Age > 45),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.Age > 45) / departmentEmployees.Count * 100, 1) : 0
                }
            };
            
            // 计算层级分布
            collectiveProfile.PositionLevelDistribution = new List<PositionLevelDistribution>
            {
                new PositionLevelDistribution
                {
                    Level = "基层",
                    Count = departmentEmployees.Count(e => e.PositionLevel == "基层"),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.PositionLevel == "基层") / departmentEmployees.Count * 100, 1) : 0
                },
                new PositionLevelDistribution
                {
                    Level = "中层",
                    Count = departmentEmployees.Count(e => e.PositionLevel == "中层"),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.PositionLevel == "中层") / departmentEmployees.Count * 100, 1) : 0
                },
                new PositionLevelDistribution
                {
                    Level = "高层",
                    Count = departmentEmployees.Count(e => e.PositionLevel == "高层"),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.PositionLevel == "高层") / departmentEmployees.Count * 100, 1) : 0
                }
            };
            
            // 计算学历分布
            collectiveProfile.EducationDistribution = new List<EducationDistribution>
            {
                new EducationDistribution
                {
                    Education = "博士",
                    Count = departmentEmployees.Count(e => e.Education == "博士"),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.Education == "博士") / departmentEmployees.Count * 100, 1) : 0
                },
                new EducationDistribution
                {
                    Education = "硕士",
                    Count = departmentEmployees.Count(e => e.Education == "硕士"),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.Education == "硕士") / departmentEmployees.Count * 100, 1) : 0
                },
                new EducationDistribution
                {
                    Education = "本科",
                    Count = departmentEmployees.Count(e => e.Education == "本科"),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.Education == "本科") / departmentEmployees.Count * 100, 1) : 0
                },
                new EducationDistribution
                {
                    Education = "其他",
                    Count = departmentEmployees.Count(e => e.Education != "博士" && e.Education != "硕士" && e.Education != "本科"),
                    Percentage = departmentEmployees.Any() ? Math.Round((double)departmentEmployees.Count(e => e.Education != "博士" && e.Education != "硕士" && e.Education != "本科") / departmentEmployees.Count * 100, 1) : 0
                }
            };

            // 计算性别分布
            var maleCount = departmentEmployees.Count(e => e.Gender == "男");
            var femaleCount = departmentEmployees.Count(e => e.Gender == "女");
            collectiveProfile.GenderDistribution = new GenderDistribution
            {
                MaleCount = maleCount,
                FemaleCount = femaleCount,
                MalePercentage = departmentEmployees.Any() ? Math.Round((double)maleCount / departmentEmployees.Count * 100, 1) : 0,
                FemalePercentage = departmentEmployees.Any() ? Math.Round((double)femaleCount / departmentEmployees.Count * 100, 1) : 0
            };
            
            // 计算明星员工和潜力股
            collectiveProfile.StarEmployees = await _analysisService.GetStarEmployeesAsync(departmentEmployees);
            collectiveProfile.PotentialEmployees = await _analysisService.GetPotentialEmployeesAsync(departmentEmployees);
            collectiveProfile.HighPerformanceEmployees = await _analysisService.GetHighPerformanceEmployeesAsync(departmentEmployees);
            collectiveProfile.UnderperformingEmployees = await _analysisService.GetUnderperformingEmployeesAsync(departmentEmployees);
            collectiveProfile.AttritionRiskEmployees = await _analysisService.GetAttritionRiskEmployeesAsync(departmentEmployees);
            
            return collectiveProfile;
        }

        // 辅助方法：根据偏差程度确定人才稀缺状态
        private string DetermineTalentShortageStatus(double deviation)
        {
            if (deviation >= 10) return "极度稀缺";
            if (deviation >= 5) return "稀缺";
            return "较稀缺";
        }
        
        // 辅助方法：根据偏差程度确定人才冗余状态
        private string DetermineTalentSurplusStatus(double deviation)
        {
            if (deviation >= 10) return "极度冗余";
            if (deviation >= 5) return "冗余";
            return "较冗余";
        }
    }
} 