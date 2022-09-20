using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ScheduleWebApi.Model;

namespace ScheduleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyScheduleController : Controller
    {
        private AppDbContext db;
        private IConfiguration configuration;

        public DailyScheduleController(AppDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        [HttpGet("GetTodaySchedule")]
        public DailySchedule GetTodaySchedule()
        {
            DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
            return db.Schedule.Where(s => s.DayOfWeek == (int)dayOfWeek).FirstOrDefault();
        }

        [HttpGet("GetAll")]
        public IEnumerable<DailySchedule> GetAll() => db.Schedule.ToList();

        [HttpGet("GetByDay")]
        public DailySchedule GetByDay(int dayOfWeek) => 
            db.Schedule.Where(s => s.DayOfWeek == dayOfWeek).FirstOrDefault();

        [HttpPost("Insert")]
        public void Insert(DailySchedule schedule, string apiKey)
        {
            string validKey = configuration["ApiKey"];
            if (apiKey != validKey)
            {
                HttpContext.Response.StatusCode = 401;
                return;
            }

            db.Schedule.Add(schedule);
            db.SaveChanges();
        }

        [HttpPost("Update")]
        public void Update(DailySchedule schedule, string apiKey)
        {
            string validKey = configuration["ApiKey"];
            if (apiKey != validKey)
            {
                HttpContext.Response.StatusCode = 401;
                return;
            }

            db.Schedule.Update(schedule);
            db.SaveChanges();
        }

        [HttpDelete("Delete")]
        public void Delete(int dayOfWeek, string apiKey)
        {
            string validKey = configuration["ApiKey"];
            if (apiKey != validKey)
            {
                HttpContext.Response.StatusCode = 401;
                return;
            }

            DailySchedule scheduleToDelete = db.Schedule
                .Where(s => s.DayOfWeek == dayOfWeek)
                .FirstOrDefault();
            db.Schedule.Remove(scheduleToDelete);
            db.SaveChanges();
        }
    }
}
