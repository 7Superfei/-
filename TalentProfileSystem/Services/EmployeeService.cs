using Microsoft.EntityFrameworkCore;
using TalentProfileSystem.Data;
using TalentProfileSystem.Models;

namespace TalentProfileSystem.Services
{
    /// <summary>
    /// 员工服务类，负责处理与员工数据相关的操作
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// 构造函数，通过依赖注入获取数据库上下文
        /// </summary>
        /// <param name="context">应用程序数据库上下文</param>
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取所有员工信息，包括相关的考勤记录、职位变更和项目经验
        /// </summary>
        /// <returns>员工列表</returns>
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.AttendanceRecords)
                .Include(e => e.PositionChanges)
                .Include(e => e.ProjectExperiences)
                .ToListAsync();
        }

        /// <summary>
        /// 根据ID获取特定员工信息，包括相关的考勤记录、职位变更和项目经验
        /// </summary>
        /// <param name="id">员工ID</param>
        /// <returns>员工对象，如果未找到则返回null</returns>
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.AttendanceRecords)
                .Include(e => e.PositionChanges)
                .Include(e => e.ProjectExperiences)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        /// <summary>
        /// 根据部门获取员工列表，包括相关的考勤记录、职位变更和项目经验
        /// </summary>
        /// <param name="department">部门名称</param>
        /// <returns>符合条件的员工列表</returns>
        public async Task<List<Employee>> GetEmployeesByDepartmentAsync(string department)
        {
            return await _context.Employees
                .Include(e => e.AttendanceRecords)
                .Include(e => e.PositionChanges)
                .Include(e => e.ProjectExperiences)
                .Where(e => e.Department == department)
                .ToListAsync();
        }

        /// <summary>
        /// 获取绩效优秀的员工列表，定义为任一月份绩效为A或A+的员工
        /// </summary>
        /// <returns>高绩效员工列表</returns>
        public async Task<List<Employee>> GetHighPerformanceEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.AttendanceRecords)
                .Include(e => e.PositionChanges)
                .Include(e => e.ProjectExperiences)
                .Where(e => e.PerformanceMonth1 == "A+" || e.PerformanceMonth1 == "A" || 
                           e.PerformanceMonth2 == "A+" || e.PerformanceMonth2 == "A" || 
                           e.PerformanceMonth3 == "A+" || e.PerformanceMonth3 == "A")
                .ToListAsync();
        }
    }
} 