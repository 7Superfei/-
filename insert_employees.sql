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