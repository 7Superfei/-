using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    /// <summary>
    /// 分析服务接口，定义与员工数据分析相关的功能
    /// 负责计算各种分析指标和评分，用于员工画像和集体画像的构建
    /// </summary>
    public interface IAnalysisService
    {
        /// <summary>
        /// 计算员工雷达图数据
        /// 评估员工在六个维度（教育背景、关键经验、个人能力、性格特质、工作态度、发展潜力）的得分
        /// </summary>
        /// <param name="employee">员工实体</param>
        /// <returns>雷达图数据视图模型</returns>
        Task<RadarChartViewModel> CalculateRadarChartDataAsync(Employee employee);
        
        /// <summary>
        /// 计算员工综合能力评分
        /// 基于多个维度的综合评估，得出员工的整体能力水平
        /// </summary>
        /// <param name="employee">员工实体</param>
        /// <returns>综合评分（0-100）</returns>
        Task<double> CalculateOverallScoreAsync(Employee employee);
        
        /// <summary>
        /// 计算晋升推荐评分
        /// 评估员工是否适合晋升的可能性
        /// </summary>
        /// <param name="employee">员工实体</param>
        /// <returns>晋升推荐评分（0-100）</returns>
        Task<double> CalculatePromotionRecommendationScoreAsync(Employee employee);
        
        /// <summary>
        /// 计算岗位匹配度评分
        /// 评估员工与当前岗位的匹配程度
        /// </summary>
        /// <param name="employee">员工实体</param>
        /// <returns>岗位匹配度评分（0-100）</returns>
        Task<double> CalculateJobMatchScoreAsync(Employee employee);
        
        /// <summary>
        /// 计算人才稀缺度评分
        /// 评估员工所拥有技能和经验在公司内的稀缺程度
        /// </summary>
        /// <param name="employee">员工实体</param>
        /// <returns>人才稀缺度评分（0-100）</returns>
        Task<double> CalculateTalentScarcityScoreAsync(Employee employee);
        
        /// <summary>
        /// 计算人才保留评分
        /// 评估员工的离职风险和保留重要性
        /// </summary>
        /// <param name="employee">员工实体</param>
        /// <returns>人才保留评分（0-100）</returns>
        Task<double> CalculateTalentRetentionScoreAsync(Employee employee);
        
        // 分析人才结构
        Task<List<TalentStructureAnalysis>> AnalyzeTalentStructureAsync(List<Employee> employees);
        
        // 获取突出员工列表
        Task<List<OutstandingEmployeeViewModel>> GetStarEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetPotentialEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetHighPerformanceEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetTransferRecommendationsAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetUnderperformingEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetAttritionRiskEmployeesAsync(List<Employee> employees);
        Task<List<OutstandingEmployeeViewModel>> GetPromotionRecommendationsAsync(List<Employee> employees);
    }
} 