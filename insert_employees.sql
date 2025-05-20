USE employee_db;

-- 插入10名员工基本信息
INSERT INTO employees (
    name, gender, phone, age, hire_date, birthplace, 
    academic_level, education, major_category, specific_major, 
    second_major_category, second_specific_major, company_type, work_years,
    department, project_count, 
    performance_month1, performance_month2, performance_month3, 
    personality_type, position_level, marital_status, mortgage_pressure,
    work_environment_satisfaction, salary_satisfaction
) VALUES
-- 员工1
(
    '宿鹏飞', '男', '13800000001', 32, '2018-05-15', '浙江',
    '985', '硕士', '工科', '计算机科学与技术',
    '理科', '数学与应用数学', '互联网科技公司', 8,
    '技术部', 2,
    'A', 'A+', 'A', 
    'INTJ', '中层', '已婚', '较低',
    '满意', '满意'
),
-- 员工2
(
    '张若楠', '女', '13800000002', 28, '2020-11-03', '江苏',
    '211', '本科', '理科', '应用物理学',
    NULL, NULL, '软件科技公司', 5,
    '产品部', 1,
    'A-', 'B+', 'A-', 
    'ENFP', '基层', '未婚', '无房贷',
    '一般', '一般'
),
-- 员工3
(
    '田子悦', '男', '13800000003', 45, '2015-02-28', '北京',
    '985', '博士', '工科', '人工智能',
    NULL, NULL, '互联网科技公司', 15,
    '技术部', 3,
    'A+', 'A+', 'A', 
    'ENTJ', '高层', '已婚', '无房贷',
    '满意', '满意'
),
-- 员工4
(
    '金晨', '女', '13800000004', 26, '2021-07-18', '广东',
    '普通', '本科', '文科', '新闻学',
    NULL, NULL, '数字内容创作公司', 3,
    '市场部', 1,
    'B', 'B+', 'A-', 
    'ESFJ', '基层', '未婚', '较高',
    '一般', '较差'
),
-- 员工5
(
    '曹俊', '男', '13800000005', 35, '2019-04-01', '四川',
    '211', '硕士', '医科', '临床医学',
    NULL, NULL, '在线教育公司', 7,
    '运营部', 2,
    'A-', 'A', 'A', 
    'ISFP', '中层', '有孩', '适中',
    '一般', '一般'
),
-- 员工6（杰出表现的年轻潜力股）
(
    '邱恩廷', '男', '13800000006', 25, '2022-03-15', '上海',
    '985', '硕士', '工科', '人工智能',
    '工科', '软件工程', '顶级互联网公司', 2,
    '技术部', 1,
    'A+', 'A+', 'A+', 
    'INTP', '基层', '未婚', '无房贷',
    '满意', '满意'
),
-- 员工7（表现差的离职风险员工）
(
    '王Q', '男', '13800000007', 38, '2020-05-20', '河北',
    '普通', '本科', '文科', '市场营销',
    NULL, NULL, '传统企业', 10,
    '销售部', 0,
    'C', 'C', 'B', 
    'ISTP', '基层', '已婚', '较高',
    '较差', '较差'
),
-- 员工8（刚入职高背景员工）
(
    '王冰冰', '女', '13800000008', 29, '2023-10-01', '天津',
    '985', '博士', '理科', '量子物理',
    '工科', '电子信息工程', '国际研究机构', 3,
    '产品部', 2,
    'A', 'A', 'A-', 
    'INTJ', '中层', '未婚', '无房贷',
    '满意', '一般'
),
-- 员工9（工作年限长但绩效一般的员工）
(
    '周青驰QQC', '男', '13800000009', 48, '2016-08-12', '福建',
    '211', '本科', '工科', '通信工程',
    NULL, NULL, '国企', 20,
    '运营部', 1,
    'B', 'B', 'B+', 
    'ESTJ', '中层', '有孩', '较低',
    '一般', '一般'
),
-- 员工10（有特殊专业背景的员工）
(
    '白鹿', '女', '13800000010', 32, '2021-01-15', '云南',
    '普通', '硕士', '农科', '农业经济管理',
    '工科', '数据科学与大数据技术', '农业科技公司', 5,
    '设计部', 1,
    'B+', 'A-', 'B+', 
    'ENFJ', '基层', '已婚', '适中',
    '满意', '较差'
),
-- 新增员工11（非常有经验的设计总监）
(
    '赵露思', '女', '13800000011', 37, '2017-03-08', '江西',
    '211', '硕士', '文科', '传播学',
    '工科', '工业设计', '互联网科技公司', 12,
    '设计部', 4,
    'A+', 'A', 'A+', 
    'ENFP', '高层', '已婚', '较低',
    '满意', '满意'
),
-- 新增员工12（博士研究员，技术专家）
(
    '叶明宸', '男', '13800000012', 33, '2022-05-10', '湖南',
    '985', '博士', '理科', '生物技术',
    '医科', '医学检验技术', '医药研发公司', 5,
    '技术部', 2,
    'A', 'A', 'A-', 
    'INFJ', '中层', '已婚', '适中',
    '一般', '满意'
),
-- 新增员工13（年轻的销售精英）
(
    '周淑怡', '女', '13800000013', 26, '2021-09-18', '安徽',
    '普通', '本科', '文科', '市场营销',
    NULL, NULL, '互联网金融公司', 3,
    '销售部', 1,
    'A+', 'A+', 'A', 
    'ESTP', '基层', '未婚', '较低',
    '满意', '一般'
),
-- 新增员工14（资深技术管理者）
(
    '汪小强', '男', '13800000014', 41, '2016-04-25', '山东',
    '985', '硕士', '工科', '软件工程',
    '理科', '数学与应用数学', '互联网科技公司', 16,
    '技术部', 5,
    'A', 'A-', 'A', 
    'ISTJ', '高层', '有孩', '较低',
    '满意', '满意'
),
-- 新增员工15（跨领域人才）
(
    '韩雪', '女', '13800000015', 31, '2019-11-30', '辽宁',
    '211', '硕士', '理科', '应用化学',
    '工科', '材料科学与工程', '新能源科技公司', 7,
    '产品部', 2,
    'B+', 'A-', 'A', 
    'ENTJ', '中层', '未婚', '无房贷',
    '满意', '一般'
),
-- 新增员工16（刚毕业的应届生）
(
    '是悬案', '男', '13800000016', 23, '2023-07-01', '重庆',
    '211', '本科', '工科', '计算机科学与技术',
    NULL, NULL, '软件科技公司', 0,
    '技术部', 0,
    'B+', 'A-', 'B+', 
    'INTP', '基层', '未婚', '无房贷',
    '一般', '一般'
),
-- 新增员工17（有创业经历的产品总监）
(
    '欧阳娜娜', '女', '13800000017', 36, '2020-02-14', '湖北',
    '985', '硕士', '工科', '物联网工程',
    '文科', '市场营销', '互联网科技公司', 11,
    '产品部', 3,
    'A', 'A+', 'A', 
    'ENTP', '高层', '已婚', '适中',
    '满意', '满意'
),
-- 新增员工18（工作很久的运维工程师）
(
    '陈平淦', '男', '13800000018', 47, '2013-08-15', '河南',
    '普通', '本科', '工科', '网络工程',
    NULL, NULL, '传统制造业公司', 22,
    '技术部', 1,
    'B', 'B+', 'B', 
    'ISTP', '中层', '有孩', '无房贷',
    '一般', '一般'
),
-- 新增员工19（表现不太稳定的年轻员工）
(
    '黄圣依', '女', '13800000019', 25, '2022-11-07', '广西',
    '211', '硕士', '文科', '英语',
    NULL, NULL, '在线教育公司', 2,
    '市场部', 1,
    'B+', 'C', 'A-', 
    'ESFP', '基层', '未婚', '较高',
    '一般', '较差'
),
-- 新增员工20（跨国公司来的专家）
(
    '李浩冉', '男', '13800000020', 39, '2021-03-23', '新疆',
    '985', '博士', '工科', '人工智能',
    '工科', '机器人工程', '互联网科技公司', 14,
    '产品部', 2,
    'A+', 'A', 'A', 
    'INTJ', '高层', '已婚', '无房贷',
    '满意', '满意'
),
-- 新增员工21（多元文化背景员工）
(
    '迪丽热巴', '女', '13800000021', 29, '2020-06-19', '海南',
    '211', '硕士', '文科', '传播学',
    '文科', '国际政治', '数字内容创作公司', 6,
    '市场部', 2,
    'A-', 'A', 'A-', 
    'ENFJ', '中层', '未婚', '较低',
    '满意', '一般'
),
-- 新增员工22（资深财务专家）
(
    '李海冰', '男', '13800000022', 43, '2015-10-15', '陕西',
    '211', '硕士', '理科', '金融学',
    NULL, NULL, '互联网金融公司', 18,
    '运营部', 2,
    'A', 'A', 'A-', 
    'ESTJ', '高层', '已婚', '较低',
    '满意', '满意'
),
-- 新增员工23（技术转管理的工程师）
(
    '李自成', '男', '13800000023', 34, '2018-09-28', '吉林',
    '985', '硕士', '工科', '电子信息工程',
    NULL, NULL, '软件科技公司', 10,
    '技术部', 3,
    'A-', 'B+', 'A', 
    'ENTJ', '中层', '已婚', '适中',
    '一般', '一般'
),
-- 新增员工24（年轻但有创新能力的设计师）
(
    '赵丽颖', '女', '13800000024', 27, '2021-11-20', '贵州',
    '普通', '本科', '文科', '广告学',
    '工科', '工业设计', '数字内容创作公司', 4,
    '设计部', 2,
    'A+', 'A', 'A+', 
    'INFP', '基层', '未婚', '较高',
    '满意', '较差'
),
-- 新增员工25（医学背景转行的产品经理）
(
    '肖战', '男', '13800000025', 32, '2019-08-01', '山西',
    '211', '硕士', '医科', '临床医学',
    '工科', '计算机科学与技术', '在线教育公司', 8,
    '产品部', 2,
    'A', 'A-', 'B+', 
    'INFJ', '中层', '已婚', '适中',
    '一般', '一般'
),
-- 新增员工26（农业科技领域专家）
(
    '易烊千玺', '男', '13800000026', 38, '2017-01-09', '甘肃',
    '985', '博士', '农科', '农学',
    NULL, NULL, '农业科技公司', 10,
    '技术部', 3,
    'A', 'A+', 'A', 
    'ISTJ', '高层', '有孩', '较低',
    '满意', '满意'
),
-- 新增员工27（绩效提升中的年轻人）
(
    '关晓彤', '女', '13800000027', 24, '2022-08-11', '青海',
    '普通', '本科', '文科', '汉语言文学',
    NULL, NULL, '数字内容创作公司', 2,
    '市场部', 1,
    'B', 'B+', 'A-', 
    'ESFJ', '基层', '未婚', '无房贷',
    '一般', '一般'
),
-- 新增员工28（多领域专业资深技术顾问）
(
    '白敬亭', '男', '13800000028', 45, '2014-05-20', '黑龙江',
    '985', '博士', '工科', '机械工程',
    '理科', '物理学', '传统制造业公司', 20,
    '技术部', 5,
    'A+', 'A', 'A+', 
    'INTJ', '高层', '已婚', '无房贷',
    '满意', '满意'
),
-- 新增员工29（跨界的创意总监）
(
    '杨紫', '女', '13800000029', 33, '2019-03-25', '内蒙古',
    '211', '硕士', '文科', '广告学',
    '工科', '数字媒体技术', '广告营销公司', 9,
    '设计部', 3,
    'A', 'A-', 'A', 
    'ENFP', '中层', '未婚', '适中',
    '满意', '一般'
),
-- 新增员工30（年轻有为的数据分析师）
(
    '王俊凯', '男', '13800000030', 28, '2021-02-16', '宁夏',
    '985', '硕士', '理科', '统计学',
    '工科', '大数据技术', '互联网金融公司', 5,
    '技术部', 2,
    'A-', 'A', 'A+', 
    'INTP', '基层', '未婚', '较低',
    '满意', '满意'
);

