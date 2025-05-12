<<<<<<< HEAD
using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    public interface IProfileService
    {
        Task<EmployeeProfileViewModel> GetEmployeeProfileAsync(int employeeId);
        Task<CollectiveProfileViewModel> GetCollectiveProfileAsync();
        Task<List<EmployeeProfileViewModel>> GetHighPerformanceProfilesAsync();
    }
=======
using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    public interface IProfileService
    {
        Task<EmployeeProfileViewModel> GetEmployeeProfileAsync(int employeeId);
        Task<CollectiveProfileViewModel> GetCollectiveProfileAsync();
        Task<List<EmployeeProfileViewModel>> GetHighPerformanceProfilesAsync();
    }
>>>>>>> c12aaa8 (first)
} 