using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SheduleWebApi.Model
{
    public class DailyShedule
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
