using Microsoft.EntityFrameworkCore;
using TalentProfileSystem.Data;
using TalentProfileSystem.Services;

// 创建Web应用程序构建器
var builder = WebApplication.CreateBuilder(args);

// 添加MVC服务到DI容器
builder.Services.AddControllersWithViews();

// 配置数据库连接
// 优先使用配置文件中的连接字符串，如不存在则使用默认连接字符串
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
    "server=localhost;database=employee_db;user=root;password=supengfei9740;";

// 添加DbContext到DI容器，使用MySQL数据库
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 注册应用程序所需的服务
// 所有服务使用Scoped生命周期，确保每个HTTP请求有一个独立的服务实例
builder.Services.AddScoped<IEmployeeService, EmployeeService>();  // 员工服务
builder.Services.AddScoped<IProfileService, ProfileService>();    // 画像服务
builder.Services.AddScoped<ITagService, TagService>();            // 标签服务
builder.Services.AddScoped<IAnalysisService, AnalysisService>();  // 分析服务

// 构建应用程序
var app = builder.Build();

// 配置HTTP请求处理管道
if (!app.Environment.IsDevelopment())
{
    // 非开发环境下启用异常处理和HSTS
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // HTTP严格传输安全
}

// 启用HTTPS重定向
app.UseHttpsRedirection();
// 启用静态文件服务
app.UseStaticFiles();

// 启用路由
app.UseRouting();

// 启用授权
app.UseAuthorization();

// 配置默认路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 启动应用程序
app.Run(); 