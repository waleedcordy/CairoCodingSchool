using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Session6.Assessment1;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Session8
{
    //Project : Notification System
    //You are building a system that sends notifications to users.
    //The system supports:
    //Email notification
    //SMS notification
    //Push notification

    //All notifications must be sent through a common processor.

    //Use an abstract class and inheritance to represent notifications and different types of notifications.
    //Then create a separate class called NotificationService that contains a Process() method.
    //Inside this method, demonstrate upcasting and downcasting while processing different notification types.

    public class Assessment2
    {
        List<Notification> notifications = new List<Notification>();
        NotificationService notificationService = new NotificationService();
        public Assessment2()
        {
            notifications.Add(new EmailNotification { NotificationMessage = "This is a new email message", EmailAddress="waleed.cordy@gmail.com" });
            notifications.Add(new SMSNotification { NotificationMessage = "This is a new SMS message", PhoneNumber= "+2010223111122" });
            notifications.Add(new PushNotification { NotificationMessage = "This is a push message", DeviceId="devId1112233" });


            foreach(var notiification in notifications)
            {
                notificationService.Process(notiification);
            }
        }
    }

    public abstract class  Notification
    {
        public string NotificationMessage { get; set; }
    }

    public class EmailNotification : Notification
    {
        public string EmailAddress { get; set; }
    }

    public class SMSNotification : Notification
    {
        public string PhoneNumber { get; set; }
    }

    public class PushNotification : Notification
    {
        public string DeviceId { get; set; }
    }

    public class NotificationService
    {
        public void Process(Notification notification)
        {
            if (notification is EmailNotification emailNotification)
            {
                Console.WriteLine($"Sending Email Notification: {emailNotification.NotificationMessage} to {emailNotification.EmailAddress}");
            }
            else if (notification is SMSNotification smsNotification)
            {
                Console.WriteLine($"Sending SMS Notification: {smsNotification.NotificationMessage} to {smsNotification.PhoneNumber}");
            }
            else if (notification is PushNotification pushNotification)
            {
                Console.WriteLine($"Sending Push Notification: {pushNotification.NotificationMessage} to device {pushNotification.DeviceId}");
            }
            else
            {
                Console.WriteLine("Unknown notification type.");
            }
        }
    }
}