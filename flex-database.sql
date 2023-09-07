create database flex;

use [flex]

create table users(
users_id int,
password varchar(50),
user_type varchar(50),

constraint pk_users primary key(users_id)
);

create table academics(
admin_id int,
Fname varchar(50),
Lname varchar(50),
email varchar(50),
cnic varchar(50),
phone varchar(50),
users_id int,

constraint pk_academics primary key(admin_id),
constraint fk_academics foreign key(users_id) references users(users_id) on update cascade on delete cascade
);

create table faculty(
Teacher_id int,
Fname varchar(50),
Lname varchar(50),
email varchar(50),
cnic varchar(50),
phone varchar(50),
users_id int,

constraint pk_faculty primary key(teacher_id),
constraint fk_faculty foreign key(users_id) references users(users_id) on update cascade on delete cascade
);

create table sections(
section varchar(50),

constraint pk_section primary key(section)
);

create table student(
roll varchar(50),
Fname varchar(50),
Lname varchar(50),
email varchar(50),
cnic varchar(50),
phone varchar(50),
batch numeric(20),
section varchar(50),
DoB varchar(50),
gender varchar(50),
Father_Name varchar(50),
users_id int,

constraint pk_student primary key(roll),
constraint fk_student foreign key(users_id) references users(users_id) on update cascade on delete cascade,
constraint fk_student_section foreign key(section) references sections(section)
);

create table course(
code varchar(50),
course_name varchar(100),
course_type varchar(50),
credit_hours int,
coordinator_id int,

constraint pk_course primary key(code),
constraint fk_course foreign key(coordinator_id) references faculty(teacher_id)
);

create table pre_requisite(
sr# int,
course_ID varchar(50),
pre_req_ID varchar(50),
);

create table attendance(
student_roll varchar(50),
course_id varchar(50),
Attend_Date varchar(50),
teacher_id int,
a_status varchar(50),

constraint fk_attendance_student foreign key(student_roll) references student(roll),
constraint fk_attendance_course foreign key(course_id) references course(code),
constraint fk_attendance_teacher foreign key(teacher_id) references faculty(teacher_id)
);

create table teaches(
teacher_id int,
section_name varchar(50),
course_id varchar(50),

constraint fk_teaches_teacher foreign key(teacher_id) references faculty(teacher_id) on update cascade on delete cascade,
constraint fk_teaches_section foreign key(section_name) references sections(section),
constraint fk_teaches_course foreign key(course_id) references course(code)
);

create table registered(
student_roll varchar(50),
course_id varchar(50)
);

create table rating_types(
sr# int,
question varchar(50),

constraint pk_rtypes primary key(question)
);

create table eval_type(
tid varchar(50),
etype varchar(50)

constraint pk_etype primary key(tid)
);

create table feedback(
student_roll varchar(50),
teacher_id int,
course_id varchar(50),
rating int,
rtype varchar(50)

constraint fk_feedback_student foreign key(student_roll) references student(roll),
constraint fk_feedback_teacher foreign key(teacher_id) references faculty(teacher_id) on update cascade on delete cascade,
constraint fk_feedback_course foreign key(course_id) references course(code),
constraint fk_feedback_rtype foreign key(rtype) references rating_types(question)
);

create table evaluation(
eid int,
tid varchar(50),
weightage int,
total int,
course_id varchar(50),

constraint pk_evaluation primary key(eid),
constraint fk_evaluation_course foreign key(course_id) references course(code),
constraint fk_evaluation_task foreign key(tid) references eval_type(tid),
);

create table student_work(
student_roll varchar(50),
eval_id int,
obtained int,

constraint fk_swork_student foreign key(student_roll) references student(roll),
constraint fk_swork_eval foreign key(eval_id) references evaluation(eid)
);




--bulk inserting data


