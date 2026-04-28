using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace ConsoleApp1.Project3
{
    public static class EventManagementSystem
    {
        static List<Organizer> Organizers = new List<Organizer>();
        static List<Venue> Venues = new List<Venue>();
        static List<Event> Events = new List<Event>();
        static List<Attendee> Attendees = new List<Attendee>();
        static List<Ticket> Tickets = new List<Ticket>();

        public static void Initialize()
        {
            Attendees.Add(new Attendee(Attendees.Count + 1, "Waleed", "waled.cordy@gmail.com"));
            Attendees.Add(new Attendee(Attendees.Count + 1, "Ahmed", "ahmed.cordy@gmail.com"));
            Attendees.Add(new Attendee(Attendees.Count + 1, "Walaa", "walaa.cordy@gmail.com"));
            Attendees.Add(new Attendee(Attendees.Count + 1, "Louis", "louis.cordy@gmail.com"));
            Attendees.Add(new Attendee(Attendees.Count + 1, "Mohammed", "mohammed.cordy@gmail.com"));

            Organizers.Add(new Organizer(Organizers.Count + 1, "organizer1", "organizer1@gmail.com"));
            Organizers.Add(new Organizer(Organizers.Count + 1, "organizer2", "organizer2@gmail.com"));
            Organizers.Add(new Organizer(Organizers.Count + 1, "organizer3", "organizer3@gmail.com"));
            Organizers.Add(new Organizer(Organizers.Count + 1, "organizer4", "organizer4@gmail.com"));
            Organizers.Add(new Organizer(Organizers.Count + 1, "organizer5", "organizer5@gmail.com"));

            Venues.Add(new Venue(Venues.Count + 1, "Venue1", "Location1", 4));
            Venues.Add(new Venue(Venues.Count + 1, "Venue2", "Location2", 150));
            Venues.Add(new Venue(Venues.Count + 1, "Venue3", "Location3", 250));
            Venues.Add(new Venue(Venues.Count + 1, "Venue4", "Location4", 350));
            Venues.Add(new Venue(Venues.Count + 1, "Venue5", "Location5", 3));

            Events.Add(new Event(Events.Count + 1, "Title1", Organizers.First(x => x.Id == 1), Venues.First(x => x.Id == 1), DateOnly.Parse("2026-05-01")));
            Events.Add(new Event(Events.Count + 1, "Title2", Organizers.First(x => x.Id == 2), Venues.First(x => x.Id == 2), DateOnly.Parse("2026-05-02")));
            Events.Add(new Event(Events.Count + 1, "Title3", Organizers.First(x => x.Id == 3), Venues.First(x => x.Id == 3), DateOnly.Parse("2026-05-03")));
            Events.Add(new Event(Events.Count + 1, "Title4", Organizers.First(x => x.Id == 4), Venues.First(x => x.Id == 4), DateOnly.Parse("2026-05-04")));
            Events.Add(new Event(Events.Count + 1, "Title5", Organizers.First(x => x.Id == 5), Venues.First(x => x.Id == 5), DateOnly.Parse("2026-05-05")));
            Events.Add(new Event(Events.Count + 1, "Title6", Organizers.First(x => x.Id == 1), Venues.First(x => x.Id == 5), DateOnly.Parse("2026-05-05")));
            Events.Add(new Event(Events.Count + 1, "Title7", Organizers.First(x => x.Id == 1), Venues.First(x => x.Id == 5), DateOnly.Parse("2026-05-05")));
            Events.Add(new Event(Events.Count + 1, "Title8", Organizers.First(x => x.Id == 1), Venues.First(x => x.Id == 1), DateOnly.Parse("2026-05-05")));
            Events.Add(new Event(Events.Count + 1, "Title9", Organizers.First(x => x.Id == 2), Venues.First(x => x.Id == 2), DateOnly.Parse("2026-01-01")));

            Tickets.Add(new Ticket(Tickets.Count + 1, Events.First(x => x.EventId == 1), Attendees.First(x => x.Id == 1), 150));
            Tickets.Add(new Ticket(Tickets.Count + 1, Events.First(x => x.EventId == 2), Attendees.First(x => x.Id == 2), 250));
            Tickets.Add(new Ticket(Tickets.Count + 1, Events.First(x => x.EventId == 3), Attendees.First(x => x.Id == 3), 350));
            Tickets.Add(new Ticket(Tickets.Count + 1, Events.First(x => x.EventId == 1), Attendees.First(x => x.Id == 4), 450));
            Tickets.Add(new Ticket(Tickets.Count + 1, Events.First(x => x.EventId == 5), Attendees.First(x => x.Id == 5), 550));
            Tickets.Add(new Ticket(Tickets.Count + 1, Events.First(x => x.EventId == 5), Attendees.First(x => x.Id == 4), 550));
            Tickets.Add(new Ticket(Tickets.Count + 1, Events.First(x => x.EventId == 5), Attendees.First(x => x.Id == 5), 550));
            Tickets.Add(new Ticket(Tickets.Count + 1, Events.First(x => x.EventId == 5), Attendees.First(x => x.Id == 5), 550));

            Tickets.First(x => x.TicketId == 1).CheckIn();

        }

        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Event Management System");
                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("1. Get all events organized by a specific organizer");
                Console.WriteLine("2. Get all attendees for a specific event");
                Console.WriteLine("3. Total ticket revenue per event");
                Console.WriteLine("4. Number of attendees per event");
                Console.WriteLine("5. Upcoming events sorted by date");
                Console.WriteLine("6. Attendees who didn't check in");
                Console.WriteLine("7. Most attened events");
                Console.WriteLine("8. Event with organizer and venue info");
                Console.WriteLine("9. Attendees attending multiple events");
                Console.WriteLine("10. Events that are fully booked");

                Console.Write("Enter choice:");
                Console.WriteLine(Environment.NewLine);

                var line = Console.ReadLine();
                bool ok = int.TryParse(line, out int choice);
                if (ok)
                {
                    switch (choice)
                    {
                        case 1:
                            GetAllEventsOrganizedByASpecificOrganizer();
                            break;
                        case 2:
                            GetAllAttendeesForASpecificEvent();
                            break;
                        case 3:
                            TotalTicketRevenuePerEvent();
                            break;
                        case 4:
                            GetNumberOfAttendeesPerEvent();
                            break;

                        case 5:
                            GetUpcomingEventsSortedByDate();
                            break;
                        case 6:
                            GetAttendeesWhoDidntCheckIn();
                            break;

                        case 7:
                            GetMostAttendedEvents();
                            break;

                        case 8:
                            GetEventWithOrganizerAndVenueInfo();
                            break;

                        case 9:
                            GetAttendeesAttendingMultipleEvents();
                            break;

                        case 10:
                            GetEventsThatAreFullyBooked();
                            break;

                    }
                }
            }
        }

        public static void GetEventsThatAreFullyBooked()
        {
            var grouped = Tickets.GroupBy(x => x.Event).Select(group => new { Event = group.Key, Count = group.Count() }).ToList();
            foreach (var group in grouped)
            {
                if (group.Count >= group.Event.Venue.Capacity)
                {
                    Console.WriteLine($"Event {group.Event.Title} is fully booked");
                }
            }
            ShowMainMenu();
        }
        public static void GetAttendeesAttendingMultipleEvents()
        {
            var grouped = Tickets.GroupBy(x => x.Attendee).Select(group => new { Attendee = group.Key, Count = group.Count() }).ToList();
            foreach (var group in grouped)
            {
                if (group.Count > 1)
                {
                    Console.WriteLine($"{group.Attendee.Name} is attending {group.Count} events.");
                }
            }
            ShowMainMenu();
        }

        public static void GetEventWithOrganizerAndVenueInfo()
        {
            while (true)
            {
                Console.WriteLine("Event Id: ");
                var line = Console.ReadLine();
                bool ok = int.TryParse(line, out var id);
                if (ok)
                {
                    var Event = Events.FirstOrDefault(x => x.EventId == id);
                    if (Event != null)
                    {
                        Console.WriteLine($"Organizer: {Event.Organizer.Name} - Venue: {Event.Venue.Name}");
                        ShowMainMenu();
                    }
                }

            }
        }

        public static void GetMostAttendedEvents()
        {
            var grouped = Tickets.GroupBy(x => x.Event).Select(group => new { Event = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).ToList();
            if (grouped.Count > 0)
            {
                Console.WriteLine($"Most attened event is {grouped[0].Event.Title} - {grouped[0].Count} attendees.");
            }
            ShowMainMenu();
        }

        public static void GetAttendeesWhoDidntCheckIn()
        {
            while (true)
            {
                Console.WriteLine("Event Id: ");
                var line = Console.ReadLine();
                bool ok = int.TryParse(line, out var id);
                if (ok)
                {
                    if (Events.FirstOrDefault(x => x.EventId == id) != null)
                    {
                        var tickets = Tickets.Where(x => x.Event.EventId == id && x.CheckedIn == null);
                        if (Tickets.Count > 0)
                        {
                            foreach (var ticket in tickets)
                            {
                                Console.WriteLine($"{ticket.Attendee.Name} didn't check in.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("All attendees attended the event, or no tickets.");
                        }
                        ShowMainMenu();
                    }
                }

            }
        }

        public static void GetUpcomingEventsSortedByDate()
        {
            var events = Events.Where(x => x.EventDate >= DateOnly.FromDateTime(DateTime.Today));

            if (events.Count() > 0)
            {
                Console.WriteLine("Upcoming events:");
                foreach (var event1 in events.OrderBy(x => x.EventDate))
                {
                    Console.WriteLine($"{event1.Title} - {event1.EventDate}");
                }
            }
            else
            {
                Console.WriteLine("No upcoming events");
            }
        }
        public static void GetNumberOfAttendeesPerEvent()
        {
            var grouped = Tickets.GroupBy(x => x.Event);
            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Key.Title} - {group.Count()} Attendees");
            }
        }

        public static void TotalTicketRevenuePerEvent()
        {
            while (true)
            {
                Console.WriteLine("Event Id: ");
                var line = Console.ReadLine();
                bool ok = int.TryParse(line, out var id);
                if (ok)
                {
                    if (Events.FirstOrDefault(x => x.EventId == id) != null)
                    {
                        var tickets = Tickets.Where(x => x.Event.EventId == id);
                        if (Tickets.Count > 0)
                        {
                            Console.WriteLine($"Revenuee: {tickets.Sum(x => x.Price)} ");
                        }
                        else
                        {
                            Console.WriteLine("No revenue");
                        }
                        ShowMainMenu();
                    }
                }

            }
        }

        public static void GetAllAttendeesForASpecificEvent()
        {
            while (true)
            {
                Console.WriteLine("Event Id: ");
                var line = Console.ReadLine();
                bool ok = int.TryParse(line, out var id);
                if (ok)
                {
                    if (Events.FirstOrDefault(x => x.EventId == id) != null)
                    {
                        var tickets = Tickets.Where(x => x.Event.EventId == id);
                        if (Tickets.Count > 0)
                        {
                            Console.WriteLine("Attendees: ");
                            foreach (var ticket in tickets)
                            {
                                Console.WriteLine($"Name : {ticket.Attendee.Name}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No one is attending this event");
                        }
                        ShowMainMenu();
                    }
                }

            }
        }

        public static void GetAllEventsOrganizedByASpecificOrganizer()
        {
            while (true)
            {
                Console.WriteLine("Organizer Id: ");
                var line = Console.ReadLine();
                bool ok = int.TryParse(line, out var id);
                if (ok)
                {
                    if (Organizers.FirstOrDefault(x => x.Id == id) != null)
                    {
                        Console.WriteLine("Events: ");
                        var events = Events.Where(x => x.Organizer.Id == id).ToList();
                        if (events.Count > 0)
                        {
                            foreach (var event1 in events)
                            {
                                Console.WriteLine($"Id: {event1.EventId} - Title: {event1.Title} - Date: {event1.EventDate}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("None");
                        }

                        ShowMainMenu();
                    }
                }

            }
        }

        public abstract class PersonBase
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            protected PersonBase(int id, string name, string email)
            {
                Id = id;
                Name = name;
                Email = email;
            }
        }

        public class Attendee : PersonBase
        {
            public Attendee(int id, string name, string email) : base(id, name, email)
            {

            }
        }

        public class Organizer : PersonBase
        {
            public Organizer(int id, string name, string email) : base(id, name, email)
            {

            }
        }

        public class Venue
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public int Capacity { get; set; }

            public Venue(int id, string name, string location, int capacity)
            {
                Id = id;
                Name = name;
                Location = location;
                Capacity = capacity;
            }
        }

        public class Event
        {
            public int EventId { get; set; }
            public string Title { get; set; }
            public Organizer Organizer { get; set; }
            public Venue Venue { get; set; }
            public DateOnly EventDate { get; set; }

            public Event(int id, string title, Organizer organizer, Venue venue, DateOnly eventDate)
            {
                EventId = id;
                Title = title;
                Organizer = organizer;
                Venue = venue;
                EventDate = eventDate;
            }
        }

        public class Ticket
        {
            public int TicketId { get; set; }
            public Event Event { get; set; }
            public Attendee Attendee { get; set; }
            public decimal Price { get; set; }
            public DateTime? CheckedIn { get; private set; }

            public Ticket(int id, Event event1, Attendee attendee, decimal price)
            {
                TicketId = id;
                Event = event1;
                Attendee = attendee;
                Price = price;
            }

            public void CheckIn()
            {
                CheckedIn = DateTime.Now;
            }
        }
    }
}