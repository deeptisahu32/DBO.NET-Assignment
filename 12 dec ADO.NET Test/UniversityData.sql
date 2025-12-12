create database Universitydbsystem;
-------------------------------------------------------------------------
create table Students
(
StudentId int identity(1,1) primary key,
FullName varchar(100) not null,
Email varchar(100) unique,
Department varchar(50) not null,
YearOfStudy int not null
);
insert into Students values
('Ananya Rao','ananyarao@example.edu','Computer Science',3),
('Vikram Sharma','vikramsharma@example.edu','Electrical',2),
('Meera','meera@example.edu','Mechanical',4),
('Karthik Kumar','karthikkumar@example.edu','Civil',1),
('Priya Gupta','priyagupta@example.edu','Information Tech',5);
-------------------------------------------------------------------------------------
create table Courses
(
CourseId int identity(1,1) primary key,
CourseName varchar(100) not null,
Credits int not null,
Semester varchar(20) not null
);

insert into Courses values
('Data Structures',4,'Semester 3'),
('Database Systems',3,'Semester 4'),
('Operating Systems',4,'Semester 5'),
('Computer Networks',3,'Semester 5'),
('Software Engineering',3,'Semester 6'),
('Discrete Mathematics',4,'Semester 2');
------------------------------------------------------------------------------------------------

create table Enrollments
(
EnrollmentId int identity(1,1) primary key,
StudentId int not null,
CourseId int not null,
EnrollDate datetime not null,
Grade varchar(5) null,
constraint FK_Enrollments_Students foreign key(StudentId) references Students(StudentId),
constraint Fk_Enrollments_Courses foreign key(CourseId) references Courses(CourseId)
)
insert into Enrollments values
(1,1,getdate(),'A'),
(1,2,getdate(),'A-'),
(2,3,getdate(),'B+'),
(2,4,getdate(),NULL),
(3,2,getdate(),'B'),
(3,5,getdate(),'A'),
(4,6,getdate(),'B-'),
(5,1,getdate(),'A'),
(5,4,getdate(),NULL);

select * from Students;
select * from Courses;
select * from Enrollments;
-- for question 2 of connected

create procedure InsertStudent
@FullName varchar(100),
@Email varchar(100)=null,
@Department varchar(50),
@YearOfStudy int
as
begin
insert into Students(FullName,Email,Department,YearOfStudy)
values(@FullName,@Email, @Department, @YearOfStudy);

select cast(scope_identity() as int) as NewStudentId;
end;


--  Question 5 ceating procedure


alter procedure usp_GetCoursesBySemester @semester varchar(20)
as 
begin
select * from Courses
where Semester=@semester
end;

exec usp_GetCoursesBySemester 'Semester 2';