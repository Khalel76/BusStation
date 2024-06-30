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
    public class VehicalRepTest
    {
        private DbContextOptions<StationContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<StationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }


        [Fact]
        public async Task Save_ShouldAddVehical()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new VehicalRep(new StationContext(options));
            var Vehical = new Vehical { Type = "kia", Plate = "mk190" };

            // Act
            await service.Create(Vehical);

            // Assert
            using var context = new StationContext(options);
            var savedVehical = await context.Vehical.FirstOrDefaultAsync(a => a.Plate == "mk190");
            Assert.NotNull(savedVehical);
        }


        [Fact]
        public async Task Get_ShouldReturnVehicalById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new VehicalRep(new StationContext(options));
            var Vehical = new Vehical { Type = "kia", Plate = "mk190" };
            await service.Create(Vehical);

            // Act
            var fetchedVehical = await service.GetById(Vehical.Id);

            // Assert
            Assert.NotNull(fetchedVehical);
            Assert.Equal(Vehical.Id, fetchedVehical.Id);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllVehical()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new VehicalRep((new StationContext(options)));
            var Vehical1 = new Vehical { Type = "kia", Plate = "mk190" };
            var Vehical2 = new Vehical {Type = "kia", Plate = "mk190" };

            await service.Create(Vehical1);
            await service.Create(Vehical2);

            // Act
            var Vehical = await service.Get();

            // Assert
            Assert.Equal(2, Vehical.Count<Vehical>());
        }

        [Fact]
        public async Task Delete_ShouldRemoveVehical()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new VehicalRep((new StationContext(options)));
            var Vehical = new Vehical { Type = "kia", Plate = "mk190" };
            await service.Create(Vehical);

            // Act
            await service.Delete(Vehical);

            // Assert
            using var context = new StationContext(options);
            var deletedvenue = await context.Vehical.FindAsync(Vehical.Id);
            Assert.Null(deletedvenue);
        }


        [Fact]
        public async Task Update_ShouldModifyVehical()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new VehicalRep((new StationContext(options)));
            var Vehical = new Vehical {Type = "kia", Plate = "mk190" };
            await service.Create(Vehical);

            // Act
            Vehical.Plate = "kj123";

            await service.Update(Vehical);

            // Assert
            using var context = new StationContext(options);
            var updatedVehical = await context.Vehical.FindAsync(Vehical.Id);
            Assert.Equal("kj123", updatedVehical.Plate);

        }
    }
}
