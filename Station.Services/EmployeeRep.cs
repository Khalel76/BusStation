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
        public void Create(Employee obj)
        {
            context.Employee.Add(obj);
            context.SaveChanges();
        }

        public void Delete(Employee Id)
        {
            context.Employee.Remove(Id);
        }

        public IEnumerable<Employee> Get()
        {
            var data = context.Employee.Select(x => x);
            return data;
        }

        public Employee GetById(int Id)
        {
            var data = context.Employee.Where(x => x.Id == Id).FirstOrDefault();
            return data;
        }

        public void Update(Employee obj)
        {
            context.Employee.Update(obj);
            context.SaveChanges();
        }
    }
}