-- 添加项目经历数据
INSERT INTO project_experiences (employee_id, project_level, project_role) VALUES
-- 员工1的项目经历（2个项目）
(1, '重点项目', '技术或业务顾问'),
(1, '一般项目', '团队负责人'),

-- 员工2的项目经历（1个项目）
(2, '一般项目', '项目经理'),

-- 员工3的项目经历（3个项目）
(3, '重点项目', '项目总负责人'),
(3, '重点项目', '技术或业务顾问'),
(3, '一般项目', '项目总负责人'),

-- 员工4的项目经历（1个项目）
(4, '轻量级项目', '技术或业务执行岗'),

-- 员工5的项目经历（2个项目）
(5, '一般项目', '团队负责人'),
(5, '轻量级项目', '团队负责人'),

-- 员工6的项目经历（1个项目）
(6, '重点项目', '技术或业务执行岗'),

-- 员工7没有项目经历

-- 员工8的项目经历（2个项目）
(8, '重点项目', '技术或业务顾问'),
(8, '一般项目', '技术专家'),

-- 员工9的项目经历（1个项目）
(9, '一般项目', '团队负责人'),

-- 员工10的项目经历（1个项目）
(10, '轻量级项目', '项目经理'),

-- 新增员工11的项目经历（4个项目）
(11, '重点项目', '项目总负责人'),
(11, '重点项目', '技术或业务顾问'),
(11, '一般项目', '团队负责人'),
(11, '轻量级项目', '技术或业务专家'),

