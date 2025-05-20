@echo off
chcp 65001
echo ================================================
echo             人才画像系统 - 数据库初始化
echo ================================================

echo 请输入数据库用户名:
set /p db_user=用户名: 
echo 请输入数据库密码:
set /p db_password=密码: 

echo.
echo 步骤1: 创建数据库结构...
mysql -u %db_user% -p%db_password% < database.sql
if %errorlevel% neq 0 (
  echo [错误] 数据库创建失败！请检查MySQL连接和账号密码。
  pause
  exit /b 1
)
echo [成功] 数据库结构创建完成！

echo.
echo 步骤2: 导入员工数据...
mysql -u %db_user% -p%db_password% < insert_employees.sql
if %errorlevel% neq 0 (
  echo [错误] 数据导入失败！
  pause
  exit /b 1
)
echo [成功] 员工数据导入完成！

echo.
echo 步骤3: 修复重复数据问题...
mysql -u %db_user% -p%db_password% -e "USE employee_db; CALL fix_duplicate_employees();"
if %errorlevel% neq 0 (
  echo [错误] 数据修复失败！
  pause
  exit /b 1
)
echo [成功] 重复数据处理完成！

echo.
echo 步骤4: 验证数据...
mysql -u %db_user% -p%db_password% -e "USE employee_db; CALL get_database_stats();"

echo.
echo ================================================
echo             数据库初始化完成！
echo ================================================
echo 您可以使用queries.sql文件中的查询来分析人才数据
echo.
echo 按任意键退出...
pause 