using Microsoft.AspNetCore.Mvc;
using TalentProfileSystem.Services;

namespace TalentProfileSystem.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IEmployeeService _employeeService;

        public ProfileController(
            IProfileService profileService,
            IEmployeeService employeeService)
        {
            _profileService = profileService;
            _employeeService = employeeService;
        }

        // 个人画像页面
        public async Task<IActionResult> Employee(int id)
        {
            var profile = await _profileService.GetEmployeeProfileAsync(id);
            if (profile.EmployeeId == 0)
            {
                return NotFound();
            }
            
            return View(profile);
        }
        
        // 高绩效人才池页面
        public async Task<IActionResult> HighPerformance()
        {
            var profiles = await _profileService.GetHighPerformanceProfilesAsync();
            return View(profiles);
        }
        
        // 集体画像页面
        public async Task<IActionResult> Collective()
        {
            var collectiveProfile = await _profileService.GetCollectiveProfileAsync();
            return View(collectiveProfile);
        }
        
        // 按部门筛选的集体画像
        public async Task<IActionResult> DepartmentCollective(string department)
        {
            var employees = await _employeeService.GetEmployeesByDepartmentAsync(department);
            // 这里应该有对特定部门的集体画像分析，暂时使用全公司的集体画像作为占位
            var collectiveProfile = await _profileService.GetCollectiveProfileAsync();
            return View("Collective", collectiveProfile);
        }
    }
} 