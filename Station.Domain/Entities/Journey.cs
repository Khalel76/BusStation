using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Domain.Entities
{
    public class Journey
    {
        public Journey()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z]{2,12}-[a-zA-Z]{2,12}", ErrorMessage = "like : Ajdabiya-Brega")]
        public string Destination { get; set; }

        [Required]
        public float Price { get; set; }
        
        [Required]
        public DateTime Date { get; set; }


        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int DriverId { get; set; }

        public Driver Driver { get; set; }

        public ICollection<Booking> Bookings { get; set; }


    }
}
