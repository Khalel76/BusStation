using Station.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.ServicesInterfaces
{
    public interface IEmployeeRep
    {
        Task Create(Employee obj);
        Task Update(Employee obj);
        Task Delete(Employee Id);
        Task<IEnumerable<Employee>> Get();
        Task<Employee> GetById(int Id);
    }
}
