-- ================================================
-- 人才画像系统查询示例
-- 此文件包含各种数据分析和查询示例
-- ================================================

USE employee_db;

-- 第一部分：基础信息查询
-- ------------------------------------------------

-- 查询所有员工的基本信息
SELECT employee_id, name, gender, age, department, position_level
FROM employees;

-- 按ID查询单个员工的详细信息
SELECT * FROM employees WHERE employee_id = 1;

-- 查询员工数据库统计信息
CALL get_database_stats();

-- 第二部分：人员画像分析查询
-- ------------------------------------------------

-- 1. 学历和专业背景分析
-- 查询高学历（硕士及以上）员工信息
SELECT name, gender, age, academic_level, education, department
FROM employees
WHERE education IN ('硕士', '博士');

-- 查询985/211院校且专业为计算机相关的员工
SELECT name, academic_level, education, major_category, specific_major
FROM employees
WHERE academic_level IN ('985', '211') 
AND (specific_major LIKE '%计算机%' OR specific_major LIKE '%软件%' OR specific_major LIKE '%人工智能%');

-- 2. 绩效表现分析
-- 查询绩效优秀（至少有一个月是A+）的员工
SELECT name, department, performance_month1, performance_month2, performance_month3
FROM employees
WHERE performance_month1 = 'A+' OR performance_month2 = 'A+' OR performance_month3 = 'A+';

-- 查询绩效有待提高的员工（有C级绩效的员工）
SELECT name, department, performance_month1, performance_month2, performance_month3
FROM employees
WHERE performance_month1 = 'C' OR performance_month2 = 'C' OR performance_month3 = 'C';

-- 查询绩效稳定的员工（三个月绩效相同）
SELECT name, department, performance_month1, performance_month2, performance_month3
FROM employees
WHERE performance_month1 = performance_month2 AND performance_month2 = performance_month3;

-- 3. 出勤情况分析
-- 查询员工出勤情况统计
SELECT e.name, 
       COUNT(CASE WHEN a.status = '正常' THEN 1 END) AS 正常出勤,
       COUNT(CASE WHEN a.status = '迟到' THEN 1 END) AS 迟到次数,
       COUNT(CASE WHEN a.status = '早退' THEN 1 END) AS 早退次数,
       COUNT(CASE WHEN a.status = '迟到且早退' THEN 1 END) AS 迟到且早退,
       COUNT(CASE WHEN a.status = '请假' THEN 1 END) AS 请假次数
FROM employees e
JOIN attendance_records a ON e.employee_id = a.employee_id
GROUP BY e.employee_id, e.name
ORDER BY 迟到次数 + 早退次数 + 迟到且早退 DESC;

-- 查询最近一个月内异常考勤次数较多的员工
SELECT e.name, e.department, COUNT(*) AS 异常考勤次数
FROM employees e
JOIN attendance_records a ON e.employee_id = a.employee_id
WHERE a.status != '正常' 
  AND a.date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
GROUP BY e.employee_id, e.name, e.department
HAVING COUNT(*) > 2
ORDER BY 异常考勤次数 DESC;

-- 第三部分：人员结构分析查询
-- ------------------------------------------------

-- 1. 部门分布分析
-- 按部门统计员工人数及占比
SELECT department, 
       COUNT(*) AS 员工数量, 
       CONCAT(ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM employees), 2), '%') AS 占比
FROM employees
GROUP BY department
ORDER BY 员工数量 DESC;

-- 2. 人口统计分析
-- 按性别和学历分组统计
SELECT gender, education, COUNT(*) AS 数量, 
       CONCAT(ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM employees), 2), '%') AS 占比
FROM employees
GROUP BY gender, education
ORDER BY gender, education;

-- 按年龄段统计
SELECT 
    CASE 
        WHEN age < 25 THEN '25岁以下'
        WHEN age BETWEEN 25 AND 35 THEN '25-35岁'
        WHEN age BETWEEN 36 AND 45 THEN '36-45岁'
        ELSE '45岁以上'
    END AS 年龄段,
    COUNT(*) AS 人数,
    CONCAT(ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM employees), 2), '%') AS 占比
FROM employees
GROUP BY 年龄段
ORDER BY MIN(age);

-- 3. 社会因素分析
-- 查询婚姻状况与房贷压力的关系
SELECT marital_status AS 婚姻状况, 
       mortgage_pressure AS 房贷压力, 
       COUNT(*) AS 人数,
       CONCAT(ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM employees WHERE marital_status = e.marital_status), 2), '%') AS 占比
FROM employees e
GROUP BY 婚姻状况, 房贷压力
ORDER BY 婚姻状况, 房贷压力;

-- 工作满意度分析
SELECT 
    work_environment_satisfaction AS 工作环境满意度, 
    salary_satisfaction AS 薪资满意度,
    COUNT(*) AS 人数,
    CONCAT(ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM employees), 2), '%') AS 占比
FROM employees
GROUP BY 工作环境满意度, 薪资满意度
ORDER BY (CASE 工作环境满意度 WHEN '满意' THEN 1 WHEN '一般' THEN 2 ELSE 3 END),
         (CASE 薪资满意度 WHEN '满意' THEN 1 WHEN '一般' THEN 2 ELSE 3 END);

-- 第四部分：职业发展分析查询
-- ------------------------------------------------

-- 1. 工作经验分析
-- 按工作年限分组
SELECT 
    CASE 
        WHEN work_years < 2 THEN '0-2年'
        WHEN work_years BETWEEN 2 AND 5 THEN '2-5年'
        WHEN work_years BETWEEN 6 AND 10 THEN '6-10年'
        ELSE '10年以上'
    END AS 工作年限,
    COUNT(*) AS 人数,
    ROUND(AVG(age), 1) AS 平均年龄
FROM employees
GROUP BY 工作年限
ORDER BY MIN(work_years);

-- 2. 职位变动分析
-- 查询员工职位变动记录
SELECT e.name, e.department, p.change_date, p.position_change
FROM employees e
JOIN position_changes p ON e.employee_id = p.employee_id
ORDER BY e.name, p.change_date;

-- 查询职位变动频繁的员工
SELECT e.name, e.department, COUNT(*) AS 职位变动次数
FROM employees e
JOIN position_changes p ON e.employee_id = p.employee_id
GROUP BY e.employee_id, e.name, e.department
HAVING COUNT(*) > 1
ORDER BY 职位变动次数 DESC;

-- 3. 综合信息查询
-- 查询员工综合信息（包括考勤和职位变动）
SELECT 
    e.name, 
    e.gender, 
    e.age, 
    e.department, 
    e.position_level,
    (SELECT COUNT(*) FROM attendance_records a WHERE a.employee_id = e.employee_id AND a.status != '正常') AS 异常考勤次数,
    (SELECT COUNT(*) FROM position_changes p WHERE p.employee_id = e.employee_id) AS 职位变动次数
FROM employees e
ORDER BY e.department, e.name; 