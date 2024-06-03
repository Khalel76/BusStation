using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Domain.Entities
{
    public class Admin
    {
        [Key]
        [MaxLength(6)] 
        public string UserName  { get; set; }
        [MaxLength(18)]
        [MinLength(8)]
        public int Password { get; set; }
    }
}
