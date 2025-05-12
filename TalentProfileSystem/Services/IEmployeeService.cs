<<<<<<< HEAD
using TalentProfileSystem.Models;

namespace TalentProfileSystem.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetEmployeesByDepartmentAsync(string department);
        Task<List<Employee>> GetHighPerformanceEmployeesAsync();
    }
=======
using TalentProfileSystem.Models;

namespace TalentProfileSystem.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetEmployeesByDepartmentAsync(string department);
        Task<List<Employee>> GetHighPerformanceEmployeesAsync();
    }
>>>>>>> c12aaa8 (first)
} 