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
    public class JourneyRep : IJourneyRep
    {
        private readonly StationContext context;

        public JourneyRep(StationContext context)
        {
            this.context = context;
        }
        public void Create(Journey obj)
        {
            context.Journey.Add(obj);
            context.SaveChanges();
        }

        public void Delete(Journey Id)
        {
            context.Journey.Remove(Id);
        }

        public IEnumerable<Journey> Get()
        {
            var data = context.Journey.Select(x => x);
            return data;
        }

        public Journey GetById(int Id)
        {
            var data = context.Journey.Where(x => x.Id == Id).FirstOrDefault();
            return data;
        }

        public void Update(Journey obj)
        {
            context.Journey.Update(obj);
            context.SaveChanges();
        }
    }
}
