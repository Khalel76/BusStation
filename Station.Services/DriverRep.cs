using Microsoft.EntityFrameworkCore;
using Station.Domain.Entities;
using Station.Persistance;
using Station.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Services
{
    public class DriverRep : IDriverRep
    {
        private readonly StationContext context;

        public DriverRep(StationContext context)
        {
            this.context = context;
        }
        public void Create(Driver obj)
        {
            context.Driver.Add(obj);
            context.SaveChanges();
        }

        public void Delete(Driver Id)
        {
            context.Driver.Remove(Id);
        }

        public IEnumerable<Driver> Get()
        {
            var data = context.Driver.Include("Vehical").Select(x => x);
            return data;
        }

        public Driver GetById(int Id)
        {
            var data = context.Driver.Where(x => x.Id == Id).FirstOrDefault();
            return data;
        }

        public void Update(Driver obj)
        {
            context.Driver.Update(obj);
            context.SaveChanges();
        }
    }
}