-- 新增员工12的项目经历（2个项目）
(12, '重点项目', '技术或业务专家'),
(12, '一般项目', '技术或业务顾问'),

-- 新增员工13的项目经历（1个项目）
(13, '一般项目', '技术或业务执行岗'),

-- 新增员工14的项目经历（5个项目）
(14, '重点项目', '项目总负责人'),
(14, '重点项目', '团队负责人'),
(14, '重点项目', '技术或业务顾问'),
(14, '一般项目', '项目经理'),
(14, '轻量级项目', '项目总负责人'),

-- 新增员工15的项目经历（2个项目）
(15, '重点项目', '技术或业务专家'),
(15, '一般项目', '团队负责人'),

-- 新增员工16没有项目经历

-- 新增员工17的项目经历（3个项目）
(17, '重点项目', '项目总负责人'),
(17, '一般项目', '项目经理'),
(17, '轻量级项目', '技术或业务顾问'),

-- 新增员工18的项目经历（1个项目）
(18, '一般项目', '支持保障岗'),

-- 新增员工19的项目经历（1个项目）
(19, '轻量级项目', '技术或业务执行岗'),

-- 新增员工20的项目经历（2个项目）
(20, '重点项目', '技术或业务顾问'),
(20, '重点项目', '技术或业务专家'),

