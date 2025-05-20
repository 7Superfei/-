using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    /// <summary>
    /// 画像服务接口，定义与个人画像和集体画像相关的功能
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// 获取指定员工的个人画像
        /// </summary>
        /// <param name="employeeId">员工ID</param>
        /// <returns>员工个人画像视图模型</returns>
        Task<EmployeeProfileViewModel> GetEmployeeProfileAsync(int employeeId);
        
        /// <summary>
        /// 获取全公司的集体画像
        /// </summary>
        /// <returns>集体画像视图模型</returns>
        Task<CollectiveProfileViewModel> GetCollectiveProfileAsync();
        
        /// <summary>
        /// 获取指定部门的集体画像
        /// </summary>
        /// <param name="department">部门名称</param>
        /// <returns>部门集体画像视图模型</returns>
        Task<CollectiveProfileViewModel> GetDepartmentCollectiveProfileAsync(string department);
        
        /// <summary>
        /// 获取所有高绩效员工的画像列表
        /// </summary>
        /// <returns>高绩效员工画像列表</returns>
        Task<List<EmployeeProfileViewModel>> GetHighPerformanceProfilesAsync();
    }
} 