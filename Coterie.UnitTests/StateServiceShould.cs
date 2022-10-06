using System.Threading.Tasks;
using Coterie.Domain.States;
using Coterie.UnitTests.Base;
using NUnit.Framework;

namespace Coterie.UnitTests
{
    public class StateServiceShould : TestsBase
    {
        private static readonly TestCaseData[] StateNameTestCases =
        {
            // Invalid names
            new("FakeState", null),
            new(null, null),
            new("", null),
            new(" ", null),
            
            // Short names
            new("OH", new StateModel("OH", "Ohio", 1)),
            new("FL", new StateModel("FL", "Florida", 1.2m)),
            new("TX", new StateModel("TX", "Texas", 0.943m)),
            
            // Long names
            new("Ohio", new StateModel("OH", "Ohio", 1)),
            new("Florida", new StateModel("FL", "Florida", 1.2m)),
            new("Texas", new StateModel("TX", "Texas", 0.943m)),
            new("OHIO", new StateModel("OH", "Ohio", 1)),
            new("FLORIDA", new StateModel("FL", "Florida", 1.2m)),
            new("TEXAS", new StateModel("TX", "Texas", 0.943m))
        };
        
        [TestCaseSource(nameof(StateNameTestCases))]
        public async Task ReturnExpectedData(string shortName, StateModel expectedState)
        {
            // Act
            var state = await StateService.GetAsync(shortName);
            
            // Assert
            Assert.AreEqual(state, expectedState);
        }
    }
}