using Station.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.ServicesInterfaces
{
    public interface IBookingRep
    {
        Task AutoCreate (char type , float price , DateTime Date , int coustemrId , int journeyId);
        Task Create(Booking obj);
        Task Update(Booking obj);
        Task Delete(Booking Id);
        Task<IEnumerable<Booking>> Get();
        Task<Booking> GetById(int Id);
        bool IsBooking(int JourneyId, int CustomerId);

    }
}
