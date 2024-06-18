using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Models.DTOs;

namespace CodingChallenge.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<int, Event> _repository;

        public EventService(IRepository<int, Event> repository)
        {
            _repository = repository;
        }
        public Task<Event> AddEvent(Event events)
        {
            return _repository.Add(events);
        }

        public Task<Event> DeleteEvent(int id)
        {
            return _repository.Delete(id);
        }

        public Task<List<Event>> GetAllEvents()
        {
            return _repository.GetAll();
        }

        public Task<Event> GetEvent(int id)
        {
            return _repository.Get(id);
        }

        public async Task<Event> UpdateEvent(int id, EventUpdateDto eventDto)
        {
            var existingEvent = await _repository.Get(id);
            if (existingEvent == null)
            {
                throw new NoSuchEventException();
            }

           
            if (eventDto.Title != null)
            {
                existingEvent.Title = eventDto.Title;
            }

            if (eventDto.Description != null)
            {
                existingEvent.Description = eventDto.Description;
            }

            if (eventDto.MaxAttendees != null)
            {
                existingEvent.MaxAttendees = eventDto.MaxAttendees;
            }

            if (eventDto.Location != null) 
            {
                existingEvent.Location = eventDto.Location;
            }

            return await _repository.Update(existingEvent);
        }
    }
}
