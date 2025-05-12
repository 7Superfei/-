<<<<<<< HEAD
USE employee_db;

-- 插入5名员工基本信息
INSERT INTO employees (
    name, gender, phone, age, hire_date, birthplace, 
    academic_level, education, major_category, specific_major, 
    second_major_category, second_specific_major, company_type, work_years,
    department, project_level, project_role, 
    performance_month1, performance_month2, performance_month3, 
    personality_type, position_level, marital_status, mortgage_pressure,
    work_environment_satisfaction, salary_satisfaction
) VALUES
-- 员工1
(
    '张三', '男', '13812345678', 32, '2018-05-15', '浙江',
    '985', '硕士', '工科', '计算机科学与技术',
    '理科', '数学与应用数学', '互联网科技公司', 8,
    '技术部', '重点项目', '技术或业务专家',
    'A', 'A+', 'A', 
    'INTJ', '中层', '已婚', '较低',
    '满意', '满意'
),
-- 员工2
(
    '李四', '女', '13987654321', 28, '2020-11-03', '江苏',
    '211', '本科', '理科', '应用物理学',
    NULL, NULL, '软件科技公司', 5,
    '产品部', '一般项目', '项目经理',
    'A-', 'B+', 'A-', 
    'ENFP', '基层', '未婚', '无房贷',
    '一般', '一般'
),
-- 员工3
(
    '王五', '男', '13712345678', 45, '2015-02-28', '北京',
    '985', '博士', '工科', '人工智能',
    NULL, NULL, '互联网科技公司', 15,
    '技术部', '重点项目', '项目总负责人',
    'A+', 'A+', 'A', 
    'ENTJ', '高层', '已婚', '无房贷',
    '满意', '满意'
),
-- 员工4
(
    '赵六', '女', '13612345678', 26, '2021-07-18', '广东',
    '普通', '本科', '文科', '新闻学',
    NULL, NULL, '数字内容创作公司', 3,
    '市场部', '轻量级项目', '技术或业务执行岗',
    'B', 'B+', 'A-', 
    'ESFJ', '基层', '未婚', '较高',
    '一般', '较差'
),
-- 员工5
(
    '钱七', '男', '13512345678', 35, '2019-04-01', '四川',
    '211', '硕士', '医科', '临床医学',
    NULL, NULL, '在线教育公司', 7,
    '运营部', '一般项目', '团队负责人',
    'A-', 'A', 'A', 
    'ISFP', '中层', '有孩', '适中',
    '一般', '一般'
);

-- 为每位员工添加上个月的考勤记录
-- 员工1的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 19 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 18 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 17 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 16 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 14 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 13 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 12 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 11 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '请假'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '请假'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常');

-- 员工2的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '迟到'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '早退'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 19 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 18 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 17 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 16 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '请假'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 14 DAY), '请假'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 13 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 12 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 11 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '迟到'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常');

-- 员工3的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 19 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 18 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 17 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 16 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 14 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 13 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 12 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 11 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '请假'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常');

-- 员工4的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '迟到'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '迟到且早退'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 19 DAY), '早退'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 18 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 17 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 16 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 14 DAY), '请假'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 13 DAY), '请假'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 12 DAY), '请假'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 11 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '迟到'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '早退'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常');

-- 员工5的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '请假'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '请假'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 19 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 18 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 17 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 16 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '迟到'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 14 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 13 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 12 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 11 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常');

-- 添加职位变动记录
INSERT INTO position_changes (employee_id, change_date, position_change) VALUES
(1, '2020-06-15', '基层->中层'),
(3, '2017-04-10', '基层->中层'),
(3, '2019-09-22', '中层->高层'),
(5, '2021-02-18', '基层->中层'); 
=======
USE employee_db;

-- 设置会话字符集为utf8mb4
SET NAMES utf8mb4;
SET CHARACTER SET utf8mb4;

-- 清空现有数据
TRUNCATE TABLE position_changes;
TRUNCATE TABLE attendance_records;
DELETE FROM employees;
ALTER TABLE employees AUTO_INCREMENT = 1;

