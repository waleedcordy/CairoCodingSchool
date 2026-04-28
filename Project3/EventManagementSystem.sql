--Project: Event Management System
--Overview
--The Event Management System is a console-based application designed
--to manage events, venues, organizers, attendees, and tickets. This system
--will allow users to track events, assign organizers and venues, register
--attendees, and manage ticket sales and check-ins. It will be implemented
--using C# classes, SQL database design with relationships, and LINQ
--queries to perform complex data operations.

--Organizer Properties:
--Id, Name, ContactEmail
--Represents the person or organization hosting events.
--Venue Properties:
--Id, Name, Location, Capacity
--Represents the physical location where events are held.
--Event Properties:
--Id, Title, OrganizerId, VenueId, EventDate
--Represents a specific event organized by an organizer at a venue on a date.
--Attendee Properties:
--Id, Name, Email
--Represents a person attending one or more events.
--Ticket Properties:
--Id, EventId, AttendeeId, Price, CheckedIn
--Represents a ticket purchased by an attendee for a specific event.

--SQL Requirements for SQL design
--Include at least 5–10 sample rows per table for testing.
--Ensure foreign key relationships are properly defined.

Create Table Organizers(
OrganizerId int primary key,
Name varchar(50) unique not null,
Email varchar(50)
)

Create Table Venues(
VenueId int identity(1,1) primary key,
Name varchar(50) not null unique,
Location varchar(100) not null unique,
Capacity int not null check(Capacity >0)
)

Create Table Attendees(
AttendeeId int identity(1,1) primary key,
Name varchar(50) not null unique,
Email varchar(50)
)

Create Table Events(
EventId int identity(1,1) primary key,
Title varchar(50) not null unique,
OrganizerId int not null,
VenueId int not null,
EventDate Date not null,
Foreign Key (OrganizerId) references Organizers (OrganizerId),
Foreign Key (VenueId) references Venues (VenueId)
)

Create Table Tickets(
TicketId int identity(1,1) primary key,
EventId int not null,
AttendeeId int not null,
Price decimal(10,4) check(Price>0),
CheckedIn Date,
Foreign Key (EventId) references Events (EventId),
Foreign Key (AttendeeId) references Attendees (AttendeeId)
)

insert into Attendees Values('Waleed','waleed.cordy@gmail.com');
insert into Attendees Values('Ahmed','ahmed.cordy@gmail.com');
insert into Attendees Values('Walaa','walaa.cordy@gmail.com');
insert into Attendees Values('Louis','louis.cordy@gmail.com');
insert into Attendees Values('Nohammed','mohammed.cordy@gmail.com');

insert into Organizers Values('organizer1','organizer1@gmail.com');
insert into Organizers Values('organizer2','organizer2@gmail.com');
insert into Organizers Values('organizer3','organizer3@gmail.com');
insert into Organizers Values('organizer4','organizer4@gmail.com');
insert into Organizers Values('organizer5','organizer5@gmail.com');

insert into Venues Values('Venue1','Location1',50);
insert into Venues Values('Venue2','Location2',150);
insert into Venues Values('Venue3','Location3',250);
insert into Venues Values('Venue4','Location4',350);
insert into Venues Values('Venue5','Location5',450);

insert into Events Values ('Title1', 1,1,'2026-05-01');
insert into Events Values ('Title2', 2,2,'2026-05-02');
insert into Events Values ('Title3', 3,3,'2026-05-03');
insert into Events Values ('Title4', 4,4,'2026-05-04');
insert into Events Values ('Title5', 5,5,'2026-05-05');

insert into Tickets Values (1,1,150,'2026-05-01 22:00:00');
insert into Tickets Values (2,2,250,'2026-05-02 22:00:00');
insert into Tickets Values (3,3,350,'2026-05-03 22:00:00');
insert into Tickets Values (4,4,450,'2026-05-04 22:00:00');
insert into Tickets Values (5,5,550,'2026-05-05 22:00:00');