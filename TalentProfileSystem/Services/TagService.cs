using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;

namespace TalentProfileSystem.Services
{
    public class TagService : ITagService
    {
        // 这个服务将来会实现标签体系的逻辑
        // 目前只提供一个简单的占位实现
        
        public async Task<List<TagViewModel>> GetEmployeeTagsAsync(Employee employee)
        {
            // 为了保持一致性，我们在这里使用与ProfileService中相同的标签生成逻辑
            var tags = new List<TagViewModel>();
            
            // 学历标签
            tags.Add(new TagViewModel
            {
                Name = employee.Education,
                Category = "学历",
                Color = "#4CAF50"
            });
            
            // 院校级别标签
            tags.Add(new TagViewModel
            {
                Name = employee.AcademicLevel,
                Category = "院校",
                Color = "#2196F3"
            });
            
            // 专业标签
            tags.Add(new TagViewModel
            {
                Name = employee.SpecificMajor,
                Category = "专业",
                Color = "#FF9800"
            });
            
            // 性格标签
            tags.Add(new TagViewModel
            {
                Name = employee.PersonalityType,
                Category = "性格",
                Color = "#9C27B0"
            });
            
            // 绩效标签
            if (employee.PerformanceMonth3 == "A+" || employee.PerformanceMonth3 == "A")
            {
                tags.Add(new TagViewModel
                {
                    Name = "绩效优秀",
                    Category = "绩效",
                    Color = "#F44336"
                });
            }
            
            return tags;
        }
    }
} 