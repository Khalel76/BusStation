using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Domain.Entities
{
    public class Employee
    {
        public Employee()
        {
            CreationDate = DateTime.Now;
            HireDate = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Max Len 20")]
        [MinLength(8, ErrorMessage = "Min Len 8")]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(2000, 10000, ErrorMessage = "Range Btw 2000 : 10000")]
        public double Salary { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress(ErrorMessage = "Mail Invalid")]
        public string Email { get; set; }

        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{2,5}-[a-zA-Z]{2,5}-[a-zA-Z]{2,5}", ErrorMessage = "like : 12-Street-City-Country")]
        public string Address { get; set; }

        public ICollection<Journey> Journeys { get; set; }


    }
}
