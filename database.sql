-- ================================================
-- 人才画像系统综合数据库脚本
-- 此文件包含创建、重置和清理数据库的完整功能
-- ================================================

-- 使用UTF-8编码，避免中文乱码问题
SET NAMES utf8mb4;

-- 第一部分：数据库创建和表结构设置
-- ------------------------------------------------
DROP DATABASE IF EXISTS employee_db;
CREATE DATABASE employee_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE employee_db;

-- 创建员工基本信息表
CREATE TABLE employees (
    employee_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL COMMENT '姓名',
    gender VARCHAR(10) NOT NULL COMMENT '性别', 
    phone VARCHAR(11) NOT NULL COMMENT '电话',
    age INT NOT NULL COMMENT '年龄',
    hire_date DATE NOT NULL COMMENT '入职时间',
    birthplace VARCHAR(20) NOT NULL COMMENT '籍贯(省份)',
    academic_level VARCHAR(10) NOT NULL COMMENT '院校级别', 
    education VARCHAR(10) NOT NULL COMMENT '学历', 
    major_category VARCHAR(10) NOT NULL COMMENT '专业大类', 
    specific_major VARCHAR(50) NOT NULL COMMENT '具体专业',
    second_major_category VARCHAR(10) COMMENT '第二专业大类', 
    second_specific_major VARCHAR(50) COMMENT '第二具体专业',
    company_type VARCHAR(100) NOT NULL COMMENT '公司类型',
    work_years INT NOT NULL COMMENT '工作时间(年)',
    department VARCHAR(10) NOT NULL COMMENT '部门', 
    project_count INT NOT NULL DEFAULT 0 COMMENT '项目数量',
    performance_month1 VARCHAR(10) NOT NULL COMMENT '第一个月绩效', 
    performance_month2 VARCHAR(10) NOT NULL COMMENT '第二个月绩效', 
    performance_month3 VARCHAR(10) NOT NULL COMMENT '第三个月绩效', 
    personality_type VARCHAR(10) NOT NULL COMMENT 'MBTI性格类型',
    position_level VARCHAR(10) NOT NULL COMMENT '职级', 
    marital_status VARCHAR(10) NOT NULL COMMENT '婚姻状况', 
    mortgage_pressure VARCHAR(10) NOT NULL COMMENT '房贷压力', 
    work_environment_satisfaction VARCHAR(10) NOT NULL COMMENT '工作环境满意度', 
    salary_satisfaction VARCHAR(10) NOT NULL COMMENT '薪资满意度', 
    UNIQUE(phone)
);

-- 创建考勤记录表
CREATE TABLE attendance_records (
    record_id INT PRIMARY KEY AUTO_INCREMENT,
    employee_id INT NOT NULL,
    date DATE NOT NULL,
    status VARCHAR(20) NOT NULL COMMENT '考勤状态：正常/迟到/早退/迟到且早退/请假',
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id) ON DELETE CASCADE,
    UNIQUE(employee_id, date)
);

-- 创建职位变动表
CREATE TABLE position_changes (
    change_id INT PRIMARY KEY AUTO_INCREMENT,
    employee_id INT NOT NULL,
    change_date DATE NOT NULL,
    position_change VARCHAR(100) NOT NULL COMMENT '职位变动描述',
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id) ON DELETE CASCADE
);

-- 创建项目经历表
CREATE TABLE project_experiences (
    experience_id INT PRIMARY KEY AUTO_INCREMENT,
    employee_id INT NOT NULL,
    project_level VARCHAR(20) NOT NULL COMMENT '项目级别：重点项目/一般项目/轻量级项目',
    project_role VARCHAR(50) NOT NULL COMMENT '担任角色',
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id) ON DELETE CASCADE
);

-- 第二部分：数据清理和重置函数
-- ------------------------------------------------

-- 删除重复员工数据的存储过程
DELIMITER //
CREATE PROCEDURE IF NOT EXISTS fix_duplicate_employees()
BEGIN
    -- 删除电话号码重复的员工（保留ID较小的）
    DELETE e1 FROM employees e1 
    INNER JOIN employees e2 
    WHERE e1.employee_id > e2.employee_id AND e1.phone = e2.phone;
    
    -- 输出提示信息
    SELECT CONCAT('成功删除了重复员工数据，当前总员工数: ', COUNT(*)) AS 'Message'
    FROM employees;
END //
DELIMITER ;

-- 重置数据的存储过程
DELIMITER //
CREATE PROCEDURE IF NOT EXISTS reset_all_data()
BEGIN
    -- 先删除数据，保持外键约束
    DELETE FROM employees;

    -- 重置自增ID
    ALTER TABLE employees AUTO_INCREMENT = 1;
    ALTER TABLE attendance_records AUTO_INCREMENT = 1;
    ALTER TABLE position_changes AUTO_INCREMENT = 1;
    ALTER TABLE project_experiences AUTO_INCREMENT = 1;
    
    -- 输出提示信息
    SELECT '所有数据已重置，表的自增ID已归零' AS 'Message';
END //
DELIMITER ;

-- 第三部分：数据库信息查询函数
-- ------------------------------------------------

-- 查询数据库概要信息的存储过程
DELIMITER //
CREATE PROCEDURE IF NOT EXISTS get_database_stats()
BEGIN
    SELECT 
        (SELECT COUNT(*) FROM employees) AS '员工总数',
        (SELECT COUNT(*) FROM attendance_records) AS '考勤记录数',
        (SELECT COUNT(*) FROM position_changes) AS '职位变动记录数',
        (SELECT COUNT(*) FROM project_experiences) AS '项目经历记录数';
    
    -- 显示部门分布
    SELECT department AS '部门', COUNT(*) AS '人数', 
           CONCAT(ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM employees), 2), '%') AS '占比'
    FROM employees
    GROUP BY department
    ORDER BY COUNT(*) DESC;
END //
DELIMITER ; 