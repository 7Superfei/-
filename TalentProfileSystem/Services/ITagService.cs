using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    /// <summary>
    /// 标签服务接口，定义与员工标签相关的功能
    /// 负责为员工生成和管理各类标签，用于员工画像的构建
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// 获取指定员工的所有标签
        /// 根据员工属性、经历和绩效等信息生成相应标签
        /// </summary>
        /// <param name="employee">员工实体</param>
        /// <returns>员工标签列表</returns>
        Task<List<TagViewModel>> GetEmployeeTagsAsync(Employee employee);
    }
} 