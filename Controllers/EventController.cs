using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            try
            {
                var eventss = await _eventService.GetEvent(id);
                return Ok(eventss);
            }
            catch (NoSuchEventException)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event events)
                {
            var newEvent = await _eventService.AddEvent(events);
                    return CreatedAtAction(nameof(GetEvent), new { id = newEvent.Id
    }, newEvent);
                }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventUpdateDto eventDto)
        {
            try
            {
                var updatedEvent = await _eventService.UpdateEvent(id, eventDto);
                return Ok(updatedEvent);
            }
            catch (NoSuchEventException)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var deletedEvent = await _eventService.DeleteEvent(id);
                return Ok(deletedEvent);
            }
            catch (NoSuchEventException)
            {
                return NotFound();
            }
        }


    }
}
