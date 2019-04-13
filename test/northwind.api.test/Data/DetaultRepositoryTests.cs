using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Northwind.Api.Data;
using Northwind.Api.Models;
using Xunit;
using Xunit.Abstractions;

namespace Northwind.Api.Test.Data
{
    public class DefaultRepositoryTests : IClassFixture<DbFixture>
    {
        ITestOutputHelper _debug;
        ILogger<DefaultEntityRepository<Product, int>> _logger;
        DbFixture _fixture;

        public DefaultRepositoryTests(DbFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            _debug = output;
            _logger = NullLogger<DefaultEntityRepository<Product, int>>.Instance;
        }

        [Fact]
        [Trait("suite", "integration")]
        public async Task Should_Update_Product()
        {
            var resolver = new DbContextResolver<NorthwindContext>(_fixture.DbContext);
            var repository = new DefaultEntityRepository<Product, int>(_logger, resolver);
            var product = repository.Get().IgnoreQueryFilters().SingleOrDefault(p => p.Id.Equals(25));

            Assert.NotNull(product);

            product.Discontinued = false;
            await repository.UpdateAsync(product.Id, product);
        }
    }
}