GO
-- import the file
BULK INSERT users
FROM 'C:\Users\HP\Desktop\attempt\user.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT academics
FROM 'C:\Users\HP\Desktop\attempt\acedemic_officer.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT faculty
FROM 'C:\Users\HP\Desktop\attempt\faculty.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT student
FROM 'C:\Users\HP\Desktop\attempt\student.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT sections
FROM 'C:\Users\HP\Desktop\attempt\Section.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT course
FROM 'C:\Users\HP\Desktop\attempt\Courses.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT pre_requisite
FROM 'C:\Users\HP\Desktop\attempt\pre_req.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT attendance
FROM 'C:\Users\HP\Desktop\attempt\attendance.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT teaches
FROM 'C:\Users\HP\Desktop\attempt\Teaches.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT registered
FROM 'C:\Users\HP\Desktop\attempt\Registered.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT rating_types
FROM 'C:\Users\HP\Desktop\attempt\Rating_Type.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT eval_type
FROM 'C:\Users\HP\Desktop\attempt\Eval_Type.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT feedback
FROM 'C:\Users\HP\Desktop\attempt\feedback.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT evaluation
FROM 'C:\Users\HP\Desktop\attempt\evaluation.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

GO
-- import the file
BULK INSERT student_work
FROM 'C:\Users\HP\Desktop\attempt\student_works.csv'
WITH(FORMAT='CSV', FIRSTROW=2, CODEPAGE='65001')
GO

SELECT s.roll, s.Fname, s.Lname, se.section, c.course_name
FROM student s
JOIN registered r ON s.roll = r.student_roll
JOIN teaches t ON r.course_id = t.course_id
JOIN sections se ON t.section_name = se.section
JOIN course c ON t.course_id = c.code
ORDER BY se.section, c.course_name;

SELECT s.roll, s.Fname, s.Lname, se.section, c.course_name FROM student s JOIN registered r ON s.roll = r.student_roll JOIN teaches t ON r.course_id = t.course_id JOIN sections se ON t.section_name = se.section JOIN course c ON t.course_id = c.code WHERE se.section ='CS-4A' ORDER BY se.section, c.course_name;

SELECT attendance.student_roll, student.Fname, student.Lname, attendance.Attend_Date, attendance.a_status
FROM attendance
JOIN student ON attendance.student_roll = student.roll
JOIN teaches ON attendance.course_id = teaches.course_id AND attendance.teacher_id = teaches.teacher_id
WHERE teaches.teacher_id = 824
AND teaches.course_id = 'CS-2048'

SELECT attendance.student_roll, student.Fname, student.Lname, attendance.Attend_Date, attendance.a_status, student.section
FROM attendance
JOIN student ON attendance.student_roll = student.roll
JOIN teaches ON attendance.course_id = teaches.course_id AND attendance.teacher_id = teaches.teacher_id
WHERE teaches.teacher_id = 824
AND teaches.course_id = 'CS-2048'
AND student.section = 'CS-4A'

SELECT student.roll, student.Fname, student.Lname, attendance.course_id, course.course_name, attendance.Attend_Date, attendance.a_status
FROM attendance
JOIN course ON attendance.course_id = course.code
JOIN student ON attendance.student_roll = student.roll
WHERE attendance.student_roll = '21i-0379'



SELECT f.Fname, f.Lname, c.course_name
FROM faculty f
JOIN teaches t ON f.Teacher_id = t.teacher_id
JOIN course c ON t.course_id = c.code
WHERE f.Teacher_id = 824;

select * from course
select *from evaluation
delete from evaluation
delete from student_work



--view marks
SELECT s.roll, s.Fname, s.Lname, c.course_name, sw.obtained, e.total
FROM student s
JOIN registered r ON s.roll = r.student_roll
JOIN evaluation e ON r.course_id = e.course_id
JOIN student_work sw ON s.roll = sw.student_roll AND e.eid = sw.eval_id
JOIN course c ON r.course_id = c.code
WHERE s.roll = '21i-7421' AND r.course_id = 'CS-2048'
GROUP BY s.roll, s.Fname, s.Lname, c.course_name, sw.obtained, e.total
delete from sections where section='CS-4C'
select *from sections
select *from student

