using Microsoft.EntityFrameworkCore;
using Station.Domain.Entities;
using Station.Persistance;
using Station.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Persistance
{
    public class CustomerRep : ICustomerRep
    {
        private readonly StationContext context;

        public CustomerRep(StationContext context)
        {
            this.context = context;
        }
        public async Task Create(Customer obj)
        {
            context.Customer.Add(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Customer Id)
        {
            context.Customer.Remove(Id);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return [.. await context.Customer.ToListAsync()];

        }

        public async Task<Customer> GetById(int Id)
        {
            var data = await context.Customer.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Update(Customer obj)
        {
            context.Customer.Update(obj);
            await context.SaveChangesAsync();
        }
    }
}