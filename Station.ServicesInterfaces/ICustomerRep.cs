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
        Task Create(Customer obj);
        Task Update(Customer obj);
        Task Delete(Customer Id);
        Task<IEnumerable<Customer>> Get();
        Task<Customer> GetById(int Id);
    }
}
