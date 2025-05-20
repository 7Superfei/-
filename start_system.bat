@echo off
chcp 65001
echo ================================================
echo             人才画像系统启动脚本
echo ================================================
echo.

echo 请输入数据库用户名:
set /p db_user=用户名: 
echo 请输入数据库密码:
set /p db_password=密码: 

echo.
echo 正在检查数据库连接...
mysql -u %db_user% -p%db_password% -e "USE employee_db; SELECT '数据库连接成功' AS '状态';" > nul 2>&1
if %errorlevel% neq 0 (
  echo [错误] 数据库连接失败，请检查MySQL服务是否启动以及账号密码是否正确。
  echo 您可能需要先运行init_database.bat初始化数据库。
  pause
  exit /b 1
)
echo [成功] 数据库连接正常！

echo.
echo 正在启动人才画像系统...
echo ================================================
echo 提示：按Ctrl+C可以终止系统运行
echo.

echo 正在启动Web应用...
cd TalentProfileSystem
start dotnet run --urls=http://localhost:5000 --ConnectionStrings:DefaultConnection="Server=localhost;Database=employee_db;User=%db_user%;Password=%db_password%;CharSet=utf8mb4;"

echo.
echo ================================================
echo 应用程序已启动！
echo 请在浏览器中访问：http://localhost:5000
echo.
echo 此窗口可以保持打开，关闭此窗口会停止应用运行。 