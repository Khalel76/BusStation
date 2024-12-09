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
    public class VehicalRep : IVehicalRep
    {
        private readonly StationContext context;

        public VehicalRep(StationContext context)
        {
            this.context = context;
        }
        public async Task Create(Vehical obj)
        {
            context.Vehical.Add(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Vehical Id)
        {
            context.Vehical.Remove(Id);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Vehical>> Get()
        {
                return [.. await context.Vehical.ToListAsync()];
        }

        public async Task<Vehical> GetById(int Id)
        {
            var data = await context.Vehical.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return data;
        }

         public string GetType(int Id)
        {
            var data =  context.Vehical.Where(x => x.Id == Id).Select( x => x.Type).FirstOrDefault();
            return data;
        }
        
        public string GetPlate(int Id)
        {
            var data =  context.Vehical.Where(x => x.Id == Id).Select( x => x.Plate).FirstOrDefault();
            return data;
        }
        public async Task Update(Vehical obj)
        {
            context.Vehical.Update(obj);
            context.SaveChangesAsync();
        }
    }
}
