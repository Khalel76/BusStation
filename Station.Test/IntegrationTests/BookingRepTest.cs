using Microsoft.EntityFrameworkCore;
using Moq;
using Station.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Test.IntegrationTests
{
    //private DbContextOptions<StationContext> CreateNewContextOptions()
    //{
    //    return new DbContextOptionsBuilder<StationContext>()
    //        .UseInMemoryDatabase(Guid.NewGuid().ToString())
    //        .Options;
    //}

    //private IDbContextFactory<StationContext> GetDbContextFactoryAsync(DbContextOptions<StationContext> options)
    //{
    //    var mockDbFactory = new Mock<IDbContextFactory<StationContext>>();
    //    mockDbFactory.Setup(f => f.CreateDbContext()).Returns(() => new StationContext(options));
    //    return mockDbFactory.Object;

    //}
}
