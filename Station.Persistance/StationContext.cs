using Station.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Station.Persistance
{
    public class StationContext : DbContext
    {
        public StationContext(DbContextOptions<StationContext> options) :
            base(options)
        {

        }

        public DbSet<Vehical> Vehical { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<Admin> Admin { get; set; }

       
    }
}
