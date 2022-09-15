using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleWebApi.Model;
using System.Net;

namespace SheduleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailySheduleController : Controller
    {
        AppDbContext db;
        IConfiguration configuration;

        public DailySheduleController(AppDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        [HttpGet("GetTodayShedule")]
        public DailyShedule GetTodayShedule()
        {
            DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
            return db.shedule.Where(s => s.DayOfWeek == (int)dayOfWeek).FirstOrDefault();
        }

        [HttpGet("GetAll")]
        public IEnumerable<DailyShedule> GetAll() => db.shedule.ToList();

        [HttpGet("GetByDay")]
        public DailyShedule GetByDay(int dayOfWeek) => 
            db.shedule.Where(s => s.DayOfWeek == dayOfWeek).FirstOrDefault();

        [HttpPost("Insert")]
        public void Insert(DailyShedule shedule, string apiKey)
        {
            string validKey = configuration["ApiKey"];
            if (apiKey != validKey)
            {
                HttpContext.Response.StatusCode = 401;
                return;
            }

            db.shedule.Add(shedule);
            db.SaveChanges();
        }

        [HttpPost("Update")]
        public void Update(DailyShedule shedule, string apiKey)
        {
            string validKey = configuration["ApiKey"];
            if (apiKey != validKey)
            {
                HttpContext.Response.StatusCode = 401;
                return;
            }

            db.shedule.Update(shedule);
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

            DailyShedule sheduleToDelete = db.shedule
                .Where(s => s.DayOfWeek == dayOfWeek)
                .FirstOrDefault();
            db.shedule.Remove(sheduleToDelete);
            db.SaveChanges();
        }
    }
}
