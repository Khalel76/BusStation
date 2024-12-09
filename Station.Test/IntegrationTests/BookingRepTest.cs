using Microsoft.EntityFrameworkCore;
using Station.Domain.Entities;
using Station.Persistance;
using Station.Services;


namespace Station.Test.IntegrationTests
{
    public class BookingRepTest
    {
        private DbContextOptions<StationContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<StationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        
        [Fact]
       public async Task Save_ShouldAddBooking()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new BookingRep(new StationContext(options));
            var Booking = new Booking { Type = 'v', Price = 190 };

            // Act
            await service.Create(Booking);

            // Assert
            using var context = new StationContext(options);
            var savedAuthor = await context.Booking.FirstOrDefaultAsync(a => a.Price == 190);
            Assert.NotNull(savedAuthor);
        }
      

            [Fact]
            public async Task Get_ShouldReturnBookingById()
            {
                // Arrange
                var options = CreateNewContextOptions();
                //var factory = GetDbContextFactoryAsync(options);
                var service = new BookingRep(new StationContext(options));
                var booking = new Booking { CustomerId = 2, Price = 20 };
                await service.Create(booking);

                // Act
                var fetchedbooking = await service.GetById(booking.Id);

                // Assert
                Assert.NotNull(fetchedbooking);
                Assert.Equal(booking.Id, fetchedbooking.Id);
            }

            [Fact]
            public async Task GetAll_ShouldReturnAllBooking()
            {
                // Arrange
                var options = CreateNewContextOptions();
                //var factory = GetDbContextFactoryAsync(options);
                var service = new BookingRep((new StationContext(options)));
                var booking1 = new Booking { CustomerId = 1, Price = 20 };
                var booking2 = new Booking { CustomerId = 2, Price = 20 };

                await service.Create(booking1);
                await service.Create(booking2);

                // Act
                var booking = await service.Get();

                // Assert
                Assert.Equal(2, booking.Count<Booking>());
            }

            [Fact]
            public async Task Delete_ShouldRemoveBooking()
            {
                // Arrange
                var options = CreateNewContextOptions();
                //var factory = GetDbContextFactoryAsync(options);
                var service = new BookingRep((new StationContext(options)));
                var booking = new Booking { CustomerId = 2, Price = 20 };
                await service.Create(booking);

                // Act
                await service.Delete(booking);

                // Assert
                using var context = new StationContext(options);
                var deletedvenue = await context.Booking.FindAsync(booking.Id);
                Assert.Null(deletedvenue);
            }


            [Fact]
            public async Task Update_ShouldModifyBooking()
            {
                // Arrange
                var options = CreateNewContextOptions();
                var service = new BookingRep((new StationContext(options)));
                var booking = new Booking { CustomerId = 2, Price = 20 };
                await service.Create(booking);

                // Act
                booking.CustomerId = 1;

                await service.Update(booking);

                // Assert
                using var context = new StationContext(options);
                var updatedbooking = await context.Booking.FindAsync(booking.Id);
                Assert.Equal(1, updatedbooking.CustomerId);

            }

           
            

        }
    }

