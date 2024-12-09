using Microsoft.EntityFrameworkCore;
using Station.Domain.Entities;
using Station.Persistance;
using Station.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Test.IntegrationTests
{
    public class JourneyRepTest
    {
        private DbContextOptions<StationContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<StationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }


        [Fact]
        public async Task Save_ShouldAddJourney()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new JourneyRep(new StationContext(options));
            var Journey = new Journey { EmployeeId = 1, Price = 190 };

            // Act
            await service.Create(Journey);

            // Assert
            using var context = new StationContext(options);
            var savedJourney = await context.Journey.FirstOrDefaultAsync(a => a.Price == 190);
            Assert.NotNull(savedJourney);
        }


        [Fact]
        public async Task Get_ShouldReturnJourneyById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new JourneyRep(new StationContext(options));
            var Journey = new Journey { EmployeeId = 2, Price = 20 };
            await service.Create(Journey);

            // Act
            var fetchedJourney = await service.GetById(Journey.Id);

            // Assert
            Assert.NotNull(fetchedJourney);
            Assert.Equal(Journey.Id, fetchedJourney.Id);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllJourney()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new JourneyRep((new StationContext(options)));
            var Journey1 = new Journey { EmployeeId = 1, Price = 20 };
            var Journey2 = new Journey { EmployeeId = 2, Price = 20 };

            await service.Create(Journey1);
            await service.Create(Journey2);

            // Act
            var Journey = await service.Get();

            // Assert
            Assert.Equal(2, Journey.Count<Journey>());
        }

        [Fact]
        public async Task Delete_ShouldRemoveJourney()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new JourneyRep((new StationContext(options)));
            var Journey = new Journey { EmployeeId = 2, Price = 20 };
            await service.Create(Journey);

            // Act
            await service.Delete(Journey);

            // Assert
            using var context = new StationContext(options);
            var deletedvenue = await context.Journey.FindAsync(Journey.Id);
            Assert.Null(deletedvenue);
        }


        [Fact]
        public async Task Update_ShouldModifyJourney()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new JourneyRep((new StationContext(options)));
            var Journey = new Journey { EmployeeId = 2, Price = 20 };
            await service.Create(Journey);

            // Act
            Journey.EmployeeId = 1;

            await service.Update(Journey);

            // Assert
            using var context = new StationContext(options);
            var updatedJourney = await context.Journey.FindAsync(Journey.Id);
            Assert.Equal(1, updatedJourney.EmployeeId);

        }
    }
}
