using Microsoft.EntityFrameworkCore;
using TalentProfileSystem.Data;
using TalentProfileSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// 添加服务到容器
builder.Services.AddControllersWithViews();

// 配置数据库连接
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
    "server=localhost;database=employee_db;user=root;password=supengfei9740;";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 添加自定义服务
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IAnalysisService, AnalysisService>();

var app = builder.Build();

// 配置HTTP请求管道
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); 