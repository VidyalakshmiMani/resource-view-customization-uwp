using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.Xaml.Media;
namespace ScheduleUWP
{
    public class SchedulerViewModel
    {
        private ObservableCollection<DateTime> datecoll = new ObservableCollection<DateTime>();
        DateTime currentdate;
        public ScheduleAppointmentCollection AppointmentCollection { get; set; } = new ScheduleAppointmentCollection();
        public ObservableCollection<DateTime> DateRange { get; set; } = new ObservableCollection<DateTime>();

        string[] subject = new string[]
      {
            "Oncological Robotic Surgery",
            "Free Plastic Surgery Camp",
            "Seminar on Recent Advances in Management of Benign Brain Tumours",
            "Patient and Public Forum",
            "4th Clinical Nutrition Update",
            "Robotic GI Surgery International Congress",
            "National CME on Contemporary Developments in Transplants",
            "Meet the Expert",
            "Free Pediatric Cardiac Camp",
            "Join Hands for Patient Safety",
            "Transforming Healthcare with Information Technology",
            "World Continence Week - Free Check-up Camp for women",
            "CME (Continuing Medical Education) Program",
            "International Bariatric Conference",
            "Global Association of Physicians",
            "Interactive Live Workshop on Robotic Surgery in Gynecology",
            "World Ostomy Day and Awareness Program",
            "Billion Hearts Beating brings you Happy Heart Fest to celebrate World Heart Day",
            "CME (Continuing Medical Education) Program",
            "International Bariatric Conference",
            "Global Association of Physicians",
            "Interactive Live Workshop on Robotic Surgery in Gynecology",
            "World Ostomy Day and Awareness Program",
            "Program on Neurology in the Future"
      };

        public SchedulerViewModel()
        {
            Random randomValue = new Random();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
                today = today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
                today = today.AddMonths(1);
            }
            int day = (int)today.DayOfWeek;
            DateTime currentWeek = DateTime.Now.AddDays(-day);

            DateTime startMonth = new DateTime(today.Year, today.Month - 1, 1, 0, 0, 0);
            for (int i = 1; i < 30; i += 2)
            {
                for (int j = -7; j < 14; j++)
                {
                    datecoll.Add(currentWeek.Date.AddDays(j).AddHours(randomValue.Next(9, 18)));
                }
            }

            ObservableCollection<SolidColorBrush> brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x00, 0x73)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0xA1, 0xE2)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xF0, 0x96, 0x09)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x99, 0x33)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xAB, 0xA9)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));

            int count = 0;
            for (int index = 0; index < 30; index++)
            {
                currentdate = datecoll[randomValue.Next(0, datecoll.Count)];
                DateTime nextdate = datecoll[randomValue.Next(0, datecoll.Count)];
                count++;
                ScheduleAppointment appointment1 = new ScheduleAppointment() { StartTime = currentdate, EndTime = currentdate.AddHours(randomValue.Next(0, 2)), Subject = subject[count % subject.Length], Location = "Chennai", AppointmentBackground = brush[index % 3] };
                appointment1.ResourceCollection.Add(new Resource() { TypeName = "Doctors", ResourceName = "Dr.Jacob" });
                count++;
                ScheduleAppointment appointment2 = new ScheduleAppointment() { StartTime = nextdate, EndTime = nextdate.AddHours(randomValue.Next(0, 2)), Subject = subject[count % subject.Length], Location = "Chennai", AppointmentBackground = brush[(index + 2) % 3] };
                appointment2.ResourceCollection.Add(new Resource() { TypeName = "Doctors", ResourceName = "Dr.Darsy" });
                AppointmentCollection.Add(appointment1);
                AppointmentCollection.Add(appointment2);

                DateRange.Add(new DateTime(2020, 08, 1));
                DateRange.Add(new DateTime(2020, 08, 2));
                DateRange.Add(new DateTime(2020, 08, 3));
                DateRange.Add(new DateTime(2020, 08, 4));
                DateRange.Add(new DateTime(2020, 08, 5));
            }
        }
    }
}
            
        
    

