using Microsoft.EntityFrameworkCore;
using TalentProfileSystem.Models;

namespace TalentProfileSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<PositionChange> PositionChanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置Employee实体
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
                entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.Phone).IsRequired();
                
                // 设置导航属性关系
                entity.HasMany(e => e.AttendanceRecords)
                      .WithOne(a => a.Employee)
                      .HasForeignKey(a => a.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasMany(e => e.PositionChanges)
                      .WithOne(p => p.Employee)
                      .HasForeignKey(p => p.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // 配置AttendanceRecord实体
            modelBuilder.Entity<AttendanceRecord>(entity =>
            {
                entity.HasKey(a => a.RecordId);
                entity.Property(a => a.RecordId).ValueGeneratedOnAdd();
                entity.Property(a => a.Status).IsRequired();
            });

            // 配置PositionChange实体
            modelBuilder.Entity<PositionChange>(entity =>
            {
                entity.HasKey(p => p.ChangeId);
                entity.Property(p => p.ChangeId).ValueGeneratedOnAdd();
                entity.Property(p => p.PositionChangeDescription).IsRequired();
            });
        }
    }
} 