using TalentProfileSystem.Models;

namespace TalentProfileSystem.Services
{
    /// <summary>
    /// 员工服务接口，定义与员工数据相关的功能
    /// 负责员工数据的查询和管理
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns>员工列表</returns>
        Task<List<Employee>> GetAllEmployeesAsync();
        
        /// <summary>
        /// 根据ID获取特定员工信息
        /// </summary>
        /// <param name="id">员工ID</param>
        /// <returns>员工对象，如未找到则返回null</returns>
        Task<Employee?> GetEmployeeByIdAsync(int id);
        
        /// <summary>
        /// 根据部门获取员工列表
        /// </summary>
        /// <param name="department">部门名称</param>
        /// <returns>指定部门的员工列表</returns>
        Task<List<Employee>> GetEmployeesByDepartmentAsync(string department);
        
        /// <summary>
        /// 获取高绩效员工列表
        /// </summary>
        /// <returns>高绩效员工列表</returns>
        Task<List<Employee>> GetHighPerformanceEmployeesAsync();
    }
} 