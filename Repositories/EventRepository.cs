using CodingChallenge.Context;
using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Repositories
{
    public class EventRepository : IRepository<int, Event>
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Event> Add(Event item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Event?> Delete(int key)
        {
            var member = await Get(key);
            if (member != null)
            {
                _context.Events.Remove(member);
                await _context.SaveChangesAsync();
            }
            return member;
        }

        public async Task<Event?> Get(int key)
        {
            var member = await _context.Events.FindAsync(key);
            if (member == null)
                throw new NoSuchEventException();
            return member;
        }

        public async Task<List<Event>?> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> Update(Event item)
        {
            var member = await Get(item.Id);
            if (member != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return item;
        }
    }
}
