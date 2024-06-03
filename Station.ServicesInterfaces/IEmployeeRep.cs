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
        void Create(Employee obj);
        void Update(Employee obj);
        void Delete(Employee Id);
        IEnumerable<Employee> Get();
        Employee GetById(int Id);
    }
}
