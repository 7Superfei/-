<<<<<<< HEAD
using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    public interface IAnalysisService
    {
        // 综合能力评分
        Task<double> CalculateOverallScoreAsync(Employee employee);
        
        // 雷达图数据
        Task<RadarChartViewModel> CalculateRadarChartDataAsync(Employee employee);
        
        // 岗位匹配度
        Task<double> CalculateJobMatchScoreAsync(Employee employee);
        
        // 晋升推荐度
        Task<double> CalculatePromotionRecommendationScoreAsync(Employee employee);
        
        // 人才稀缺度
        Task<double> CalculateTalentScarcityScoreAsync(Employee employee);
        
        // 人才保有率
        Task<double> CalculateTalentRetentionScoreAsync(Employee employee);
        
        // 分析人才结构
        Task<List<TalentStructureAnalysis>> AnalyzeTalentStructureAsync(List<Employee> employees);
        
        // 获取突出员工列表
        Task<List<OutstandingEmployeeViewModel>> GetStarEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetPotentialEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetTransferRecommendationsAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetUnderperformingEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetAttritionRiskEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetPromotionRecommendationsAsync(List<Employee> employees);
    }
=======
using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    public interface IAnalysisService
    {
        // 综合能力评分
        Task<double> CalculateOverallScoreAsync(Employee employee);
        
        // 雷达图数据
        Task<RadarChartViewModel> CalculateRadarChartDataAsync(Employee employee);
        
        // 岗位匹配度
        Task<double> CalculateJobMatchScoreAsync(Employee employee);
        
        // 晋升推荐度
        Task<double> CalculatePromotionRecommendationScoreAsync(Employee employee);
        
        // 人才稀缺度
        Task<double> CalculateTalentScarcityScoreAsync(Employee employee);
        
        // 人才保有率
        Task<double> CalculateTalentRetentionScoreAsync(Employee employee);
        
        // 分析人才结构
        Task<List<TalentStructureAnalysis>> AnalyzeTalentStructureAsync(List<Employee> employees);
        
        // 获取突出员工列表
        Task<List<OutstandingEmployeeViewModel>> GetStarEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetPotentialEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetTransferRecommendationsAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetUnderperformingEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetAttritionRiskEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetPromotionRecommendationsAsync(List<Employee> employees);
    }
>>>>>>> c12aaa8 (first)
} 