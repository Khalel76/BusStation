using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Domain.Entities
{
    public class Driver
    {
        public int Id { get; set; }

        [MaxLength(60, ErrorMessage = "Max Len 60")]
        public string Name { get; set; }

        [StringLength(24, ErrorMessage = "Max Len 24")]
        [MinLength(10, ErrorMessage = "Min Len 10")]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public int VehicalId { get; set; }

        public Vehical Vehical { get; set; }

        public ICollection<Journey> Journeys { get; set; }
    }
}
