using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static ConsoleApp1.Program;

namespace ConsoleApp1.Session17
{
    //Task-Hotel Reservation System
    //OOP Design
    //Hotels
    //Stores information about each hotel.
    //Rooms
    //Represents the rooms available in each hotel.
    //A room can have multiple features, and a feature can belong to multiple rooms.
    //Customers
    //Users who make reservations.
    //Each customer can book multiple rooms per reservation

    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
    }

    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get;set;  }
        public decimal Price { get; set; }
        public int HotelId { get;set;  }
        public Hotel Hotel { get; set; }

        public List<Feature> Features { get; set; } = new List<Feature>();
    }

    public class Feature
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }

    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get;set;  }
        public List<ReservationDetail> Details { get; set; } = new List<ReservationDetail>();
    }

    public class ReservationDetail
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public decimal Price { get; set;  }
        public int RoomId { get; set;  }
        public Room Room { get; set; }
    }
    
}
