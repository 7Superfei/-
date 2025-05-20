using Microsoft.EntityFrameworkCore;
using TalentProfileSystem.Models;

namespace TalentProfileSystem.Data
{
    /// <summary>
    /// 应用程序数据库上下文类，继承自EF Core的DbContext
    /// 负责与数据库交互并管理实体关系
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 构造函数，通过依赖注入接收DbContext配置选项
        /// </summary>
        /// <param name="options">数据库上下文配置选项</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 员工实体集合
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        
        /// <summary>
        /// 考勤记录实体集合
        /// </summary>
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        
        /// <summary>
        /// 职位变更实体集合
        /// </summary>
        public DbSet<PositionChange> PositionChanges { get; set; }
        
        /// <summary>
        /// 项目经验实体集合
        /// </summary>
        public DbSet<ProjectExperience> ProjectExperiences { get; set; }

        /// <summary>
        /// 重写OnModelCreating方法，配置实体关系和约束
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置Employee实体
            modelBuilder.Entity<Employee>(entity =>
            {
                // 设置主键
                entity.HasKey(e => e.EmployeeId);
                // 设置主键为自增长
                entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
                // 设置必填字段
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.Phone).IsRequired();
                
                // 配置与考勤记录的一对多关系
                entity.HasMany(e => e.AttendanceRecords)
                      .WithOne(a => a.Employee)  // 考勤记录与员工的多对一关系
                      .HasForeignKey(a => a.EmployeeId)  // 外键为EmployeeId
                      .OnDelete(DeleteBehavior.Cascade);  // 级联删除
                
                // 配置与职位变更的一对多关系
                entity.HasMany(e => e.PositionChanges)
                      .WithOne(p => p.Employee)  // 职位变更与员工的多对一关系
                      .HasForeignKey(p => p.EmployeeId)  // 外键为EmployeeId
                      .OnDelete(DeleteBehavior.Cascade);  // 级联删除
                
                // 配置与项目经验的一对多关系
                entity.HasMany(e => e.ProjectExperiences)
                      .WithOne(p => p.Employee)  // 项目经验与员工的多对一关系
                      .HasForeignKey(p => p.EmployeeId)  // 外键为EmployeeId
                      .OnDelete(DeleteBehavior.Cascade);  // 级联删除
            });

            // 配置AttendanceRecord实体
            modelBuilder.Entity<AttendanceRecord>(entity =>
            {
                // 设置主键
                entity.HasKey(a => a.RecordId);
                // 设置主键为自增长
                entity.Property(a => a.RecordId).ValueGeneratedOnAdd();
                // 设置必填字段
                entity.Property(a => a.Status).IsRequired();
            });

            // 配置PositionChange实体
            modelBuilder.Entity<PositionChange>(entity =>
            {
                // 设置主键
                entity.HasKey(p => p.ChangeId);
                // 设置主键为自增长
                entity.Property(p => p.ChangeId).ValueGeneratedOnAdd();
                // 设置必填字段
                entity.Property(p => p.PositionChangeDescription).IsRequired();
            });
            
            // 配置ProjectExperience实体
            modelBuilder.Entity<ProjectExperience>(entity =>
            {
                // 设置主键
                entity.HasKey(p => p.ExperienceId);
                // 设置主键为自增长
                entity.Property(p => p.ExperienceId).ValueGeneratedOnAdd();
                // 设置必填字段
                entity.Property(p => p.ProjectLevel).IsRequired();
                entity.Property(p => p.ProjectRole).IsRequired();
            });
        }
    }
} 