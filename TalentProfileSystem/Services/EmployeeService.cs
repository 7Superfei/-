using Microsoft.EntityFrameworkCore;
using TalentProfileSystem.Data;
using TalentProfileSystem.Models;

namespace TalentProfileSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.AttendanceRecords)
                .Include(e => e.PositionChanges)
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.AttendanceRecords)
                .Include(e => e.PositionChanges)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<List<Employee>> GetEmployeesByDepartmentAsync(string department)
        {
            return await _context.Employees
                .Include(e => e.AttendanceRecords)
                .Include(e => e.PositionChanges)
                .Where(e => e.Department == department)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetHighPerformanceEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.AttendanceRecords)
                .Include(e => e.PositionChanges)
                .Where(e => e.PerformanceMonth1 == "A+" || e.PerformanceMonth1 == "A" || 
                           e.PerformanceMonth2 == "A+" || e.PerformanceMonth2 == "A" || 
                           e.PerformanceMonth3 == "A+" || e.PerformanceMonth3 == "A")
                .ToListAsync();
        }
    }
} 