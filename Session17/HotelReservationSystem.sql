--Task-Hotel Reservation System

--SQL Design

--Hotels
--Stores information about each hotel.
--Rooms
--Represents the rooms available in each hotel.
--A room can have multiple features, and a feature can belong to multiple rooms.
--Customers
--Users who make reservations.
--Each customer can book multiple rooms per reservation

Create table Hotels (
HotelId int primary key,
HotelName varchar(50) unique not null,
)

Create Table Rooms(
RoomId int primary key,
RoomNumber varchar(5) unique not null,
Price decimal(10,4) check (Price >0),
HotelId int not null,

foreign key (HotelId) references Hotels (HotelId)
)

Create Table Features(
FeatureId int primary key,
FeatureName varchar(50) unique not null
)

Create Table RoomdFeatures(
RoomId int ,
FeatureId int ,
Primary Key (RoomId, FeatureId),
Foreign key (RoomId) references Rooms (RoomId),
Foreign Key (FeatureId) references Features (FeatureId)
)

Create Table Customers(
CustomerId int primary key,
CustomerName varchar(50) not null unique,
)

Create Table Reservations(
ReservationId int primary key,
ReservationDate Date not null Default(GetDate()),
CustomerId int not null,
CheckIn Date not null,
CheckOut Date not null,
Foreign Key (CustomerId) References Customers (CustomerId)
)

Create Table ReservationDetails(
ReservationId int,
RoomId int,
Primary Key(ReservationId , RoomId),
Price decimal(10,4) check (Price > 0),
Foreign Key (ReservationId) references Reservations (ReservationId),
Foreign Key (RoomId) references Rooms (RoomId),
)