-- 新增员工21的项目经历（2个项目）
(21, '一般项目', '团队负责人'),
(21, '一般项目', '项目经理'),

-- 新增员工22的项目经历（2个项目）
(22, '重点项目', '技术或业务顾问'),
(22, '一般项目', '团队负责人'),

-- 新增员工23的项目经历（3个项目）
(23, '重点项目', '团队负责人'),
(23, '一般项目', '项目经理'),
(23, '轻量级项目', '技术或业务专家'),

-- 新增员工24的项目经历（2个项目）
(24, '一般项目', '技术或业务专家'),
(24, '轻量级项目', '技术或业务执行岗'),

-- 新增员工25的项目经历（2个项目）
(25, '一般项目', '项目经理'),
(25, '轻量级项目', '团队负责人'),

-- 新增员工26的项目经历（3个项目）
(26, '重点项目', '项目总负责人'),
(26, '重点项目', '技术或业务专家'),
(26, '一般项目', '技术或业务顾问'),

-- 新增员工27的项目经历（1个项目）
(27, '轻量级项目', '技术或业务执行岗'),

-- 新增员工28的项目经历（5个项目）
(28, '重点项目', '项目总负责人'),
(28, '重点项目', '技术或业务顾问'),
(28, '重点项目', '技术或业务专家'),
(28, '一般项目', '项目经理'),
(28, '一般项目', '团队负责人'),

