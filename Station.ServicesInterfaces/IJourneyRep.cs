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
        void Create(Journey obj);
        void Update(Journey obj);
        void Delete(Journey Id);
        IEnumerable<Journey> Get();
        Journey GetById(int Id);
    }
}
