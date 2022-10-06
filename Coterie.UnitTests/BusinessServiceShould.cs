using System.Threading.Tasks;
using Coterie.Domain.Businesses;
using Coterie.Domain.States;
using Coterie.UnitTests.Base;
using NUnit.Framework;

namespace Coterie.UnitTests
{
    public class BusinessServiceShould : TestsBase
    {
        private static readonly TestCaseData[] BusinessNameTestCases = 
        {
            // Invalid businesses
            new ("FakeBusiness", null),
            new (null, null),
            new ("", null),
            new (" ", null),
            
            // Valid businesses
            new ("Architect", new BusinessModel("Architect", 1)),
            new ("architect", new BusinessModel("Architect", 1)),
            new ("ARCHITECT", new BusinessModel("Architect", 1)),
            new ("Plumber", new BusinessModel("Plumber", 0.5m)),
            new ("plumber", new BusinessModel("Plumber", 0.5m)),
            new ("PLUMBER", new BusinessModel("Plumber", 0.5m)),
            new ("Programmer", new BusinessModel("Programmer", 1.25m)),
            new ("programmer", new BusinessModel("Programmer", 1.25m)),
            new ("PROGRAMMER", new BusinessModel("Programmer", 1.25m))
        };
        
        [TestCaseSource(nameof(BusinessNameTestCases))]
        public async Task ReturnExpectedData(string businessName, BusinessModel expectedBusiness)
        {
            // Act
            var business = await BusinessService.GetAsync(businessName);
            
            // Assert
            Assert.AreEqual(business, expectedBusiness);
        }
    }
}