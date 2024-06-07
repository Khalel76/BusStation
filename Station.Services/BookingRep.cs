using Microsoft.EntityFrameworkCore;
using Station.Domain.Entities;
using Station.Persistance;
using Station.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Services
{
    public class BookingRep : IBookingRep
    {
        private readonly StationContext context;

        public BookingRep(StationContext context)
        {
            this.context = context;
        }
        public async Task AutoCreate (char type , float price , DateTime Date , int coustemrId , int journeyId)
       {
            Booking booking = new Booking();
            booking.Type=type;
            booking.Price=price;
            booking.Date=Date;
            booking.CustomerId=coustemrId;
            booking.JourneyId=journeyId;
            context.Booking.Add(booking);
            context.SaveChangesAsync();
        }
        public async Task Create(Booking obj)
        {
            context.Booking.Add(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Booking Id)
        {
           context.Booking.Remove(Id);
           await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Booking>> Get()
        {
                return [.. await context.Booking.ToListAsync()];

        }

        public async Task<Booking> GetById(int Id)
        {
            
            var data = await context.Booking.FirstOrDefaultAsync(x => x.Id == Id);
            return data;
        }

        public async Task Update(Booking obj)
        {
            context.Booking.Update(obj);
            await context.SaveChangesAsync() ;
        }
    }
}
