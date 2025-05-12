<<<<<<< HEAD
USE employee_db;

-- 1. 查询所有员工的基本信息
SELECT employee_id, name, gender, age, department, position_level
FROM employees;

-- 2. 查询高学历（硕士及以上）员工信息
SELECT name, gender, age, academic_level, education, department
FROM employees
WHERE education IN ('硕士', '博士');

-- 3. 按部门统计员工人数
SELECT department, COUNT(*) AS 员工数量
FROM employees
GROUP BY department;

-- 4. 查询绩效优秀（至少有一个月是A+）的员工
SELECT name, department, performance_month1, performance_month2, performance_month3
FROM employees
WHERE performance_month1 = 'A+' OR performance_month2 = 'A+' OR performance_month3 = 'A+';

-- 5. 查询员工出勤情况统计
SELECT e.name, 
       COUNT(CASE WHEN a.status = '正常' THEN 1 END) AS 正常出勤,
       COUNT(CASE WHEN a.status = '迟到' THEN 1 END) AS 迟到次数,
       COUNT(CASE WHEN a.status = '早退' THEN 1 END) AS 早退次数,
       COUNT(CASE WHEN a.status = '迟到且早退' THEN 1 END) AS 迟到且早退,
       COUNT(CASE WHEN a.status = '请假' THEN 1 END) AS 请假次数
FROM employees e
JOIN attendance_records a ON e.employee_id = a.employee_id
GROUP BY e.employee_id, e.name;

-- 6. 查询员工职位变动记录
SELECT e.name, p.change_date, p.position_change
FROM employees e
JOIN position_changes p ON e.employee_id = p.employee_id
ORDER BY e.name, p.change_date;

-- 7. 查询985院校且专业为计算机相关的员工
SELECT name, academic_level, education, major_category, specific_major
FROM employees
WHERE academic_level = '985' 
AND (specific_major LIKE '%计算机%' OR specific_major LIKE '%软件%' OR specific_major LIKE '%人工智能%');

-- 8. 按性别和学历分组统计
SELECT gender, education, COUNT(*) AS 数量
FROM employees
GROUP BY gender, education
ORDER BY gender, education;

-- 9. 查询婚姻状况与房贷压力的关系
SELECT marital_status, mortgage_pressure, COUNT(*) AS 数量
FROM employees
GROUP BY marital_status, mortgage_pressure
ORDER BY marital_status, mortgage_pressure;

-- 10. 查询员工综合信息（包括考勤和职位变动）
SELECT 
    e.name, 
    e.gender, 
    e.age, 
    e.department, 
    e.position_level,
    (SELECT COUNT(*) FROM attendance_records a WHERE a.employee_id = e.employee_id AND a.status != '正常') AS 异常考勤次数,
    (SELECT COUNT(*) FROM position_changes p WHERE p.employee_id = e.employee_id) AS 职位变动次数
FROM employees e
=======
USE employee_db;

-- 1. 查询所有员工的基本信息
SELECT employee_id, name, gender, age, department, position_level
FROM employees;

-- 2. 查询高学历（硕士及以上）员工信息
SELECT name, gender, age, academic_level, education, department
FROM employees
WHERE education IN ('硕士', '博士');

-- 3. 按部门统计员工人数
SELECT department, COUNT(*) AS 员工数量
FROM employees
GROUP BY department;

-- 4. 查询绩效优秀（至少有一个月是A+）的员工
SELECT name, department, performance_month1, performance_month2, performance_month3
FROM employees
WHERE performance_month1 = 'A+' OR performance_month2 = 'A+' OR performance_month3 = 'A+';

-- 5. 查询员工出勤情况统计
SELECT e.name, 
       COUNT(CASE WHEN a.status = '正常' THEN 1 END) AS 正常出勤,
       COUNT(CASE WHEN a.status = '迟到' THEN 1 END) AS 迟到次数,
       COUNT(CASE WHEN a.status = '早退' THEN 1 END) AS 早退次数,
       COUNT(CASE WHEN a.status = '迟到且早退' THEN 1 END) AS 迟到且早退,
       COUNT(CASE WHEN a.status = '请假' THEN 1 END) AS 请假次数
FROM employees e
JOIN attendance_records a ON e.employee_id = a.employee_id
GROUP BY e.employee_id, e.name;

-- 6. 查询员工职位变动记录
SELECT e.name, p.change_date, p.position_change
FROM employees e
JOIN position_changes p ON e.employee_id = p.employee_id
ORDER BY e.name, p.change_date;

-- 7. 查询985院校且专业为计算机相关的员工
SELECT name, academic_level, education, major_category, specific_major
FROM employees
WHERE academic_level = '985' 
AND (specific_major LIKE '%计算机%' OR specific_major LIKE '%软件%' OR specific_major LIKE '%人工智能%');

-- 8. 按性别和学历分组统计
SELECT gender, education, COUNT(*) AS 数量
FROM employees
GROUP BY gender, education
ORDER BY gender, education;

-- 9. 查询婚姻状况与房贷压力的关系
SELECT marital_status, mortgage_pressure, COUNT(*) AS 数量
FROM employees
GROUP BY marital_status, mortgage_pressure
ORDER BY marital_status, mortgage_pressure;

-- 10. 查询员工综合信息（包括考勤和职位变动）
SELECT 
    e.name, 
    e.gender, 
    e.age, 
    e.department, 
    e.position_level,
    (SELECT COUNT(*) FROM attendance_records a WHERE a.employee_id = e.employee_id AND a.status != '正常') AS 异常考勤次数,
    (SELECT COUNT(*) FROM position_changes p WHERE p.employee_id = e.employee_id) AS 职位变动次数
FROM employees e
>>>>>>> c12aaa8 (first)
ORDER BY e.name; 