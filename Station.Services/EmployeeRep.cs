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
    public class EmployeeRep : IEmployeeRep
    {
        private readonly StationContext context;

        public EmployeeRep(StationContext context)
        {
            this.context = context;
        }
        public async Task Create(Employee obj)
        {
            context.Employee.Add(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Employee Id)
        {
            context.Employee.Remove(Id);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return [.. await context.Employee.ToListAsync()];

        }

        public async Task<Employee> GetById(int Id)
        {
            var data = await context.Employee.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Update(Employee obj)
        {
            context.Employee.Update(obj);
            await context.SaveChangesAsync();
        }
    }
}
