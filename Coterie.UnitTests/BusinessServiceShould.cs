using System.Threading.Tasks;
using Coterie.Domain.Businesses;
using Coterie.Domain.States;
using NUnit.Framework;

namespace Coterie.UnitTests
{
    public class BusinessServiceShould : TestsBase
    {
        [Test]
        public async Task ReturnDataOnProperBusinesses()
        {
            // Act
            var architect = await BusinessService.GetAsync("Architect");
            var plumber = await BusinessService.GetAsync("Plumber");
            var programmer = await BusinessService.GetAsync("Programmer");
            
            // Assert
            Assert.AreEqual(architect, new BusinessModel("Architect", 1));
            Assert.AreEqual(plumber, new BusinessModel("Plumber", 0.5m));
            Assert.AreEqual(programmer, new BusinessModel("Programmer", 1.25m));
        }

        [Test]
        public async Task ReturnNullOnInvalidBusinesses()
        {
            // Act
            var fakeBusiness = await BusinessService.GetAsync("FakeBusiness");
            var nullStringBusiness = await BusinessService.GetAsync(null);
            var whitespaceBusiness = await BusinessService.GetAsync(" ");
            
            // Assert
            Assert.IsNull(fakeBusiness);
            Assert.IsNull(nullStringBusiness);
            Assert.IsNull(whitespaceBusiness);
        }
    }
}