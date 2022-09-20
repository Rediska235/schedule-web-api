using Microsoft.EntityFrameworkCore;
using ScheduleWebApi.Model;

namespace ScheduleWebApi.Controllers
{
    public class AppDbContext : DbContext
    {
        public DbSet<DailySchedule> Schedule { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
