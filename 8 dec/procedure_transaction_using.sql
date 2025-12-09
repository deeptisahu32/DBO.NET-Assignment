create database dbo_db;


CREATE TABLE Department (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50)
);

INSERT INTO Department (DeptID, DeptName)
VALUES
(10, 'HR'),
(20, 'Finance'),
(30, 'IT'),
(40, 'Sales'),
(50, 'Operations');
-----------------------------------
CREATE TABLE Employee (
    EmpID INT IDENTITY(1,1) PRIMARY KEY,
    EmpName VARCHAR(100),
    Salary DECIMAL(10,2),
    DateOfJoin DATE,
    DeptID INT FOREIGN KEY REFERENCES Department(DeptID)
);

INSERT INTO Employee (EmpName, Salary, DateOfJoin, DeptID)
VALUES
('Aasritha', 52000, '2022-04-15', 30),
('Akshay', 60000, '2021-11-20', 30),
('Anvith Reddy', 48000, '2023-02-10', 10),
('ASHOK', 55000, '2021-07-18', 40),
('Deepalakshmi', 47000, '2022-01-25', 20),
('Deepti', 51000, '2023-03-12', 50),
('Dharani sri', 46000, '2020-09-30', 10),
('Humera', 62000, '2021-12-05', 30),
('Kanishka', 53000, '2022-05-09', 40),
('KEERTHANA', 45000, '2023-04-03', 20),
('Keerthi', 58000, '2021-03-22', 30),
('Keerthickragul', 54000, '2022-06-10', 50),
('Logeshwaran', 50000, '2020-11-17', 40),
('Madavi', 47000, '2023-01-08', 10),
('Manikanta', 61000, '2021-10-14', 30),
('Fatima', 49500, '2022-02-19', 20),
('Monika', 52000, '2023-05-22', 10),
('Nagamani', 47000, '2020-08-27', 50),
('Pooja', 45000, '2022-09-12', 40),
('Hymavathi', 48000, '2021-07-05', 10),
('Sairam Somaraju', 65000, '2020-05-18', 30),
('Sakthivel', 53000, '2022-03-24', 40),
('Usha sri', 45500, '2023-02-14', 20),
('Waseef', 62000, '2021-01-30', 30);


select * from Employee
select * from Department;


-- create procedure

create procedure pr_emp
as
select * from Employee

alter procedure pr_empbycond(@empid int,@sal int)
as
select * from Employee where empid=@empid and salary>@sal;

/**
Task-1 
Public void GetTransactions(d1 DateTime  , d2 DateTime) 
{ 
// logic to display all records from Employees who date of join  between 
2 dates using procedures 
}
**/

create procedure pr_getemployee(@d1 date,@d2 date)
as
select * from Employee where DateOfJoin between @d1 and @d2


/**
Public void GetCommonRecords(int id) 
{ 
// logic to display common records from Employee and department 
based on id  
}
**/

alter procedure pr_Getrecord(@id int)
as
select * from Employee as e
join Department as d
on
e.DeptID=d.DeptID
where d.DeptID=@id;

/**
Public void InsertRecordsusingtrans() 
{ 
// logic to insert records to employee and department using transaction 
}
**/

/**
Connected Insert + Fetch New Identity 
For a Employee table with an identity primary key: 
• Insert a new Employee using INSERT  command. 
• Immediately fetch the newly inserted identity using: 
o SCOPE_IDENTITY() 
• Validate that the ID exists by fetching it again with a new command.
**/

create procedure pr_insertemployee(@Empname varchar(20),@Sal int,@doj date,@did int)
as
begin
insert into Employee values(@Empname,@Sal,@doj,@did)
select Scope_identity()
end;

/**
Multi-Result Reader with Joins 
A company has Employees and Department tables. 
Write a C# program that: 
• Executes a single SqlCommand that returns two result sets: 
1. List of employees 
2. List of Departments 
• Reads first result set via SqlDataReader.Read(), then moves to the next 
using NextResult(). 
**/

/**
Using Stored Procedure That Returns Multiple Output Parameters 
Stored procedure: 
sp_GetEmployeeDet 
   @Empid, 
   @DateofJoin OUTPUT, 
   @Department  OUTPUT 
Task: 
• Call this stored procedure using SqlCommand in connected mode. 
• Retrieve output parameters. 
• Display formatted summary. 
• Check if connection is opened or not, display appropriate message if connection is 
not opened 
• Handle exception for all methods using SqlException Class 
• Pass all the data dynamically. 
• Using single connection for all above operations
**/

create procedure sp_GetEmployeeDet (@Empid int,@Dateofjoin datetime output,@Department varchar output)
as
begin
select @Dateofjoin=e.DateOfJoin,@Department=d.deptname from employee as e
join department as d
on e.DeptID=d.deptid
where @Empid=EmpID
end;