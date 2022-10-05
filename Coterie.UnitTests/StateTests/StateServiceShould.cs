using Coterie.Services.States;
using NUnit.Framework;

namespace Coterie.UnitTests.StateTests
{
    public class StateServiceShould : TestsBase
    {
        private IStateService _stateService;
        
        [SetUp]
        public void SetUp()
        {
            _stateService = new StateService(DbContext);
        }
        
        
    }
}