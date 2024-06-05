using Station.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.ServicesInterfaces
{
    public interface IJourneyRep
    {
        Task Create(Journey obj);
        Task Update(Journey obj);
        Task Delete(Journey Id);
        Task<IEnumerable<Journey>> Get();
        Task<Journey> GetById(int Id);
    }
}