select * from registered

SELECT s.roll, s.Fname, s.Lname, s.email, se.section, COALESCE(c.course_name, '') AS course_name 
FROM student s 
JOIN sections se ON s.section = se.section 
LEFT OUTER JOIN registered r ON s.roll = r.student_roll 
LEFT OUTER JOIN teaches t ON r.course_id = t.course_id AND t.section_name = se.section 
LEFT OUTER JOIN course c ON t.course_id = c.code 
WHERE se.section = 'CS-4A' 
ORDER BY se.section, c.course_name;


SELECT r.course_id, c.course_name
FROM registered r
JOIN student s ON r.student_roll = s.roll
JOIN sections se ON s.section = se.section
LEFT OUTER JOIN course c ON r.course_id = c.code
WHERE se.section = 'CS-4A' AND s.roll = '21i-8889';



SELECT s.roll, s.Fname, s.Lname, s.email, se.section, STRING_AGG(c.course_name, ', ') AS course_names
FROM student s
JOIN sections se ON s.section = se.section
LEFT OUTER JOIN registered r ON s.roll = r.student_roll
LEFT OUTER JOIN teaches t ON r.course_id = t.course_id AND t.section_name = se.section
LEFT OUTER JOIN course c ON t.course_id = c.code
WHERE se.section = 'CS-4A'
GROUP BY s.roll, s.Fname, s.Lname, s.email, se.section
ORDER BY se.section, s.Lname, s.Fname;

SELECT s.roll, s.Fname, s.Lname, s.email, se.section, c.course_name
FROM student s
JOIN sections se ON s.section = se.section
JOIN registered r ON s.roll = r.student_roll
LEFT OUTER JOIN teaches t ON r.course_id = t.course_id AND t.section_name = se.section
LEFT OUTER JOIN course c ON t.course_id = c.code
WHERE se.section = 'CS-4A'
ORDER BY se.section, s.Lname, s.Fname, c.course_name;

SELECT s.roll, s.Fname, s.Lname, s.email, se.section, c.course_name
FROM (
  SELECT r.student_roll, r.course_id
  FROM registered r
  JOIN student s ON r.student_roll = s.roll
  JOIN sections se ON s.section = se.section
  WHERE se.section = 'CS-4A'
) AS rc
JOIN student s ON rc.student_roll = s.roll
JOIN sections se ON s.section = se.section
JOIN course c ON rc.course_id = c.code
WHERE se.section = 'CS-4A'
ORDER BY s.roll, c.course_name;
--for transcript
select evaluation.eid, evaluation.tid, eval_type.tid as e_type, student_work.obtained, evaluation.total, evaluation.weightage
from student_work inner join evaluation on student_work.eval_id = evaluation.eid inner join eval_type on evaluation.tid = eval_type.etype
where student_work.student_roll = '21i-7421' and evaluation.course_id = 'CS-2048';

--for gpa
select (sum(tbl.obtained*tbl.weightage)/sum(tbl.total)) as grand_total
from (select evaluation.eid, evaluation.tid, eval_type.tid as e_type, student_work.obtained, evaluation.total, evaluation.weightage
from student_work inner join evaluation on student_work.eval_id = evaluation.eid inner join eval_type on evaluation.tid = eval_type.etype
where student_work.student_roll = '21i-7421' and evaluation.course_id = 'CS-2048') as tbl
where tbl.e_type = 'Assignment';

SELECT tbl.e_type, (SUM(tbl.obtained*tbl.weightage)/SUM(tbl.total)) AS grand_total
FROM (
    SELECT evaluation.eid, evaluation.tid, eval_type.tid AS e_type, student_work.obtained, evaluation.total, evaluation.weightage
    FROM student_work
    INNER JOIN evaluation ON student_work.eval_id = evaluation.eid
    INNER JOIN eval_type ON evaluation.tid = eval_type.etype
    WHERE student_work.student_roll = '21i-7421' AND evaluation.course_id = 'CS-2048' AND eval_type.tid = 'Assignment'
) AS tbl
GROUP BY tbl.e_type;

