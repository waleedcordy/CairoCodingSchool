--Scenario: Company HR System

--Stores details about the employee, such as name, id, title, department, age, address, phone, photo, salary, national id, fingerprint
--Stores company departments.
--Stores company projects.
--One Project can belong to one department.
--Each task belongs to one project.
--One employee can belong to one department.
--Employees can work on multiple projects, and projects can have multiple employees.
--One employee can work on many tasks.

--Retrieve employee names and titles where age > 30
--Retrieve employees from a specific department.
--Find the minimum salary.
--Find employees whose name starts with A.
--Find employees whose email contains gmail.
--Find employees without a phone number.
--Retrieve employees from multiple departments.
--Sort employees by age.
--Classify employees by age group.

--Age < 30 'Junior'
--Age BETWEEN 30 AND 40 'Mid Level'
--ELSE 'Senior'



--Stores company departments.
Create Table Departments(
DepartmentId int identity(1,1) primary key,
Name varchar(255) not null unique,
);

--Stores company projects.
--One Project can belong to one department.
Create Table Projects(
ProjectId int identity(1,1) primary key,
Name varchar(255) not null unique,
DepartmentId int not null,
Foreign Key (DepartmentId) References Departments (DepartmentId)
);

--Each task belongs to one project.
Create Table Tasks(
TaskId int identity(1,1) primary key,
Name varchar(255) not null unique, 
ProjectId int not null,
Foreign Key (ProjectId) REFERENCES Projects(ProjectId)
);

--Stores details about the employee, such as name, id, title, department, age, address, phone, photo, salary, national id, fingerprint
--One employee can belong to one department.
Create Table Employees(
EmployeeId int identity(1,1) primary key , 
Name varchar(255) not null unique,
Title varchar(255) not null,
DepartmentId int not null,
Age int ,
Address varchar(255),
Phone varchar(20),
Photo binary,
Salary int ,
NationalId bigint,
FingerPrint binary,
Foreign key (DepartmentId) REFERENCES Departments (DepartmentId),
);

--Employees can work on multiple projects, and projects can have multiple employees.
Create Table EmployeesProjects(
EmployeeId int not null,
ProjectId int not null,
primary key (EmployeeId, ProjectId),
Foreign key (EmployeeId) references Employees(EmployeeId),
Foreign Key (ProjectId) references Projects(ProjectId)
);

--One employee can work on many tasks.
Create Table EmployeesTasks(
EmployeeId int not null,
TaskId int not null,
primary key (EmployeeId, TaskId),
Foreign key (EmployeeId) references Employees(EmployeeId),
Foreign Key (TaskId) references Tasks(TaskId)
);


--Retrieve employee names and titles where age > 30
Select Name, Title from Employess where Age >30;

--Retrieve employees from a specific department.
Select * from Employees where Departmentid = 1;

--Find the minimum salary.
Select Min(Salary) from Employees;

--Find employees whose name starts with A.
Select * from Employees where Name like 'A%';

--Find employees whose email contains gmail.
Select * from Employees where email like '%gmail.com%';

--Find employees without a phone number.
select * from employess where phone is null;

--Retrieve employees from multiple departments.
select * from Employess where DepartmentId in (1,2,3);

--Sort employees by age.
select * from employees order by age;

--Classify employees by age group.


--Age < 30 'Junior'
--Age BETWEEN 30 AND 40 'Mid Level'
--ELSE 'Senior'

Select 
	Name, Age,
	Case
		When Age < 30 then 'Junior'
		When Age between 30 and 40 then 'Mid Level'
		else default_value
		End as Class     
from Employees;
