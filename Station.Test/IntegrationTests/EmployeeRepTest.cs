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
    public class EmployeeRepTest
    {
        private DbContextOptions<StationContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<StationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }


        [Fact]
        public async Task Save_ShouldAddEmployee()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new EmployeeRep(new StationContext(options));
            var Employee = new Employee {Name = "ali", Salary = 190 };

            // Act
            await service.Create(Employee);

            // Assert
            using var context = new StationContext(options);
            var savedEmployee = await context.Employee.FirstOrDefaultAsync(a => a.Salary == 190);
            Assert.NotNull(savedEmployee);
        }


        [Fact]
        public async Task Get_ShouldReturnEmployeeById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new EmployeeRep(new StationContext(options));
            var Employee = new Employee {Name = "ali", Salary = 20 };
            await service.Create(Employee);

            // Act
            var fetchedEmployee = await service.GetById(Employee.Id);

            // Assert
            Assert.NotNull(fetchedEmployee);
            Assert.Equal(Employee.Id, fetchedEmployee.Id);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllEmployee()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new EmployeeRep((new StationContext(options)));
            var Employee1 = new Employee {Name = "ali", Salary = 20 };
            var Employee2 = new Employee {Name = "ali", Salary = 20 };

            await service.Create(Employee1);
            await service.Create(Employee2);

            // Act
            var Employee = await service.Get();

            // Assert
            Assert.Equal(2, Employee.Count<Employee>());
        }

        [Fact]
        public async Task Delete_ShouldRemoveEmployee()
        {
            // Arrange
            var options = CreateNewContextOptions();
            //var factory = GetDbContextFactoryAsync(options);
            var service = new EmployeeRep((new StationContext(options)));
            var Employee = new Employee {Name = "ali", Salary = 20 };
            await service.Create(Employee);

            // Act
            await service.Delete(Employee);

            // Assert
            using var context = new StationContext(options);
            var deletedvenue = await context.Employee.FindAsync(Employee.Id);
            Assert.Null(deletedvenue);
        }


        [Fact]
        public async Task Update_ShouldModifyEmployee()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var service = new EmployeeRep((new StationContext(options)));
            var Employee = new Employee {Name = "ali", Salary = 20 };
            await service.Create(Employee);

            // Act
            Employee.Salary = 1;

            await service.Update(Employee);

            // Assert
            using var context = new StationContext(options);
            var updatedEmployee = await context.Employee.FindAsync(Employee.Id);
            Assert.Equal(1, updatedEmployee.Salary);

        }
    }
}
