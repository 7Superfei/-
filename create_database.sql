<<<<<<< HEAD
-- 创建数据库
CREATE DATABASE IF NOT EXISTS employee_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE employee_db;

-- 创建员工基本信息表
CREATE TABLE employees (
    employee_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL COMMENT '姓名',
    gender ENUM('男', '女') NOT NULL COMMENT '性别',
    phone VARCHAR(11) NOT NULL COMMENT '电话',
    age INT NOT NULL COMMENT '年龄',
    hire_date DATE NOT NULL COMMENT '入职时间',
    birthplace VARCHAR(20) NOT NULL COMMENT '籍贯(省份)',
    academic_level ENUM('普通', '211', '985') NOT NULL COMMENT '院校级别',
    education ENUM('本科', '硕士', '博士') NOT NULL COMMENT '学历',
    major_category ENUM('文科', '理科', '工科', '医科', '农科') NOT NULL COMMENT '专业大类',
    specific_major VARCHAR(50) NOT NULL COMMENT '具体专业',
    second_major_category ENUM('文科', '理科', '工科', '医科', '农科') COMMENT '第二专业大类',
    second_specific_major VARCHAR(50) COMMENT '第二具体专业',
    company_type VARCHAR(100) NOT NULL COMMENT '公司类型',
    work_years INT NOT NULL COMMENT '工作时间(年)',
    department ENUM('技术部', '设计部', '市场部', '产品部', '运营部', '销售部') NOT NULL COMMENT '部门',
    project_level ENUM('重点项目', '一般项目', '轻量级项目') NOT NULL COMMENT '项目级别',
    project_role VARCHAR(50) NOT NULL COMMENT '身份',
    performance_month1 ENUM('A+', 'A', 'A-', 'B+', 'B', 'C') NOT NULL COMMENT '第一个月绩效',
    performance_month2 ENUM('A+', 'A', 'A-', 'B+', 'B', 'C') NOT NULL COMMENT '第二个月绩效',
    performance_month3 ENUM('A+', 'A', 'A-', 'B+', 'B', 'C') NOT NULL COMMENT '第三个月绩效',
    personality_type VARCHAR(4) NOT NULL COMMENT 'MBTI性格类型',
    position_level ENUM('基层', '中层', '高层') NOT NULL COMMENT '职级',
    marital_status ENUM('已婚', '未婚', '有孩') NOT NULL COMMENT '婚姻状况',
    mortgage_pressure ENUM('无房贷', '较低', '适中', '较高') NOT NULL COMMENT '房贷压力',
    work_environment_satisfaction ENUM('满意', '一般', '较差') NOT NULL COMMENT '工作环境满意度',
    salary_satisfaction ENUM('满意', '一般', '较差') NOT NULL COMMENT '薪资满意度',
    UNIQUE(phone)
);

-- 创建考勤记录表
CREATE TABLE attendance_records (
    record_id INT PRIMARY KEY AUTO_INCREMENT,
    employee_id INT NOT NULL,
    date DATE NOT NULL,
    status ENUM('正常', '迟到', '早退', '迟到且早退', '请假') NOT NULL,
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id),
    UNIQUE(employee_id, date)
);

-- 创建职位变动表
CREATE TABLE position_changes (
    change_id INT PRIMARY KEY AUTO_INCREMENT,
    employee_id INT NOT NULL,
    change_date DATE NOT NULL,
    position_change VARCHAR(100) NOT NULL,
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id)
); 
=======
-- 创建数据库
CREATE DATABASE IF NOT EXISTS employee_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE employee_db;

-- 创建员工基本信息表
CREATE TABLE IF NOT EXISTS employees (
    employee_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL COMMENT '姓名',
    gender ENUM('男', '女') NOT NULL COMMENT '性别',
    phone VARCHAR(11) NOT NULL COMMENT '电话',
    age INT NOT NULL COMMENT '年龄',
    hire_date DATE NOT NULL COMMENT '入职时间',
    birthplace VARCHAR(20) NOT NULL COMMENT '籍贯(省份)',
    academic_level ENUM('普通', '211', '985') NOT NULL COMMENT '院校级别',
    education ENUM('本科', '硕士', '博士') NOT NULL COMMENT '学历',
    major_category ENUM('文科', '理科', '工科', '医科', '农科') NOT NULL COMMENT '专业大类',
    specific_major VARCHAR(50) NOT NULL COMMENT '具体专业',
    second_major_category ENUM('文科', '理科', '工科', '医科', '农科') COMMENT '第二专业大类',
    second_specific_major VARCHAR(50) COMMENT '第二具体专业',
    company_type VARCHAR(100) NOT NULL COMMENT '公司类型',
    work_years INT NOT NULL COMMENT '工作时间(年)',
    department ENUM('技术部', '设计部', '市场部', '产品部', '运营部', '销售部') NOT NULL COMMENT '部门',
    project_level ENUM('重点项目', '一般项目', '轻量级项目') NOT NULL COMMENT '项目级别',
    project_role VARCHAR(50) NOT NULL COMMENT '身份',
    performance_month1 ENUM('A+', 'A', 'A-', 'B+', 'B', 'C') NOT NULL COMMENT '第一个月绩效',
    performance_month2 ENUM('A+', 'A', 'A-', 'B+', 'B', 'C') NOT NULL COMMENT '第二个月绩效',
    performance_month3 ENUM('A+', 'A', 'A-', 'B+', 'B', 'C') NOT NULL COMMENT '第三个月绩效',
    personality_type VARCHAR(4) NOT NULL COMMENT 'MBTI性格类型',
    position_level ENUM('基层', '中层', '高层') NOT NULL COMMENT '职级',
    marital_status ENUM('已婚', '未婚', '有孩') NOT NULL COMMENT '婚姻状况',
    mortgage_pressure ENUM('无房贷', '较低', '适中', '较高') NOT NULL COMMENT '房贷压力',
    work_environment_satisfaction ENUM('满意', '一般', '较差') NOT NULL COMMENT '工作环境满意度',
    salary_satisfaction ENUM('满意', '一般', '较差') NOT NULL COMMENT '薪资满意度',
    UNIQUE(phone)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- 创建考勤记录表
CREATE TABLE IF NOT EXISTS attendance_records (
    record_id INT PRIMARY KEY AUTO_INCREMENT,
    employee_id INT NOT NULL,
    date DATE NOT NULL,
    status ENUM('正常', '迟到', '早退', '迟到且早退', '请假') NOT NULL,
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id),
    UNIQUE(employee_id, date)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- 创建职位变动表
CREATE TABLE IF NOT EXISTS position_changes (
    change_id INT PRIMARY KEY AUTO_INCREMENT,
    employee_id INT NOT NULL,
    change_date DATE NOT NULL,
    position_change VARCHAR(100) NOT NULL,
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci; 
>>>>>>> c12aaa8 (first)
