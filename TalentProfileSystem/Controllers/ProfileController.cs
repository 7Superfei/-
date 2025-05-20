using Microsoft.AspNetCore.Mvc;
using TalentProfileSystem.Services;
using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;
using System.Collections.Generic;

namespace TalentProfileSystem.Controllers
{
    /// <summary>
    /// 画像控制器，负责处理与员工画像和集体画像相关的请求
    /// </summary>
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// 构造函数，通过依赖注入获取所需服务
        /// </summary>
        /// <param name="profileService">画像服务</param>
        /// <param name="employeeService">员工服务</param>
        public ProfileController(
            IProfileService profileService,
            IEmployeeService employeeService)
        {
            _profileService = profileService;
            _employeeService = employeeService;
        }

        /// <summary>
        /// 个人画像页面
        /// 显示指定员工的画像信息，若未指定员工ID则默认显示第一位员工
        /// </summary>
        /// <param name="id">员工ID，默认值为0表示未指定</param>
        /// <returns>个人画像视图</returns>
        public async Task<IActionResult> Employee(int id = 0)
        {
            // 获取所有员工列表，用于页面上的员工选择下拉菜单
            var allEmployees = await _employeeService.GetAllEmployeesAsync();
            
            // 如果没有指定ID，默认选择第一个员工
            if (id == 0 && allEmployees.Any())
            {
                id = allEmployees.First().EmployeeId;
            }
            
            // 获取指定员工的画像数据
            var profile = await _profileService.GetEmployeeProfileAsync(id);
            if (profile.EmployeeId == 0)
            {
                return NotFound(); // 如果未找到员工，返回404错误
            }
            
            // 将员工列表和当前选中的员工ID传递给视图，用于页面导航
            ViewBag.AllEmployees = allEmployees;
            ViewBag.CurrentEmployeeId = id;
            
            return View(profile);
        }
        
        /// <summary>
        /// 员工详细信息页面
        /// 显示员工的详细信息和画像数据
        /// </summary>
        /// <param name="id">员工ID</param>
        /// <returns>员工详细信息视图</returns>
        public async Task<IActionResult> EmployeeDetails(int id)
        {
            // 获取员工基本信息
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound(); // 如果未找到员工，返回404错误
            }
            
            // 获取员工画像数据
            var profile = await _profileService.GetEmployeeProfileAsync(id);
            
            // 创建详细信息视图模型，包含基本信息和画像数据
            var detailsViewModel = new EmployeeDetailsViewModel
            {
                Employee = employee,
                Profile = profile
            };
            
            return View(detailsViewModel);
        }
        
        /// <summary>
        /// 高绩效人才池页面
        /// 显示所有高绩效员工的画像列表
        /// </summary>
        /// <returns>高绩效人才池视图</returns>
        public async Task<IActionResult> HighPerformance()
        {
            // 获取所有高绩效员工的画像
            var profiles = await _profileService.GetHighPerformanceProfilesAsync();
            return View(profiles);
        }
        
        /// <summary>
        /// 集体画像页面
        /// 显示全公司的集体画像数据
        /// </summary>
        /// <returns>集体画像视图</returns>
        public async Task<IActionResult> Collective()
        {
            // 获取全公司集体画像
            var collectiveProfile = await _profileService.GetCollectiveProfileAsync();
            
            // 获取所有可用部门列表，用于页面上的部门筛选
            var allEmployees = await _employeeService.GetAllEmployeesAsync();
            var departments = allEmployees.Select(e => e.Department).Distinct().ToList();
            ViewBag.AllDepartments = departments;
            
            // 标记当前为全公司视图
            ViewBag.CurrentDepartment = "全公司";
            
            // 将全公司数据存入ViewBag，用于顶部区域显示
            ViewBag.CompanyModel = collectiveProfile;
            
            return View(collectiveProfile);
        }
        
        /// <summary>
        /// 部门集体画像页面
        /// 根据指定部门筛选显示集体画像数据
        /// </summary>
        /// <param name="department">部门名称</param>
        /// <returns>部门集体画像视图</returns>
        public async Task<IActionResult> DepartmentCollective(string department)
        {
            // 首先获取全公司集体画像数据，用于顶部区域显示和对比
            var companyModel = await _profileService.GetCollectiveProfileAsync();
            ViewBag.CompanyModel = companyModel;
            
            // 使用专门的方法获取部门集体画像
            var collectiveProfile = await _profileService.GetDepartmentCollectiveProfileAsync(department);
            
            // 将当前选中的部门传递给视图，用于页面导航
            ViewBag.CurrentDepartment = department;
            
            // 获取所有可用部门列表，用于部门筛选下拉菜单
            var allEmployees = await _employeeService.GetAllEmployeesAsync();
            var departments = allEmployees.Select(e => e.Department).Distinct().ToList();
            ViewBag.AllDepartments = departments;
            
            // 使用与全公司相同的视图，但传递不同的数据
            return View("Collective", collectiveProfile);
        }

        /// <summary>
        /// 突出员工详情页面
        /// 根据指定类别显示对应的突出员工列表
        /// </summary>
        /// <param name="category">员工类别（star：明星员工，potential：潜力股，等）</param>
        /// <returns>突出员工详情视图</returns>
        public async Task<IActionResult> OutstandingEmployees(string category)
        {
            // 获取全公司集体画像
            var collectiveProfile = await _profileService.GetCollectiveProfileAsync();
            
            // 根据类别获取对应的员工列表
            List<OutstandingEmployeeViewModel> employees = category switch
            {
                "star" => collectiveProfile.StarEmployees,
                "potential" => collectiveProfile.PotentialEmployees,
                "highperformance" => collectiveProfile.HighPerformanceEmployees,
                "underperforming" => collectiveProfile.UnderperformingEmployees,
                "attritionrisk" => collectiveProfile.AttritionRiskEmployees,
                _ => new List<OutstandingEmployeeViewModel>()
            };
            
            // 设置页面标题，用于显示在视图中
            ViewBag.CategoryTitle = category switch
            {
                "star" => "明星员工",
                "potential" => "潜力股",
                "highperformance" => "绩效优秀",
                "underperforming" => "表现欠佳",
                "attritionrisk" => "高离职风险",
                _ => "突出员工"
            };
            
            // 将当前类别传递给视图，用于页面导航
            ViewBag.Category = category;
            
            return View(employees);
        }
    }
} 