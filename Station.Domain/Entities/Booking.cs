using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Domain.Entities
{
    public class Booking
    {
        public Booking()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        public char Type { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int JourneyId { get; set; }

        public Journey Journey { get; set; }
    }
}
