@echo off
echo 正在创建员工信息数据库...

REM 连接MySQL并执行创建数据库和表的脚本
mysql -u root -psupengfei9740 < create_database.sql

REM 执行插入员工数据的脚本
mysql -u root -psupengfei9740 < insert_employees.sql

echo 数据库创建完成！
echo 以下是数据库中的表：
mysql -u root -psupengfei9740 -e "USE employee_db; SHOW TABLES;"

echo.
echo 以下是员工基本信息：
mysql -u root -psupengfei9740 -e "USE employee_db; SELECT employee_id, name, gender, age, department, position_level FROM employees;"

pause 