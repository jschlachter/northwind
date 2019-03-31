using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;

namespace Northwind.Api.Test.Models
{
    public class ProductTests : IClassFixture<DbFixture>
    {
        ILogger _logger;

        DbFixture _fixture;

        public ProductTests(DbFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;

            _logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                        .WriteTo.TestOutput(output, LogEventLevel.Verbose)
                        .CreateLogger()
                        .ForContext<ProductTests>();

            Log.Logger = _logger;
        }

        [Fact]
        [Trait("suite", "integration")]
        public void Should_Get_Products()
        {
            var products = _fixture.DbContext.Products.Include("Category");
            Assert.True(products.Any());

            foreach(var product in products){
                _logger.Debug("Db Record: {Id} - {Category} - {ProductName}",product.Id, product.Category.Name, product.Name);
            }
        }
    }
}
