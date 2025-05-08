using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    public class AnalysisService : IAnalysisService
    {
        // 这个服务将来会实现各种分析算法
        // 目前只提供简单的占位实现，未来会根据具体的评分算法和分析规则完善
        
        public async Task<double> CalculateOverallScoreAsync(Employee employee)
        {
            // 综合能力评分算法占位实现
            return 80.0;
        }
        
        public async Task<RadarChartViewModel> CalculateRadarChartDataAsync(Employee employee)
        {
            // 雷达图数据计算算法占位实现
            return new RadarChartViewModel
            {
                EducationBackground = 75.0,
                KeyExperience = 80.0,
                PersonalAbility = 85.0,
                PersonalityTrait = 70.0,
                WorkAttitude = 90.0,
                DevelopmentPotential = 80.0
            };
        }
        
        public async Task<double> CalculateJobMatchScoreAsync(Employee employee)
        {
            // 岗位匹配度计算算法占位实现
            return 85.0;
        }
        
        public async Task<double> CalculatePromotionRecommendationScoreAsync(Employee employee)
        {
            // 晋升推荐度计算算法占位实现
            return 75.0;
        }
        
        public async Task<double> CalculateTalentScarcityScoreAsync(Employee employee)
        {
            // 人才稀缺度计算算法占位实现
            return 70.0;
        }
        
        public async Task<double> CalculateTalentRetentionScoreAsync(Employee employee)
        {
            // 人才保有率计算算法占位实现
            return 80.0;
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
            // 明星员工识别算法占位实现
            var result = new List<OutstandingEmployeeViewModel>();
            
            // 简单示例：绩效连续两个月A+的员工
            foreach (var employee in employees)
            {
                if ((employee.PerformanceMonth2 == "A+" && employee.PerformanceMonth3 == "A+") ||
                   (employee.PerformanceMonth1 == "A+" && employee.PerformanceMonth2 == "A+"))
                {
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = 95.0
                    });
                }
            }
            
            return result;
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetPotentialEmployeesAsync(List<Employee> employees)
        {
            // 潜力股识别算法占位实现
            var result = new List<OutstandingEmployeeViewModel>();
            
            // 简单示例：职级为基层但绩效提升明显的员工
            foreach (var employee in employees)
            {
                if (employee.PositionLevel == "基层" && 
                    ConvertPerformanceToValue(employee.PerformanceMonth3) > ConvertPerformanceToValue(employee.PerformanceMonth1))
                {
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = 85.0
                    });
                }
            }
            
            return result;
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetTransferRecommendationsAsync(List<Employee> employees)
        {
            // 调职推荐算法占位实现
            return new List<OutstandingEmployeeViewModel>();
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetUnderperformingEmployeesAsync(List<Employee> employees)
        {
            // 表现欠佳员工识别算法占位实现
            var result = new List<OutstandingEmployeeViewModel>();
            
            // 简单示例：连续两个月绩效为C的员工
            foreach (var employee in employees)
            {
                if ((employee.PerformanceMonth2 == "C" && employee.PerformanceMonth3 == "C") ||
                   (employee.PerformanceMonth1 == "C" && employee.PerformanceMonth2 == "C"))
                {
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = 40.0
                    });
                }
            }
            
            return result;
        }
        
        public async Task<List<OutstandingEmployeeViewModel>> GetAttritionRiskEmployeesAsync(List<Employee> employees)
        {
            // 离职风险识别算法占位实现
            var result = new List<OutstandingEmployeeViewModel>();
            
            // 简单示例：薪资满意度较差且绩效较好的员工
            foreach (var employee in employees)
            {
                if (employee.SalarySatisfaction == "较差" && 
                    (employee.PerformanceMonth3 == "A+" || employee.PerformanceMonth3 == "A"))
                {
                    result.Add(new OutstandingEmployeeViewModel
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Department = employee.Department,
                        PositionLevel = employee.PositionLevel,
                        Score = 75.0
                    });
                }
            }
            
            return result;
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
    }
} 