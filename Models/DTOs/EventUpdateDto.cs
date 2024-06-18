namespace CodingChallenge.Models.DTOs
{
    public class EventUpdateDto
    {
        public string Title {  get; set; }
        public string Description { get; set; }

        public string Location { get; set; }

        public  int MaxAttendees { get; set; }
    }
}
