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
        public async Task Create(Driver obj)
        {
            context.Driver.Add(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Driver Id)
        {
            context.Driver.Remove(Id);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Driver>> Get()
        {
            return [.. await context.Driver.ToListAsync()];

        }

        public async Task<Driver> GetById(int Id)
        {
            var data = await context.Driver.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Update(Driver obj)
        {
            context.Driver.Update(obj);
            await context.SaveChangesAsync();
        }
    }
}