-- 新增员工29的项目经历（3个项目）
(29, '重点项目', '团队负责人'),
(29, '一般项目', '技术或业务专家'),
(29, '轻量级项目', '项目经理'),

-- 新增员工30的项目经历（2个项目）
(30, '一般项目', '技术或业务专家'),
(30, '轻量级项目', '技术或业务执行岗');

-- 添加职位变动记录
INSERT INTO position_changes (employee_id, change_date, position_change) VALUES
(1, '2020-06-15', '基层->中层'),
(3, '2017-04-10', '基层->中层'),
(3, '2019-09-22', '中层->高层'),
(5, '2021-02-18', '基层->中层'),
(8, '2023-12-10', '基层->中层'),
(9, '2018-05-20', '基层->中层'),
-- 新增员工的职位变动记录
(11, '2019-06-15', '基层->中层'),
(11, '2021-12-01', '中层->高层'),
(12, '2023-06-10', '基层->中层'),
(14, '2018-03-20', '中层->高层'),
(15, '2022-01-15', '基层->中层'),
(17, '2022-05-08', '中层->高层'),
(18, '2017-11-12', '基层->中层'),
(20, '2022-09-05', '中层->高层'),
(21, '2022-02-18', '基层->中层'),
(22, '2019-04-23', '中层->高层'),
(23, '2021-07-15', '基层->中层'),
(26, '2020-03-01', '中层->高层'),
(28, '2016-06-10', '中层->高层'),
(29, '2021-10-05', '基层->中层');

-- 为部分新增员工添加考勤记录示例
-- 员工11（优秀设计总监）的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '请假'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '请假'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(11, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工16（刚毕业应届生）的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '早退'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '迟到'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(16, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工19（表现不稳定的员工）的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '早退'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '迟到且早退'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '请假'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '请假'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '迟到'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(19, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工28（多领域专业资深技术顾问）的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '请假'),
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(28, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 为所有未添加考勤记录的员工添加考勤记录
-- 员工1的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '迟到'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(1, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工2的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '早退'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '迟到'),
(2, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

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
(3, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工4的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '迟到'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '早退'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '迟到且早退'),
(4, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工5的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '请假'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '请假'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(5, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工6的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '迟到'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '早退'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '迟到'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(6, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工7的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '迟到'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '早退'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '迟到且早退'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '迟到'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '迟到'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '早退'),
(7, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '迟到');

-- 员工8的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '请假'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(8, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工9的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '早退'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(9, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工10的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '请假'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '请假'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '早退'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(10, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工12的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '请假'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(12, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工13的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '迟到'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '迟到'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '早退'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '迟到'),
(13, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工14的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(14, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工15的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '早退'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(15, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工17的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '请假'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '请假'),
(17, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工18的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '迟到'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '迟到'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '早退'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '迟到'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '迟到且早退'),
(18, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工20的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(20, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工21的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '请假'),
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '请假'),
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(21, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '早退');

-- 员工22的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(22, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工23的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '请假'),
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '请假'),
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '请假'),
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(23, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工24的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '迟到'),
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '迟到'),
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '迟到'),
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '迟到'),
(24, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工25的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '早退'),
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '早退'),
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(25, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工26的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(26, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工27的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '迟到'),
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '迟到'),
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '迟到'),
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '迟到且早退'),
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '迟到'),
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '迟到'),
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '早退'),
(27, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '迟到');

-- 员工29的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '早退'),
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '正常'),
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '正常'),
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '请假'),
(29, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常');

-- 员工30的考勤
INSERT INTO attendance_records (employee_id, date, status) VALUES
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 30 DAY), '正常'),
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 29 DAY), '正常'),
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 28 DAY), '正常'),
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 27 DAY), '正常'),
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 26 DAY), '迟到'),
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 25 DAY), '正常'),
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 24 DAY), '正常'),
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 23 DAY), '早退'),
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 22 DAY), '正常'),
(30, DATE_SUB(CURRENT_DATE(), INTERVAL 21 DAY), '正常'); 