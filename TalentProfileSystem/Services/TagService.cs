using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using TalentProfileSystem.Models;
using TalentProfileSystem.Models.ViewModels;
using TalentProfileSystem.Data;

namespace TalentProfileSystem.Services
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext _context;

        public TagService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TagViewModel>> GetEmployeeTagsAsync(Employee employee)
        {
            var tags = new List<TagViewModel>();

            // 添加专业匹配标签
            AddProfessionMatchingTags(employee, tags);

            // 添加学历相关标签
            AddEducationTags(employee, tags);

            // 添加性格标签
            AddPersonalityTags(employee, tags);

            // 添加从业经历标签
            AddWorkExperienceTags(employee, tags);

            // 添加项目资历标签
            AddProjectExperienceTags(employee, tags);

            // 添加绩效表现标签
            AddPerformanceTags(employee, tags);

            // 添加考勤纪律标签
            AddAttendanceTags(employee, tags);

            // 添加多源数据组合标签（部门特有标签）
            AddDepartmentSpecificTags(employee, tags);

            // 添加通用多源数据标签
            AddGeneralCombinationTags(employee, tags);

            return tags;
        }

        #region 专业匹配标签
        private void AddProfessionMatchingTags(Employee employee, List<TagViewModel> tags)
        {
            // 获取员工所在部门的专业需求
            var directMatch = IsProfessionDirectMatch(employee.Department, employee.SpecificMajor);
            var generalMatch = IsProfessionGeneralMatch(employee.Department, employee.MajorCategory);
            
            if (directMatch)
            {
                tags.Add(new TagViewModel
                {
                    Name = "专业对口",
                    Category = "专业背景",
                    Color = "#4CAF50" // 绿色
                });
            }
            else if (generalMatch)
            {
                tags.Add(new TagViewModel
                {
                    Name = "专业泛相关",
                    Category = "专业背景",
                    Color = "#8BC34A" // 浅绿色
                });
            }
            else
            {
                tags.Add(new TagViewModel
                {
                    Name = "专业脱节",
                    Category = "专业背景",
                    Color = "#FFC107" // 黄色
                });
            }
        }

        private bool IsProfessionDirectMatch(string department, string major)
        {
            // 技术部
            if (department == "技术部" && new[] { 
                "计算机科学与技术", "软件工程", "人工智能", "大数据技术", 
                "物联网工程", "网络工程", "网络安全", "电子信息工程", 
                "通信工程", "数据科学与大数据技术", "区块链工程",
                "数学与应用数学", "信息与计算科学", "统计学", "应用统计学"
            }.Contains(major))
            {
                return true;
            }
            
            // 设计部
            if (department == "设计部" && new[] { 
                "广告学", "传播学", "艺术设计", "工业设计", "建筑学", "城乡规划"
            }.Contains(major))
            {
                return true;
            }
            
            // 市场部
            if (department == "市场部" && new[] { 
                "新闻学", "传播学", "广告学", "市场营销", "社会学", "心理学", "应用心理学"
            }.Contains(major))
            {
                return true;
            }
            
            // 产品部
            if (department == "产品部" && new[] { 
                "计算机科学与技术", "软件工程", "管理学", "法学", "数据科学", "传播学"
            }.Contains(major))
            {
                return true;
            }
            
            // 运营部
            if (department == "运营部" && new[] { 
                "教育学", "教育技术学", "管理学", "新闻学", "传播学", 
                "统计学", "应用心理学", "大数据技术", "网络工程"
            }.Contains(major))
            {
                return true;
            }
            
            // 销售部
            if (department == "销售部" && new[] { 
                "法学", "社会学", "政治学", "管理学", "心理学"
            }.Contains(major))
            {
                return true;
            }
            
            return false;
        }

        private bool IsProfessionGeneralMatch(string department, string majorCategory)
        {
            // 技术部
            if (department == "技术部" && new[] { "工科", "理科" }.Contains(majorCategory))
            {
                return true;
            }
            
            // 设计部
            if (department == "设计部" && new[] { "文科", "工科" }.Contains(majorCategory))
            {
                return true;
            }
            
            // 市场部
            if (department == "市场部" && new[] { "文科", "理科" }.Contains(majorCategory))
            {
                return true;
            }
            
            // 产品部
            if (department == "产品部" && new[] { "工科", "理科" }.Contains(majorCategory))
            {
                return true;
            }
            
            // 运营部
            if (department == "运营部" && (majorCategory == "文科" || 
                (majorCategory == "理科" || majorCategory == "工科")))
            {
                return true;
            }
            
            // 销售部
            if (department == "销售部" && new[] { "文科", "理科" }.Contains(majorCategory))
            {
                return true;
            }
            
            return false;
        }
        #endregion

        #region 学历标签
        private void AddEducationTags(Employee employee, List<TagViewModel> tags)
        {
            var is985211 = employee.AcademicLevel == "985" || employee.AcademicLevel == "211";
            var isBachelor = employee.Education == "本科" || employee.Education == "硕士" || employee.Education == "博士";
            var isProfessionMatch = IsProfessionDirectMatch(employee.Department, employee.SpecificMajor);
            
            if (is985211 && isBachelor)
            {
                tags.Add(new TagViewModel
                {
                    Name = "高材生",
                    Category = "学历",
                    Color = "#2196F3" // 蓝色
                });
            }
            else if (!is985211 && isProfessionMatch)
            {
                tags.Add(new TagViewModel
                {
                    Name = "科班基础",
                    Category = "学历",
                    Color = "#03A9F4" // 浅蓝色
                });
            }
            else if (!is985211 && !isProfessionMatch)
            {
                tags.Add(new TagViewModel
                {
                    Name = "学历短板",
                    Category = "学历",
                    Color = "#FF9800" // 橙色
                });
            }
        }
        #endregion

        #region 性格标签
        private void AddPersonalityTags(Employee employee, List<TagViewModel> tags)
        {
            if (!string.IsNullOrEmpty(employee.PersonalityType))
            {
                var personalityDescription = GetPersonalityDescription(employee.PersonalityType);
                
                if (!string.IsNullOrEmpty(personalityDescription))
                {
                    tags.Add(new TagViewModel
                    {
                        Name = personalityDescription,
                        Category = "性格特点",
                        Color = "#9C27B0" // 紫色
                    });
                }
            }
        }
        
        private string GetPersonalityDescription(string mbtiType)
        {
            return mbtiType.ToUpper() switch
            {
                "ISTJ" => "责任感强",
                "ISFJ" => "无私奉献",
                "INFJ" => "理想主义",
                "INTJ" => "战略思想家",
                "ISTP" => "灵活变通",
                "ISFP" => "艺术敏感",
                "INFP" => "温和理想家",
                "INTP" => "逻辑思考者",
                "ESTP" => "冒险实干",
                "ESFP" => "活力四射",
                "ENFP" => "热情创新",
                "ENTP" => "思维开放",
                "ESTJ" => "执行管理",
                "ESFJ" => "热心社交",
                "ENFJ" => "人际影响",
                "ENTJ" => "果断领导",
                _ => "" // 默认返回空字符串
            };
        }
        #endregion

        #region 从业经历标签
        private void AddWorkExperienceTags(Employee employee, List<TagViewModel> tags)
        {
            var isCompanyMatch = IsCompanyTypeMatch(employee.CompanyType);
            var isDepartmentMatch = true; // 假设当前部门与现在相同
            
            if (isCompanyMatch && isDepartmentMatch && employee.WorkYears >= 3)
            {
                tags.Add(new TagViewModel
                {
                    Name = "行业资深",
                    Category = "从业经历",
                    Color = "#673AB7" // 深紫色
                });
            }
            else if ((isCompanyMatch || isDepartmentMatch) && employee.WorkYears >= 2)
            {
                tags.Add(new TagViewModel
                {
                    Name = "经验适中",
                    Category = "从业经历",
                    Color = "#9C27B0" // 紫色
                });
            }
            else
            {
                tags.Add(new TagViewModel
                {
                    Name = "初出茅庐",
                    Category = "从业经历",
                    Color = "#E1BEE7" // 浅紫色
                });
            }
        }
        
        private bool IsCompanyTypeMatch(string companyType)
        {
            var matchingTypes = new[] { 
                "互联网科技公司", "软件科技公司", "数字内容创作公司", "互联网金融公司" 
            };
            
            return matchingTypes.Contains(companyType);
        }
        #endregion

        #region 项目资历标签
        private void AddProjectExperienceTags(Employee employee, List<TagViewModel> tags)
        {
            bool hasProjectExperience = HasProjectExperience(employee);
            
            if (IsCoreProjectMember(employee))
            {
                tags.Add(new TagViewModel
                {
                    Name = "核心骨干",
                    Category = "项目经历",
                    Color = "#E91E63" // 深粉色
                });
            }
            else if (IsProjectExpert(employee))
            {
                tags.Add(new TagViewModel
                {
                    Name = "项目熟手",
                    Category = "项目经历",
                    Color = "#F06292" // 粉色
                });
            }
            else if (hasProjectExperience)
            {
                tags.Add(new TagViewModel
                {
                    Name = "项目新手",
                    Category = "项目经历",
                    Color = "#EC407A" // 浅粉色
                });
            }
            else
            {
                tags.Add(new TagViewModel
                {
                    Name = "片叶不沾",
                    Category = "项目经历",
                    Color = "#FCE4EC" // 超浅粉色
                });
            }
        }
        
        // 核心骨干：两次及以上担任重点项目的高层
        private bool IsCoreProjectMember(Employee employee)
        {
            // 判断是否有两次及以上担任重点项目的高层经历
            var keyHighLevelProjects = employee.ProjectExperiences.Where(p => 
                p.ProjectLevel == "重点项目" && 
                IsHighLevelRole(p.ProjectRole)
            ).Count();
            
            return keyHighLevelProjects >= 2;
        }

        // 项目熟手：两次一般项目高层或重点项目中层
        private bool IsProjectExpert(Employee employee)
        {
            // 一般项目的高层角色数量
            var generalHighLevelProjects = employee.ProjectExperiences.Where(p => 
                p.ProjectLevel == "一般项目" && 
                IsHighLevelRole(p.ProjectRole)
            ).Count();
            
            // 重点项目的中层角色数量
            var keyMidLevelProjects = employee.ProjectExperiences.Where(p => 
                p.ProjectLevel == "重点项目" && 
                IsMidLevelRole(p.ProjectRole)
            ).Count();
            
            return generalHighLevelProjects >= 2 || keyMidLevelProjects >= 2;
        }

        // 判断是否为高层角色
        private bool IsHighLevelRole(string projectRole)
        {
            return projectRole == "项目总负责人" || projectRole == "技术或业务顾问";
        }

        // 判断是否为中层角色
        private bool IsMidLevelRole(string projectRole)
        {
            return projectRole == "项目经理" || projectRole == "团队负责人" || 
                   projectRole == "技术或业务专家";
        }
        
        private bool HasProjectExperience(Employee employee)
        {
            // 判断是否有项目经历
            return employee.ProjectExperiences.Count > 0;
        }
        #endregion

        #region 绩效表现标签
        private void AddPerformanceTags(Employee employee, List<TagViewModel> tags)
        {
            var recentPerformances = new[] { 
                employee.PerformanceMonth1, 
                employee.PerformanceMonth2, 
                employee.PerformanceMonth3 
            };
            
            var mostRecentPerformance = employee.PerformanceMonth3;
            
            // 金牌员工：近三个月绩效全为A及以上
            if (recentPerformances.All(p => p == "A+" || p == "A"))
            {
                tags.Add(new TagViewModel
                {
                    Name = "金牌员工",
                    Category = "绩效表现",
                    Color = "#FFC107" // 金色
                });
            }
            
            // 绩效标兵：近一个月绩效评级A+
            if (mostRecentPerformance == "A+")
            {
                tags.Add(new TagViewModel
                {
                    Name = "绩效标兵",
                    Category = "绩效表现",
                    Color = "#FFEB3B" // 黄色
                });
            }
            
            // 绩效达标：近一个月评级A-/B+
            if (mostRecentPerformance == "A-" || mostRecentPerformance == "B+")
            {
                tags.Add(new TagViewModel
                {
                    Name = "绩效达标",
                    Category = "绩效表现",
                    Color = "#CDDC39" // 酸橙色
                });
            }
            
            // 绩效滞后：近一个月评级B及以下
            if (mostRecentPerformance == "B" || 
                mostRecentPerformance == "B-" || 
                mostRecentPerformance == "C" || 
                mostRecentPerformance == "D")
            {
                tags.Add(new TagViewModel
                {
                    Name = "绩效滞后",
                    Category = "绩效表现",
                    Color = "#FF5722" // 深橙色
                });
            }
            
            // 宝藏员工：近三个月评级递增且最近一个月评级为A及以上
            var performanceValues = GetPerformanceValues(recentPerformances);
            if (performanceValues.Count == 3 && 
                performanceValues[0] < performanceValues[1] && 
                performanceValues[1] < performanceValues[2] && 
                (mostRecentPerformance == "A+" || mostRecentPerformance == "A"))
            {
                tags.Add(new TagViewModel
                {
                    Name = "宝藏员工",
                    Category = "绩效表现",
                    Color = "#FFAB00" // 琥珀色
                });
            }
        }
        
        private List<int> GetPerformanceValues(string[] performances)
        {
            var result = new List<int>();
            
            foreach (var performance in performances)
            {
                switch (performance)
                {
                    case "A+": result.Add(5); break;
                    case "A": result.Add(4); break;
                    case "A-": result.Add(3); break;
                    case "B+": result.Add(2); break;
                    case "B": result.Add(1); break;
                    case "B-": result.Add(0); break;
                    case "C": result.Add(-1); break;
                    case "D": result.Add(-2); break;
                    default: break; // 无法解析的绩效不添加
                }
            }
            
            return result;
        }
        #endregion

        #region 考勤纪律标签
        private void AddAttendanceTags(Employee employee, List<TagViewModel> tags)
        {
            // 获取员工最近一个月的考勤记录
            var attendanceRecords = _context.AttendanceRecords
                .Where(a => a.EmployeeId == employee.EmployeeId)
                .OrderByDescending(a => a.Date)
                .Take(30) // 假设一个月大约30天
                .ToList();
            
            if (attendanceRecords.Count > 0)
            {
                var lateCount = attendanceRecords.Count(a => a.Status == "迟到");
                var earlyLeaveCount = attendanceRecords.Count(a => a.Status == "早退");
                var bothLateAndLeaveCount = attendanceRecords.Count(a => a.Status == "迟到且早退");
                var leaveCount = attendanceRecords.Count(a => a.Status == "请假");
                var abnormalCount = lateCount + earlyLeaveCount + bothLateAndLeaveCount + leaveCount;
                
                if (abnormalCount == 0)
                {
                    tags.Add(new TagViewModel
                    {
                        Name = "全勤模范",
                        Category = "考勤纪律",
                        Color = "#00BCD4" // 青色
                    });
                }
                else if (abnormalCount <= 2 && bothLateAndLeaveCount == 0)
                {
                    tags.Add(new TagViewModel
                    {
                        Name = "考勤正常",
                        Category = "考勤纪律",
                        Color = "#80DEEA" // 浅青色
                    });
                }
                else
                {
                    tags.Add(new TagViewModel
                    {
                        Name = "纪律散漫",
                        Category = "考勤纪律",
                        Color = "#FF9800" // 橙色
                    });
                }
            }
        }
        #endregion

        #region 多源数据组合标签
        private void AddDepartmentSpecificTags(Employee employee, List<TagViewModel> tags)
        {
            // 技术部门-专业技术精湛：985/211+专业对口+相关岗位从业3年
            if (employee.Department == "技术部" && 
                (employee.AcademicLevel == "985" || employee.AcademicLevel == "211") && 
                IsProfessionDirectMatch(employee.Department, employee.SpecificMajor) && 
                employee.WorkYears >= 3)
            {
                tags.Add(new TagViewModel
                {
                    Name = "专业技术精湛",
                    Category = "综合标签",
                    Color = "#3F51B5" // 靛蓝色
                });
            }
            
            // 设计部门特有-创意先锋：专业对口+有相关岗位经验+重点项目高层
            if (employee.Department == "设计部" && 
                IsProfessionDirectMatch(employee.Department, employee.SpecificMajor) && 
                employee.WorkYears > 0 && 
                employee.ProjectExperiences.Any(p => 
                    p.ProjectLevel == "重点项目" && 
                    IsHighLevelRole(p.ProjectRole)))
            {
                tags.Add(new TagViewModel
                {
                    Name = "创意先锋",
                    Category = "综合标签",
                    Color = "#E91E63" // 粉红色
                });
            }
            
            // 市场部门特有-市场操盘手：专业对口+相关岗位从业3年+绩效A+
            if (employee.Department == "市场部" && 
                IsProfessionDirectMatch(employee.Department, employee.SpecificMajor) && 
                employee.WorkYears >= 3 && 
                employee.PerformanceMonth3 == "A+")
            {
                tags.Add(new TagViewModel
                {
                    Name = "市场操盘手",
                    Category = "综合标签",
                    Color = "#009688" // 青色
                });
            }
            
            // 运营部门特有-运营老炮：专业对口+相关岗位和工龄之和5年+绩效A及以上
            if (employee.Department == "运营部" && 
                IsProfessionDirectMatch(employee.Department, employee.SpecificMajor) && 
                (employee.WorkYears >= 5) && 
                (employee.PerformanceMonth3 == "A+" || employee.PerformanceMonth3 == "A"))
            {
                tags.Add(new TagViewModel
                {
                    Name = "运营老炮",
                    Category = "综合标签",
                    Color = "#FF5722" // 深橙色
                });
            }
            
            // 产品部门特有-战略型产品人：专业对口+相关岗位和工龄之和5年+重点项目高层
            if (employee.Department == "产品部" && 
                IsProfessionDirectMatch(employee.Department, employee.SpecificMajor) && 
                (employee.WorkYears >= 5) && 
                employee.ProjectExperiences.Any(p => 
                    p.ProjectLevel == "重点项目" && 
                    IsHighLevelRole(p.ProjectRole)))
            {
                tags.Add(new TagViewModel
                {
                    Name = "战略型产品人",
                    Category = "综合标签",
                    Color = "#795548" // 棕色
                });
            }
            
            // 销售部门特有-销售战神：专业对口+绩效A++全勤
            if (employee.Department == "销售部" && 
                IsProfessionDirectMatch(employee.Department, employee.SpecificMajor) && 
                employee.PerformanceMonth3 == "A+")
            {
                // 检查是否全勤
                var attendanceRecords = _context.AttendanceRecords
                    .Where(a => a.EmployeeId == employee.EmployeeId)
                    .OrderByDescending(a => a.Date)
                    .Take(30) // 假设一个月大约30天
                    .ToList();
                
                bool isFullAttendance = attendanceRecords.Count > 0 && 
                                       attendanceRecords.All(a => a.Status == "正常");
                
                if (isFullAttendance)
                {
                    tags.Add(new TagViewModel
                    {
                        Name = "销售战神",
                        Category = "综合标签",
                        Color = "#F44336" // 红色
                    });
                }
            }
        }
        
        private void AddGeneralCombinationTags(Employee employee, List<TagViewModel> tags)
        {
            // 潜力股：985/211硕士+专业对口+工龄两年
            if ((employee.AcademicLevel == "985" || employee.AcademicLevel == "211") && 
                employee.Education == "硕士" && 
                IsProfessionDirectMatch(employee.Department, employee.SpecificMajor) && 
                employee.WorkYears <= 2)
            {
                tags.Add(new TagViewModel
                {
                    Name = "潜力股",
                    Category = "综合标签",
                    Color = "#4CAF50" // 绿色
                });
            }
            
            // 明日之星：绩效A++工龄两年及以下
            if (employee.PerformanceMonth3 == "A+" && employee.WorkYears <= 2)
            {
                tags.Add(new TagViewModel
                {
                    Name = "明日之星",
                    Category = "综合标签",
                    Color = "#FFEB3B" // 黄色
                });
            }
            
            // 复合型人才：双专业背景+跨部门岗位经历+绩效A及以上
            bool hasDualMajor = !string.IsNullOrEmpty(employee.SecondSpecificMajor);
            bool hasCrossDepartmentExperience = true; // 假设员工有跨部门经历
            bool hasGoodPerformance = employee.PerformanceMonth3 == "A+" || employee.PerformanceMonth3 == "A";
            
            if (hasDualMajor && hasCrossDepartmentExperience && hasGoodPerformance)
            {
                tags.Add(new TagViewModel
                {
                    Name = "复合型人才",
                    Category = "综合标签",
                    Color = "#9C27B0" // 紫色
                });
            }
            
            // 摸鱼嫌疑：全勤+绩效B及以下+无项目
            bool hasLowPerformance = employee.PerformanceMonth3 == "B" || 
                                    employee.PerformanceMonth3 == "B-" || 
                                    employee.PerformanceMonth3 == "C" || 
                                    employee.PerformanceMonth3 == "D";
            bool hasNoProjectExperience = employee.ProjectExperiences.Count == 0;
            
            // 检查是否全勤
            var attendanceRecords = _context.AttendanceRecords
                .Where(a => a.EmployeeId == employee.EmployeeId)
                .OrderByDescending(a => a.Date)
                .Take(30)
                .ToList();
            
            bool isFullAttendance = attendanceRecords.Count > 0 && 
                                  !attendanceRecords.Any(a => a.Status != "正常");
            
            if (isFullAttendance && hasLowPerformance && hasNoProjectExperience)
            {
                tags.Add(new TagViewModel
                {
                    Name = "摸鱼嫌疑",
                    Category = "综合标签",
                    Color = "#FF9800" // 橙色
                });
            }
            
            // 人岗不匹配：专业脱节+非相关岗位从业2年+绩效B及以下
            bool isProfessionMismatch = !IsProfessionDirectMatch(employee.Department, employee.SpecificMajor) && 
                                       !IsProfessionGeneralMatch(employee.Department, employee.MajorCategory);
            bool hasWorkExperience = employee.WorkYears >= 2;
            
            if (isProfessionMismatch && hasWorkExperience && hasLowPerformance)
            {
                tags.Add(new TagViewModel
                {
                    Name = "人岗不匹配",
                    Category = "综合标签",
                    Color = "#F44336" // 红色
                });
            }
            
            // 经验固化：工龄8+且岗位无变化+无重点项目经历
            bool hasNoPositionChange = employee.PositionChanges.Count == 0;
            bool hasNoKeyProjectExperience = !employee.ProjectExperiences.Any(p => p.ProjectLevel == "重点项目");

            if (employee.WorkYears >= 8 && hasNoPositionChange && hasNoKeyProjectExperience)
            {
                tags.Add(new TagViewModel
                {
                    Name = "经验固化",
                    Category = "发展风险",
                    Color = "#F44336"
                });
            }
            
            // 协作黑洞：MBTI与岗位不适配+投诉3次及以上
            // 此处需要更多数据支持，暂不实现
            
            // 问题员工：学历短板+专业脱节+绩效C+纪律散漫
            bool hasEducationShortcoming = !((employee.AcademicLevel == "985" || employee.AcademicLevel == "211") && 
                                          (employee.Education == "本科" || employee.Education == "硕士" || employee.Education == "博士")) && 
                                          !IsProfessionDirectMatch(employee.Department, employee.SpecificMajor);
            bool hasBadPerformance = employee.PerformanceMonth3 == "C" || employee.PerformanceMonth3 == "D";
            bool hasDisciplineIssue = attendanceRecords.Count > 0 && 
                                     (attendanceRecords.Count(a => a.Status == "迟到") > 2 || 
                                      attendanceRecords.Any(a => a.Status == "早退"));
            
            if (hasEducationShortcoming && isProfessionMismatch && hasBadPerformance && hasDisciplineIssue)
            {
                tags.Add(new TagViewModel
                {
                    Name = "问题员工",
                    Category = "综合标签",
                    Color = "#D32F2F" // 深红色
                });
            }
            
            // 快速成长型：工龄2年及以下+近三个月绩效不断提升
            if (employee.WorkYears <= 2)
            {
                var performanceValues = GetPerformanceValues(new[] { 
                    employee.PerformanceMonth1, 
                    employee.PerformanceMonth2, 
                    employee.PerformanceMonth3 
                });
                
                if (performanceValues.Count == 3 && 
                    performanceValues[0] < performanceValues[1] && 
                    performanceValues[1] < performanceValues[2])
                {
                    tags.Add(new TagViewModel
                    {
                        Name = "快速成长型",
                        Category = "综合标签",
                        Color = "#8BC34A" // 浅绿色
                    });
                }
            }
        }
        #endregion
    }
} 