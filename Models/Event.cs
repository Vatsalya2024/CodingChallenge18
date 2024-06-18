using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int MaxAttendees { get; set; }
        public double RegistrationFee { get; set; }

        public Event()
        {
            
        }
        public Event(int id , string title,string description, DateTime date ,string location,int maxAttendees,double registrationFee)
        {
            Id = id;
            Title = title;  
            Description = description;
            Date = date;
            Location = location;
            MaxAttendees = maxAttendees;
            RegistrationFee = registrationFee;
        }
    }
}