-- 插入20名员工基本信息
INSERT INTO employees (
    name, gender, phone, age, hire_date, birthplace, 
    academic_level, education, major_category, specific_major, 
    second_major_category, second_specific_major, company_type, work_years,
    department, project_level, project_role, 
    performance_month1, performance_month2, performance_month3, 
    personality_type, position_level, marital_status, mortgage_pressure,
    work_environment_satisfaction, salary_satisfaction
) VALUES
-- 员工1（优秀员工）
(
    '张三', '男', '13812345678', 32, '2018-05-15', '浙江',
    '985', '硕士', '工科', '计算机科学与技术',
    '理科', '数学与应用数学', '互联网科技公司', 8,
    '技术部', '重点项目', '技术或业务专家',
    'A', 'A+', 'A', 
    'INTJ', '中层', '已婚', '较低',
    '满意', '满意'
),
-- 员工2（一般员工）
(
    '李四', '女', '13987654321', 28, '2020-11-03', '江苏',
    '211', '本科', '理科', '应用物理学',
    NULL, NULL, '软件科技公司', 5,
    '产品部', '一般项目', '项目经理',
    'A-', 'B+', 'A-', 
    'ENFP', '基层', '未婚', '无房贷',
    '一般', '一般'
),
-- 员工3（高管）
(
    '王五', '男', '13712345678', 45, '2015-02-28', '北京',
    '985', '博士', '工科', '人工智能',
    NULL, NULL, '互联网科技公司', 15,
    '技术部', '重点项目', '项目总负责人',
    'A+', 'A+', 'A', 
    'ENTJ', '高层', '已婚', '无房贷',
    '满意', '满意'
),
-- 员工4（表现欠佳）
(
    '赵六', '女', '13612345678', 26, '2021-07-18', '广东',
    '普通', '本科', '文科', '新闻学',
    NULL, NULL, '数字内容创作公司', 3,
    '市场部', '轻量级项目', '技术或业务执行岗',
    'B', 'B+', 'A-', 
    'ESFJ', '基层', '未婚', '较高',
    '一般', '较差'
),
-- 员工5（中层管理）
(
    '钱七', '男', '13512345678', 35, '2019-04-01', '四川',
    '211', '硕士', '医科', '临床医学',
    NULL, NULL, '在线教育公司', 7,
    '运营部', '一般项目', '团队负责人',
    'A-', 'A', 'A', 
    'ISFP', '中层', '有孩', '适中',
    '一般', '一般'
),
-- 员工6（高潜力新人）
(
    '孙八', '男', '13612345679', 24, '2022-01-10', '上海',
    '985', '硕士', '工科', '软件工程',
    NULL, NULL, '互联网科技公司', 2,
    '技术部', '一般项目', '技术或业务执行岗',
    'A+', 'A', 'A+', 
    'INTP', '基层', '未婚', '无房贷',
    '满意', '满意'
),
-- 员工7（表现一般但稳定）
(
    '周九', '女', '13712345679', 30, '2019-08-22', '河北',
    '普通', '本科', '文科', '市场营销',
    NULL, NULL, '传统企业转型公司', 6,
    '市场部', '一般项目', '团队负责人',
    'B+', 'B', 'B+', 
    'ESFP', '中层', '已婚', '较高',
    '一般', '一般'
),
-- 员工8（绩效下滑，离职风险）
(
    '吴十', '男', '13812345679', 33, '2018-03-15', '安徽',
    '211', '硕士', '工科', '电子工程',
    NULL, NULL, '硬件科技公司', 9,
    '产品部', '重点项目', '技术或业务专家',
    'A', 'B+', 'B', 
    'INFJ', '中层', '已婚', '较高',
    '较差', '较差'
),
-- 员工9（技术专家）
(
    '郑十一', '男', '13912345678', 38, '2017-05-20', '湖南',
    '985', '博士', '工科', '信息安全',
    '工科', '网络工程', '网络安全公司', 10,
    '技术部', '重点项目', '技术或业务专家',
    'A+', 'A', 'A+', 
    'INTJ', '中层', '已婚', '适中',
    '满意', '一般'
),
-- 员工10（年轻高管）
(
    '王十二', '女', '13812345680', 36, '2016-06-15', '天津',
    '985', '硕士', '工科', '计算机科学与技术',
    '文科', '工商管理', '互联网科技公司', 12,
    '运营部', '重点项目', '项目总负责人',
    'A+', 'A', 'A+', 
    'ENTJ', '高层', '已婚', '适中',
    '满意', '满意'
),
-- 员工11（新入职表现好）
(
    '刘十三', '男', '13712345680', 25, '2022-09-01', '福建',
    '211', '本科', '工科', '数据科学',
    NULL, NULL, '大数据公司', 3,
    '技术部', '一般项目', '技术或业务执行岗',
    'A-', 'A', 'A', 
    'ISTJ', '基层', '未婚', '较低',
    '满意', '一般'
),
-- 员工12（表现极差）
(
    '陈十四', '女', '13612345680', 29, '2021-03-15', '江西',
    '普通', '本科', '文科', '人力资源管理',
    NULL, NULL, '互联网科技公司', 4,
    '运营部', '轻量级项目', '技术或业务执行岗',
    'B', 'C', 'C', 
    'ESFJ', '基层', '未婚', '无房贷',
    '较差', '较差'
),
-- 员工13（设计专家）
(
    '林十五', '女', '13512345681', 31, '2019-11-11', '浙江',
    '211', '本科', '文科', '视觉设计',
    NULL, NULL, '互联网科技公司', 7,
    '设计部', '重点项目', '技术或业务专家',
    'A', 'A', 'A-', 
    'INFP', '中层', '已婚', '适中',
    '满意', '一般'
),
-- 员工14（销售精英）
(
    '张十六', '男', '13612345681', 34, '2018-08-05', '广东',
    '普通', '本科', '文科', '市场营销',
    NULL, NULL, 'SaaS服务公司', 9,
    '销售部', '重点项目', '团队负责人',
    'A+', 'A+', 'A', 
    'ESTP', '中层', '已婚', '较低',
    '满意', '满意'
),
-- 员工15（潜力被低估）
(
    '李十七', '女', '13712345681', 27, '2021-01-20', '湖北',
    '985', '硕士', '理科', '统计学',
    '工科', '人工智能', '大数据公司', 3,
    '技术部', '一般项目', '技术或业务执行岗',
    'B+', 'A-', 'A', 
    'INTP', '基层', '未婚', '无房贷',
    '一般', '一般'
),
-- 员工16（资深高管）
(
    '王十八', '男', '13812345682', 48, '2014-04-10', '北京',
    '985', '硕士', '文科', '工商管理',
    NULL, NULL, '互联网科技公司', 20,
    '销售部', '重点项目', '项目总负责人',
    'A', 'A', 'A', 
    'ESTJ', '高层', '有孩', '无房贷',
    '满意', '满意'
),
-- 员工17（成长迅速）
(
    '赵十九', '女', '13912345682', 29, '2020-07-01', '山东',
    '211', '硕士', '工科', '计算机应用技术',
    NULL, NULL, '互联网科技公司', 5,
    '产品部', '重点项目', '团队负责人',
    'B+', 'A-', 'A', 
    'ENFJ', '中层', '未婚', '较低',
    '满意', '满意'
),
-- 员工18（适应困难）
(
    '钱二十', '男', '13712345682', 31, '2021-05-12', '云南',
    '普通', '本科', '理科', '生物科学',
    NULL, NULL, '生物科技公司', 6,
    '运营部', '一般项目', '技术或业务执行岗',
    'B', 'B', 'C', 
    'ISFJ', '基层', '已婚', '较高',
    '较差', '较差'
),
-- 员工19（即将退休）
(
    '孙二十一', '男', '13612345683', 55, '2010-01-20', '河南',
    '普通', '本科', '工科', '机械工程',
    NULL, NULL, '传统制造业', 25,
    '运营部', '一般项目', '技术或业务专家',
    'B+', 'B+', 'B', 
    'ISTJ', '中层', '有孩', '无房贷',
    '一般', '一般'
),
-- 员工20（优秀新员工）
(
    '周二十二', '女', '13812345683', 26, '2022-03-01', '陕西',
    '985', '硕士', '理科', '数学',
    '工科', '人工智能', '互联网科技公司', 2,
    '技术部', '一般项目', '技术或业务执行岗',
    'A', 'A+', 'A+', 
    'INTJ', '基层', '未婚', '较低',
    '满意', '满意'
);

