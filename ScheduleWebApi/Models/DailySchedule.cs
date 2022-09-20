using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ScheduleWebApi.Model
{
    public class DailySchedule
    {
        [Key]
        public int DayOfWeek { get; set; }

        [MaxLength(20)]
        public string? First { get; set; }

        [MaxLength(20)]
        public string? Second { get; set; }

        [MaxLength(20)]
        public string? Third { get; set; }

        [MaxLength(20)]
        public string? Fourth { get; set; }
    }
}
