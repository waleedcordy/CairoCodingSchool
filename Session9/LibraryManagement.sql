--Library Management
--Think and design a Library Management System.
--Assume any requirements you need and provide a clear description of your design.
--Provide a full script for creating the database, including all necessary tables.
--Include INSERT statements for sample records in each table.
--Tables can be included:
--Books
--Members
--Borrowings
--You may add additional tables as needed — use your judgment to design a
--complete, functional system.

Create table Books(

BookId int identity(1,1) primary key,
BookName varchar(255) not null unique,
AuthorName varchar(255) not null,

)

create Table Members(

MemberId int identity(1,1) primary key,
MemberName varchar(255) not null unique,
RegestirationDate DateTime DEFAULT GETDATE(),
BirthDate Date,

)

create table Borrowings(

BorrowingId int identity(1,1) primary key,
BorrowingDateTime DateTime Default GETDATE() not null,
ReturningBackDate DateTime ,
MemberId int,
BookId int,
Foreign key (MemberId) REFERENCES Members(MemberId),
Foreign key (BookId) REFERENCES Books(BookId)

)

insert into books values('Harry Potter 1' , 'J.K.Rowling');
insert into books values('Harry Potter 2' , 'J.K.Rowling');
insert into books values('Harry Potter 3' , 'J.K.Rowling');
insert into books values('Harry Potter 4' , 'J.K.Rowling');
insert into books values('Harry Potter 5' , 'J.K.Rowling');
insert into books values('Harry Potter 6' , 'J.K.Rowling');

insert into members (MemberName,BirthDate) values ('Waleed','2020-01-01');
insert into members (MemberName,BirthDate) values ('Ahmed','2024-01-01');
insert into members (MemberName,BirthDate) values ('Luke','2023-01-01');
insert into members (MemberName,BirthDate) values ('Toby','2022-01-01');
insert into members (MemberName,BirthDate) values ('John','2021-01-01');

insert into Borrowings (memberid,bookid) values (1,1);
insert into Borrowings (memberid,bookid) values (2,2);
insert into Borrowings (memberid,bookid) values (2,3);
insert into Borrowings (memberid,bookid) values (1,2);
insert into Borrowings (memberid,bookid) values (2,4);
insert into Borrowings (memberid,bookid) values (3,5);