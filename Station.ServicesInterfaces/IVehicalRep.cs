using Station.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.ServicesInterfaces
{
    public interface IVehicalRep
    {
        Task Create(Vehical obj);
        Task Update(Vehical obj);
        Task Delete(Vehical Id);
        Task<IEnumerable<Vehical>> Get();
        Task<Vehical> GetById(int Id);
        string GetType(int Id);
        string GetPlate(int Id);


    }
}
