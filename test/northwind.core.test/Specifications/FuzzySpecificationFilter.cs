using System.Collections.Generic;
using Northwind.Core.Entities;
using Xunit;
using Bogus;
using Northwind.Core.Specifications;
using System.Linq;

namespace Northwind.Core.Test
{
    public class FuzzySpecificationFilter
    {
        [Theory]
        [InlineData("MN", 3)]
        [InlineData("Sartell", 1)]

        public void MatchesExpectedNumberOfItems(string queryString, int expectedCount)
        {
            var spec = new FuzzySpecification<Customer, string>(0, 10, queryString,
                        nameof(Customer.Address.City),
                        nameof(Customer.Address.Region));

            var result = GetTestItemCollection()
                            .AsQueryable()
                            .Where(spec.Criteria);

            Assert.Equal(expectedCount, result.Count());
        }

        public List<Customer> GetTestItemCollection()
        {
            return new List<Customer> {
                new Customer {
                    Address = new Address {
                        City = "Rochester",
                        Street1 = "3635 20th St SE",
                        PostalCode = "55904",
                        Region = "MN",
                        Country = "USA"
                    }
                },
                new Customer {
                    Address = new Address {
                        City = "Sartell",
                        Street1 = "815 4th Ave N",
                        PostalCode = "56377",
                        Region = "MN",
                        Country = "USA"
                    }
                },
                new Customer {
                    Address = new Address {
                        City = "Garden City",
                        Street1 = "110 Washington St",
                        PostalCode = "56034",
                        Region = "MN",
                        Country = "USA"
                    }
                }
            };
        }
    }
}
