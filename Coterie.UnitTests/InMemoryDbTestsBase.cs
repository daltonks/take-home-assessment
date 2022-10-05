using System;
using Coterie.Db;
using Coterie.Services.Businesses;
using Coterie.Services.States;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Coterie.UnitTests
{
    public class InMemoryDbTestsBase
    {
        protected IBusinessService BusinessService { get; private set; }
        protected IStateService StateService { get; private set; }
        private CoterieDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            _dbContext = CoterieDbContext.CreateSqliteContext("Data Source=:memory:");
            _dbContext.Database.Migrate();
            
            BusinessService = new BusinessService(_dbContext);
            StateService = new StateService(_dbContext);
        }
        
        [TearDown]
        public virtual void TearDown()
        {
            _dbContext.Dispose();
        }
    }
}