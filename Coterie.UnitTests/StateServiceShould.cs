using System.Threading.Tasks;
using Coterie.Domain.States;
using NUnit.Framework;

namespace Coterie.UnitTests
{
    public class StateServiceShould : TestsBase
    {
        [Test]
        public async Task WorkWithShortNames()
        {
            // Act
            var ohio = await StateService.GetAsync("OH");
            var florida = await StateService.GetAsync("FL");
            var texas = await StateService.GetAsync("TX");
            
            // Assert
            Assert.AreEqual(ohio, new StateModel("OH", "Ohio", 1));
            Assert.AreEqual(florida, new StateModel("FL", "Florida", 1.2m));
            Assert.AreEqual(texas, new StateModel("TX", "Texas", 0.943m));
        }
        
        [Test]
        public async Task WorkWithLongNames()
        {
            // Act
            var ohio = await StateService.GetAsync("Ohio");
            var florida = await StateService.GetAsync("Florida");
            var texas = await StateService.GetAsync("Texas");
            
            // Assert
            Assert.AreEqual(ohio, new StateModel("OH", "Ohio", 1));
            Assert.AreEqual(florida, new StateModel("FL", "Florida", 1.2m));
            Assert.AreEqual(texas, new StateModel("TX", "Texas", 0.943m));
        }
        
        [Test]
        public async Task WorkWithInvalidNames()
        {
            // Arrange
            var fakeState = await StateService.GetAsync("FakeState");
            var nullStringState = await StateService.GetAsync(null);
            var whitespaceState = await StateService.GetAsync(" ");
            
            // Assert
            Assert.IsNull(fakeState);
            Assert.IsNull(nullStringState);
            Assert.IsNull(whitespaceState);
        }
    }
}