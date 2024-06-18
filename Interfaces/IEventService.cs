using CodingChallenge.Models;
using CodingChallenge.Models.DTOs;

namespace CodingChallenge.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEvents();
        Task<Event> GetEvent(int id);

        Task<Event> AddEvent(Event events);
        Task<Event> UpdateEvent(int id, EventUpdateDto eventDto);
        Task<Event> DeleteEvent(int id);
       
    }
}
