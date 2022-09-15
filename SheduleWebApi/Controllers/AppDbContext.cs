using Microsoft.EntityFrameworkCore;
using SheduleWebApi.Model;

namespace SheduleWebApi.Controllers
{
    public class AppDbContext : DbContext
    {
        public DbSet<DailyShedule> shedule { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
