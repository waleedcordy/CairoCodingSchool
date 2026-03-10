--Scenario: Library Management System

--Members → people who borrow books
--MemberProfile → optional info like photo, ID (1:1 with Members)
--Books → books available in the library
--Authors → authors who write books (1:N Author → Books)
--Borrowings → which members borrow which books (M:N between Members and
--Books)
--Categories → each book can belong to multiple categories (M:N Book ↔ Category)


create table Members(
MemberId  int identity(1,1) primary key,
MemberName varchar(255) not null unique,

);

create table MemberProfile(
MemberId int primary key,
NationalId bigint not null,
Photo binary ,
foreign key (MemberId) references Members(MemberId)
);

create table Authors(
AuthorId int identity(1,1) primary key,
AuthorName varchar(255) not null unique
);

Create table Books(
BookId int identity(1,1) primary key,
BookName varchar(255) not null unique,
AuthorId int,
Foreign Key (AuthorId) References Authors(AuthorId)
);


Create table Categories(
CategoryId int identity(1,1) primary key,
CategoryName varchar(255) not null unique,
);

Create table BooksCategories(
BookId int not null,
CategoryId int not null,
primary key (BookId, CategoryId),
Foreign Key (BookId) References Books(BookId),
Foreign Key (CategoryId) References Categories(CategoryId)
);

Create Table Borrowings(
BorrwingId int identity(1,1) primary key,
MemberId int not null,
BookId int not null,
BorrowedOn DateTime Default GetDate() not null,
ReturnedOn DateTime null,
Foreign key (MemberId) References Members(MemberId),
Foreign key (BookId) References Books(BookId),
);



