--Online Course Platform
--The Online Course Platform is a database system that stores and manages
--information about students, available courses, and enrollments. It simulates how
--an actual e-learning site (like Coursera or Udemy) might structure its data to
--support course management, student registrations, and reporting features.

--1. Students
--Represents users who register and enroll in courses.
--Columns:
--StudentID (Primary Key, Auto-Increment)
--Name (Required)
--Email (Required, Unique)
--Age (Must be 16 or older)
--Country (Defaults to Egypt if not provided)

--2. Courses
--Represents the available courses in the platform.
--Columns:
--CourseID (Primary Key, Auto-Increment)
--CourseName (Required)
--Category (e.g., Programming, Business, Design)
--Price (Must be greater than zero)

--3.Enrollments
--Represents relationship between Students and Courses.
--Columns:
--EnrollmentID (Primary Key, Auto-Increment)
--StudentID (Foreign Key → Students)
--CourseID (Foreign Key → Courses)
--EnrollDate (Defaults to current date)

--Create Table and insert data into each table
--Find Students from usa , ordered by age
--Find students where age between 20-30 (use between)
--After Create Tables Add col CreatedDate in student table (Google it)
--Rename col Price in Course table to Course_Price(Google it)
--Select only the first 3 records of the Enrollment table(TOP)

create table Students(
StudentId int identity(1,1) primary key,
StudentName VARCHAR(255) not null,
Email varchar(255) not null unique,
Age int check(Age >= 16),
Country varchar(255) default 'Egypt'
)

create table Courses(
CourseID int identity(1,1) primary key,
CourseName varchar(255) not null,
Category varchar(255),
Price Decimal(10,3) check (Price > 0)
)

create table Enrollments(
EnrollmentID int identity(1,1) primary key,
StudentID int,
CourseId int,
EnrollDate DATETIME DEFAULT GETDATE(),
Foreign key (StudentID) REFERENCES Students(StudentId) ,
Foreign key (CourseId) References Courses(CourseID)
)


Insert into Students VALUES('Waleed' , 'waleed.cordy@gdsfgf.com',  17, 'USA' );
Insert into Students VALUES('Ahmed' , 'ahmed@gdsfgf.com',  33, 'Egypt' );
Insert into Students VALUES('Luke' , 'luke@gdsfgf.com',  39, 'Germany' );
Insert into Students VALUES('Toby' , 'toby@gdsfgf.com',  50, 'France' );
Insert into Students VALUES('John' , 'john@gdsfgf.com',  24, 'Qatar' );
Insert into Students VALUES('Mohammed' , 'mohammed@gdsfgf.com',  44, 'Lebanon' );
Insert into Students VALUES('Waleed1' , 'waleed.cordy1@gdsfgf.com',  17, 'USA' );
Insert into Students VALUES('Ahmed1' , 'ahmed@gdsfgf1.com',  33, 'Egypt' );
Insert into Students VALUES('Luke1' , 'luke@gdsfgf1.com',  39, 'Germany' );
Insert into Students VALUES('Toby1' , 'toby@gdsfgf1.com',  50, 'France' );
Insert into Students VALUES('John1' , 'john@gdsfg1f.com',  24, 'USA' );
Insert into Students VALUES('Mohammed1' , 'mohammed@gdsfg1f.com',  44, 'Lebanon' );

insert into Courses values('C#','Programming',500);
insert into Courses values('VB','Programming',1000);
insert into Courses values('Marketing with coach','Sales & Marketing',2000);
insert into Courses values('Excel','Accounting',101);


insert into enrollments (StudentId, CourseID) values(1,1);
insert into enrollments (StudentId, CourseID) values(1,2);
insert into enrollments (StudentId, CourseID) values(1,3);
insert into enrollments (StudentId, CourseID) values(1,4);
insert into enrollments (StudentId, CourseID) values(2,1);
insert into enrollments (StudentId, CourseID) values(2,2);
insert into enrollments (StudentId, CourseID) values(2,3);
insert into enrollments (StudentId, CourseID) values(2,4);
insert into enrollments (StudentId, CourseID) values(3,1);
insert into enrollments (StudentId, CourseID) values(3,2);
insert into enrollments (StudentId, CourseID) values(3,3);
insert into enrollments (StudentId, CourseID) values(3,4);
insert into enrollments (StudentId, CourseID) values(4,1);
insert into enrollments (StudentId, CourseID) values(4,2);
insert into enrollments (StudentId, CourseID) values(4,3);
insert into enrollments (StudentId, CourseID) values(4,4);

select * from students where Country = 'USA' order by age 
select * from Students where Age between 20 and 30

ALTER TABLE Students ADD CreatedDate DateTime;

--EXEC sp_rename 'Courses.Price', 'Course_Price', 'COLUMN';
--gives this error : Object 'Courses.Price' cannot be renamed because the object participates in enforced dependencies.

select top(3) * from enrollments