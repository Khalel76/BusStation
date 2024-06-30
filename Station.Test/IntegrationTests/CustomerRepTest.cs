using Microsoft.EntityFrameworkCore;
using Station.Domain.Entities;
using Station.Persistance;
using Station.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Station.Test.IntegrationTests
{
    public class CustomerRepTest
    {
        private DbContextOptions<StationContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<StationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }


        [Fact]
        public async Task Save_ShouldAddCustomer()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new CustomerRep(new StationContext(options));
            var Customer = new Customer { Gender = 'm', Name = "ali" };

            // Act
            await service.Create(Customer);

            // Assert
            using var context = new StationContext(options);
            var savedCustomer = await context.Customer.FirstOrDefaultAsync(a => a.Name == "ali");
            Assert.NotNull(savedCustomer);
        }


        [Fact]
        public async Task Get_ShouldReturnCustomerById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new CustomerRep(new StationContext(options));
            var Customer = new Customer { Gender = 'm', Name = "ali" };
            await service.Create(Customer);

            // Act
            var fetchedCustomer = await service.GetById(Customer.Id);

            // Assert
            Assert.NotNull(fetchedCustomer);
            Assert.Equal(Customer.Id, fetchedCustomer.Id);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllCustomer()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new CustomerRep((new StationContext(options)));
            var Customer1 = new Customer {Gender = 'm', Name = "ali" };
            var Customer2 = new Customer {Gender = 'm', Name = "ali" };

            await service.Create(Customer1);
            await service.Create(Customer2);

            // Act
            var Customer = await service.Get();

            // Assert
            Assert.Equal(2, Customer.Count<Customer>());
        }

        [Fact]
        public async Task Delete_ShouldRemoveCustomer()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new CustomerRep((new StationContext(options)));
            var Customer = new Customer {Gender = 'm', Name = "ali" };
            await service.Create(Customer);

            // Act
            await service.Delete(Customer);

            // Assert
            using var context = new StationContext(options);
            var deletedCustomer = await context.Customer.FindAsync(Customer.Id);
            Assert.Null(deletedCustomer);
        }


        [Fact]
        public async Task Update_ShouldModifyCustomer()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new CustomerRep((new StationContext(options)));
            var Customer = new Customer { Gender = 'm', Name = "ali" };
            await service.Create(Customer);

            // Act
            Customer.Gender = 'f';

            await service.Update(Customer);

            // Assert
            using var context = new StationContext(options);
            var updatedCustomer = await context.Customer.FindAsync(Customer.Id);
            Assert.Equal(1, updatedCustomer.Gender);

        }
    }
}