-- 为所有员工添加考勤记录（仅展示部分员工的详细记录，其余简化处理）
-- 为员工1添加完整考勤记录
INSERT INTO attendance_records (employee_id, date, status) VALUES
-- 员工1考勤记录（表现优秀）
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 19 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 18 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 17 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 16 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 14 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 13 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 12 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 11 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '请假'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '请假'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常');

-- 员工8考勤记录（离职风险，出勤较差）
INSERT INTO attendance_records (employee_id, date, status) VALUES
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '早退'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '迟到'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '请假'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '请假'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '请假'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 19 DAY), '迟到且早退'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 18 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 17 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 16 DAY), '迟到'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 14 DAY), '早退'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 13 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 12 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 11 DAY), '迟到'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '请假'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '请假'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '迟到'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '早退'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '迟到'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '迟到');

-- 员工12考勤记录（表现很差）
INSERT INTO attendance_records (employee_id, date, status) VALUES
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '迟到'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '迟到'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '迟到且早退'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '请假'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '请假'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '请假'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '请假'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '请假'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 19 DAY), '早退'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 18 DAY), '迟到'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 17 DAY), '迟到'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 16 DAY), '早退'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '迟到且早退'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 14 DAY), '请假'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 13 DAY), '请假'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 12 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 11 DAY), '迟到'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '迟到'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '迟到且早退'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '迟到'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '早退'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '迟到'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '迟到'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '迟到且早退'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '请假');

