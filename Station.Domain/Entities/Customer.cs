using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Max Len 20")]
        [MinLength(8, ErrorMessage = "Min Len 8")]
        public string Password { get; set; }

        [MaxLength(60, ErrorMessage = "Max Len 60")]
        public string Name { get; set; }

        [StringLength(24, ErrorMessage = "Max Len 24")]
        [MinLength(10, ErrorMessage = "Min Len 10")]
        [Phone]
        public string Phone { get; set; }

        [MaxLength(60)]
        [EmailAddress(ErrorMessage = "Mail Invalid")]
        public string Email { get; set; }

        [Required]
        public char Gender { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
