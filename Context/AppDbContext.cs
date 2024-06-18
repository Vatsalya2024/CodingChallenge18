using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