select * from feedback

select sum(gt_tbl.grand_total) as student_grand_total
from (select (sum(tbl.obtained*tbl.weightage)/sum(tbl.total)) as grand_total
from (select evaluation.eid, evaluation.tid, eval_type.tid as e_type, student_work.obtained, evaluation.total, evaluation.weightage
from student_work inner join evaluation on student_work.eval_id = evaluation.eid inner join eval_type on evaluation.tid = eval_type.etype
where student_work.student_roll = '21i-7421' and evaluation.course_id = 'CS-2048') as tbl
group by tbl.e_type) as gt_tbl;

SELECT * 
FROM feedback
WHERE teacher_id = 195 



delete from attendance where Attend_Date='05/09/2023'



select *from attendance where course_id='CS-2048'

SELECT f.Fname, f.Lname, c.course_name
FROM faculty f
JOIN teaches t ON f.Teacher_id = t.teacher_id
JOIN course c ON t.course_id = c.code
WHERE f.users_id = 6289




SELECT f.Fname, f.Lname, c.course_name FROM faculty f JOIN teaches t ON f.Teacher_id = t.teacher_id JOIN course c ON t.course_id = c.code WHERE f.Teacher_id = 824



SELECT attendance.student_roll, student.Fname, student.Lname, attendance.Attend_Date, attendance.a_status, student.section FROM attendance JOIN student ON attendance.student_roll = student.roll JOIN teaches ON attendance.course_id = teaches.course_id AND attendance.teacher_id = teaches.teacher_id WHERE teaches.teacher_id = 824




SELECT s.roll, s.Fname, s.Lname, c.course_name, sw.obtained, e.total FROM student s JOIN registered r ON s.roll = r.student_roll JOIN evaluation e ON r.course_id = e.course_id JOIN student_work sw ON s.roll = sw.student_roll AND e.eid = sw.eval_id JOIN course c ON r.course_id = c.code WHERE s.roll = '21i-7421' GROUP BY s.roll, s.Fname, s.Lname, c.course_name, sw.obtained, e.total


SELECT s.roll, s.Fname, s.Lname, c.course_name, c.credit_hours, sw.obtained 
FROM student s 
INNER JOIN registered r ON s.roll = r.student_roll 
INNER JOIN course c ON r.course_id = c.code 
LEFT JOIN evaluation e ON c.code = e.course_id 
LEFT JOIN student_work sw ON e.eid = sw.eval_id AND s.roll = sw.student_roll 
WHERE s.roll = '21i-7421'

SELECT s.roll, s.Fname, s.Lname, c.course_name, c.credit_hours, sw.obtained 
FROM student s 
INNER JOIN registered r ON s.roll = r.student_roll 
INNER JOIN course c ON r.course_id = c.code 
LEFT JOIN teaches t ON c.code = t.course_id AND s.section = t.section_name
LEFT JOIN evaluation e ON c.code = e.course_id AND t.teacher_id = e.tid
LEFT JOIN student_work sw ON e.eid = sw.eval_id AND s.roll = sw.student_roll 
WHERE s.roll = '21i-7421'


SELECT distinct c.code, c.course_name, c.credit_hours, sw.obtained 
FROM student s 
INNER JOIN registered r ON s.roll = r.student_roll 
INNER JOIN course c ON r.course_id = c.code 
LEFT JOIN evaluation e ON c.code = e.course_id 
LEFT JOIN student_work sw ON e.eid = sw.eval_id AND s.roll = sw.student_roll 
WHERE s.roll = '21i-7421'




SELECT c.code AS course_code, 
       c.course_name, 
       e.obtained, 
       e.eval_id, 
       SUM(e.obtained) / SUM(ev.total)*100 AS percentage
