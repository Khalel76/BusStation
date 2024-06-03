using Station.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.ServicesInterfaces
{
    public interface IDriverRep
    {
        void Create(Driver obj);
        void Update(Driver obj);
        void Delete(Driver Id);
        IEnumerable<Driver> Get();
        Driver GetById(int Id);
    }
}
