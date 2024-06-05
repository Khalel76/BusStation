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
    public class JourneyRep : IJourneyRep
    {
        private readonly StationContext context;

        public JourneyRep(StationContext context)
        {
            this.context = context;
        }
        public async Task Create(Journey obj)
        {
            context.Journey.Add(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Journey Id)
        {
            context.Journey.Remove(Id);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Journey>> Get()
        {
            return [.. await context.Journey.ToListAsync()];

        }

        public async Task<Journey> GetById(int Id)
        {
            var data = await context.Journey.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Update(Journey obj)
        {
            context.Journey.Update(obj);
            await context.SaveChangesAsync();
        }
    }
}
