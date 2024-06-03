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
        public void Create(Customer obj)
        {
            context.Customer.Add(obj);
            context.SaveChanges();
        }

        public void Delete(Customer Id)
        {
            context.Customer.Remove(Id);
        }

        public IEnumerable<Customer> Get()
        {
            var data = context.Customer.Select(x => x);
            return data;
        }

        public Customer GetById(int Id)
        {
            var data = context.Customer.Where(x => x.Id == Id).FirstOrDefault();
            return data;
        }

        public void Update(Customer obj)
        {
            context.Customer.Update(obj);
            context.SaveChanges();
        }
    }
}