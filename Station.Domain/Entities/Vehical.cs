﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Domain.Entities
{
    public class Vehical
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Plate { get; set; }
    }
}

