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
    public class DriverRepTest
    {
        private DbContextOptions<StationContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<StationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }


        [Fact]
        public async Task Save_ShouldAddDriver()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new DriverRep(new StationContext(options));
            var Driver = new Driver { Name = "ali", VehicalId = 190 };

            // Act
            await service.Create(Driver);

            // Assert
            using var context = new StationContext(options);
            var savedDriver = await context.Driver.FirstOrDefaultAsync(a => a.VehicalId == 190);
            Assert.NotNull(savedDriver);
        }


        [Fact]
        public async Task Get_ShouldReturnDriverById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new DriverRep(new StationContext(options));
            var Driver = new Driver {Name = "ali", VehicalId = 20 };
            await service.Create(Driver);

            // Act
            var fetchedDriver = await service.GetById(Driver.Id);

            // Assert
            Assert.NotNull(fetchedDriver);
            Assert.Equal(Driver.Id, fetchedDriver.Id);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllDriver()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new DriverRep((new StationContext(options)));
            var Driver1 = new Driver {Name = "ali", VehicalId = 20 };
            var Driver2 = new Driver {Name = "ali", VehicalId = 20 };

            await service.Create(Driver1);
            await service.Create(Driver2);

            // Act
            var Driver = await service.Get();

            // Assert
            Assert.Equal(2, Driver.Count<Driver>());
        }

        [Fact]
        public async Task Delete_ShouldRemoveDriver()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new DriverRep((new StationContext(options)));
            var Driver = new Driver {Name = "ali", VehicalId = 20 };
            await service.Create(Driver);

            // Act
            await service.Delete(Driver);

            // Assert
            using var context = new StationContext(options);
            var deletedvenue = await context.Driver.FindAsync(Driver.Id);
            Assert.Null(deletedvenue);
        }


        [Fact]
        public async Task Update_ShouldModifyDriver()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new DriverRep((new StationContext(options)));
            var Driver = new Driver {Name = "ali", VehicalId = 20 };
            await service.Create(Driver);

            // Act
            Driver.VehicalId = 1;

            await service.Update(Driver);

            // Assert
            using var context = new StationContext(options);
            var updatedDriver = await context.Driver.FindAsync(Driver.Id);
            Assert.Equal(1, updatedDriver.VehicalId);

        }
    }
}