-- 对于其他员工，简化处理，每个员工插入一些随机考勤记录
-- 为员工2-7, 9-11, 13-20添加考勤记录（每人添加10条）
-- 员工2 (一般员工)
INSERT INTO attendance_records (employee_id, date, status) VALUES
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '迟到'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '早退'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '请假'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常');

-- 员工3 (高管，表现优秀)
INSERT INTO attendance_records (employee_id, date, status) VALUES
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY), '请假'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), '正常'),
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常');

-- 为剩余员工添加简化的考勤记录
-- 员工4-7, 9-11, 13-20各添加随机考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
-- 员工4 (表现欠佳)
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '迟到'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '迟到'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '早退'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '请假'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '迟到'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '早退'),

-- 员工5-7的考勤记录
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '请假'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(6, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '请假'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(7, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '迟到'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 15 DAY), '正常'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '早退'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 8 DAY), '正常'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), '正常'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), '请假'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), '正常'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常');

-- 为员工9-20添加简化的考勤记录
INSERT INTO attendance_records (employee_id, date, status) VALUES
-- 优秀员工(9, 10, 14, 16, 20)考勤
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(10, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '请假'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(14, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(16, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(20, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

-- 一般员工(11, 13, 15, 17, 19)考勤
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '迟到'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(13, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '请假'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(15, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '早退'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(17, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '请假'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

(19, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '迟到'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '正常'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '正常'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '早退'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '正常'),

-- 表现差的员工(18)考勤
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '迟到'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 20 DAY), '迟到'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), '早退'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), '请假'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), '迟到且早退');

-- 添加职位变动记录
INSERT INTO position_changes (employee_id, change_date, position_change) VALUES
-- 已有员工的职位变动
(1, '2020-06-15', '基层->中层'),
(3, '2017-04-10', '基层->中层'),
(3, '2019-09-22', '中层->高层'),
(5, '2021-02-18', '基层->中层'),
-- 新增员工的职位变动
(6, '2023-05-10', '基层->中层'), -- 高潜力新人快速晋升
(9, '2019-08-15', '基层->中层'), -- 技术专家晋升
(10, '2018-03-10', '基层->中层'),
(10, '2020-11-20', '中层->高层'), -- 年轻高管两次晋升
(14, '2019-12-05', '基层->中层'), -- 销售精英晋升
(16, '2016-07-20', '基层->中层'),
(16, '2018-05-15', '中层->高层'), -- 资深高管两次晋升
(17, '2022-03-18', '基层->中层'); -- 成长迅速员工晋升 
>>>>>>> c12aaa8 (first)
