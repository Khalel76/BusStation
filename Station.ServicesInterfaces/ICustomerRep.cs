using Station.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.ServicesInterfaces
{
    public interface ICustomerRep
    {
        void Create(Customer obj);
        void Update(Customer obj);
        void Delete(Customer Id);
        IEnumerable<Customer> Get();
        Customer GetById(int Id);
    }
}
