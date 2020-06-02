using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace CityOfInfo.Domain.EntityFramework.Tests
{
    public class DomainContextTests 
    {
        public DomainContextTests()
        {
        }

        [Fact]
        public void SouldGetErrorForEnteringSamePowerIdTwice()
        {
            var powers = new Power[]
            {
                new Power { Id = 0, Name = "test" },
                new Power { Id = 0, Name = "other" },
            };
            
            using (var domainContext = new DomainContext(Options()))
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    foreach (var power in powers)
                        domainContext.Powers.Add(power);
                    domainContext.SaveChanges();
                });
            }
        }

        [Fact]
        public void ShouldUseAssignedIdWhenAddingPower()
        {
            var powers = new Power[]
            {
                new Power { Id = 10, Name = "test" },
                new Power { Id = 20, Name = "other" },
            };

            var options = Options();

            using (var domainContext = new DomainContext(options))
            {
                foreach (var power in powers)
                    domainContext.Powers.Add(power);
                domainContext.SaveChanges();
            }
            using (var newDomainContext = new DomainContext(options))
            {
                var addedPowers = newDomainContext.Powers;
                Assert.Contains(addedPowers, x => x.Id == 10 || x.Id == 20);
            }
        }

        [Fact]
        public void AllPropertiesShouldPersist()
        {
            var expected = new Power
            {
                Id = 100,
                Name = "Name",
                Description = "Description",
                Display = "Display",
                LongDescription = "LongDescription",
            };

            var options = Options();
            using (var domainContext = new DomainContext(options))
            {
                domainContext.Powers.Add(expected);
                domainContext.SaveChanges();
            }
                
            using (var newDomainContext = new DomainContext(options))
            {
                var powers = newDomainContext.Powers;
                Assert.Equal(1, powers.Count());
                var actual = powers.FirstOrDefault();
                var properties = typeof(Power).GetProperties();
                foreach (var property in properties)
                {
                    Assert.Equal(property.GetValue(expected), property.GetValue(actual));
                }
            }
        }

        /// <summary>
        /// Options creates db context options scoped to the caller. Each new instance call to options will create a brand new empty database
        /// </summary>
        /// <returns></returns>
        private static DbContextOptions Options([CallerMemberName] string name = "database")
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            return new DbContextOptionsBuilder()
               .UseInMemoryDatabase(name)
               .UseInternalServiceProvider(serviceProvider)
               .Options;            
        }
    }
}
