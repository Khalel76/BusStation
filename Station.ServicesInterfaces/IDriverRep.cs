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
        Task Create(Driver obj);
        Task Update(Driver obj);
        Task Delete(Driver Id);
        Task<IEnumerable<Driver>> Get();
        Task<Driver> GetById(int Id);
    }
}
