using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    public interface ITagService
    {
        Task<List<TagViewModel>> GetEmployeeTagsAsync(Employee employee);
    }
} 