FROM student_work e  
JOIN evaluation ev ON e.eval_id = ev.eid   
JOIN course c ON ev.course_id = c.code
WHERE e.student_roll = '21i-7421'
GROUP BY c.code, c.course_name, e.obtained, e.eval_id  
ORDER BY course_code;

SELECT distinct c.code AS course_code, 
       c.course_name,
       ev.total AS total_marks,  
       e.obtained, 
       e.eval_id, 
       SUM(e.obtained) / SUM(ev.total)*100 AS percentage
FROM student_work e  
JOIN evaluation ev ON e.eval_id = ev.eid   
JOIN course c ON ev.course_id = c.code
WHERE e.student_roll = '21i-7421'
GROUP BY c.code, c.course_name, ev.total,  e.obtained, e.eval_id
ORDER BY course_code;



SELECT c.code AS course_code,
       c.course_name,
       ev.total AS total_marks,  
       e.obtained, 
       e.eval_id,
       CASE
          WHEN SUM(e.obtained)/SUM(ev.total)*100 >= 90 THEN 'A+'  
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 86 AND 89 THEN 'A' 
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 82 AND 85 THEN 'A-'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 78 AND 81 THEN 'B+' 
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 74 AND 77 THEN 'B'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 70 AND 73 THEN 'B-' 
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 66 AND 69 THEN 'C+'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 62 AND 65 THEN 'C'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 58 AND 61 THEN 'C-'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 54 AND 57 THEN 'D+'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 50 AND 53 THEN 'D'
          ELSE 'F'
       END AS letter_grade
FROM student_work e  
JOIN evaluation ev ON e.eval_id = ev.eid   
JOIN course c ON ev.course_id = c.code
WHERE e.student_roll = '21i-7421'       
GROUP BY c.code, c.course_name, ev.total,  e.obtained, e.eval_id      
ORDER BY course_code;

SELECT c.code AS course_code,
       c.course_name,  
       ev.total AS total_marks,      
       SUM(e.obtained) obtained,
       CASE  WHEN SUM(e.obtained)/SUM(ev.total)*100 >= 90 THEN 'A+'  
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 86 AND 89 THEN 'A' 
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 82 AND 85 THEN 'A-'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 78 AND 81 THEN 'B+' 
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 74 AND 77 THEN 'B'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 70 AND 73 THEN 'B-' 
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 66 AND 69 THEN 'C+'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 62 AND 65 THEN 'C'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 58 AND 61 THEN 'C-'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 54 AND 57 THEN 'D+'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 50 AND 53 THEN 'D'
          ELSE 'F'
         
       END AS letter_grade
FROM student_work e  
JOIN evaluation ev ON e.eval_id = ev.eid   
JOIN course c ON ev.course_id = c.code
WHERE e.student_roll = '21i-7421'       
GROUP BY c.code, c.course_name,ev.total      
ORDER BY course_code;



SELECT c.code AS course_code,  
       c.course_name,       
       CASE 
          WHEN SUM(e.obtained)/SUM(ev.total)*100 >= 90 THEN 'A+'   
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 86 AND 89 THEN 'A'
		   WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 82 AND 85 THEN 'A-'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 78 AND 81 THEN 'B+' 
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 74 AND 77 THEN 'B'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 70 AND 73 THEN 'B-' 
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 66 AND 69 THEN 'C+'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 62 AND 65 THEN 'C'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 58 AND 61 THEN 'C-'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 54 AND 57 THEN 'D+'
          WHEN SUM(e.obtained)/SUM(ev.total)*100 BETWEEN 50 AND 53 THEN 'D'
          
          ELSE 'F'  
       END AS letter_grade
FROM student_work e  
JOIN evaluation ev ON e.eval_id = ev.eid    
JOIN course c ON ev.course_id = c.code
WHERE e.student_roll = '21i-7421'       
GROUP BY c.code, c.course_name       
ORDER BY course_code;