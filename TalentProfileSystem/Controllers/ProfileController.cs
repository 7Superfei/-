using Microsoft.AspNetCore.Mvc;
using TalentProfileSystem.Services;
using TalentProfileSystem.Models;
using System.Collections.Generic;

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
        public async Task<IActionResult> Employee(int id = 0)
        {
            // 获取所有员工列表
            var allEmployees = await _employeeService.GetAllEmployeesAsync();
            
            // 如果没有指定ID，默认选择第一个员工
            if (id == 0 && allEmployees.Any())
            {
                id = allEmployees.First().EmployeeId;
            }
            
            var profile = await _profileService.GetEmployeeProfileAsync(id);
            if (profile.EmployeeId == 0)
            {
                return NotFound();
            }
            
            // 将员工列表和当前选中的员工ID传递给视图
            ViewBag.AllEmployees = allEmployees;
            ViewBag.CurrentEmployeeId = id;
            
            return View(profile);
        }
        
        // 高绩效人才池页面 - 现在重定向到集体画像
        public IActionResult HighPerformance()
        {
            // 重定向到集体画像，并设置一个标记以显示高绩效人才池
            return RedirectToAction("Collective", new { showHighPerformance = true });
        }
        
        // 集体画像页面 - 现在包含高绩效人才池数据
        public async Task<IActionResult> Collective(bool showHighPerformance = false)
        {
            var collectiveProfile = await _profileService.GetCollectiveProfileAsync();
            
            // 获取高绩效人才池数据
            var highPerformanceProfiles = await _profileService.GetHighPerformanceProfilesAsync();
            
            // 通过ViewBag传递高绩效人才池数据和显示标记
            ViewBag.HighPerformanceProfiles = highPerformanceProfiles;
            ViewBag.ShowHighPerformance = showHighPerformance;
            
            return View(collectiveProfile);
        }
        
        // 按部门筛选的集体画像
        public async Task<IActionResult> DepartmentCollective(string department)
        {
            var employees = await _employeeService.GetEmployeesByDepartmentAsync(department);
            // 这里应该有对特定部门的集体画像分析，暂时使用全公司的集体画像作为占位
            var collectiveProfile = await _profileService.GetCollectiveProfileAsync();
            
            // 获取该部门的高绩效人才
            var highPerformanceProfiles = await _profileService.GetHighPerformanceProfilesAsync();
            var departmentHighPerformers = highPerformanceProfiles
                .Where(p => p.Department == department)
                .ToList();
                
            ViewBag.HighPerformanceProfiles = departmentHighPerformers;
            ViewBag.ShowHighPerformance = false; // 默认不显示
            
            return View("Collective", collectiveProfile);
        }
    }
} 