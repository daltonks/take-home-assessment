using System;
using System.IO;
using Coterie.Db;
using Coterie.Services.Businesses;
using Coterie.Services.States;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Coterie.UnitTests
{
    public class TestsBase
    {
        protected IBusinessService BusinessService { get; private set; }
        protected IStateService StateService { get; private set; }
        private readonly string _dbPath = Guid.NewGuid().ToString();
        private CoterieDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            _dbContext = CoterieDbContext.CreateSqliteContext($"Filename={_dbPath}");
            _dbContext.Database.Migrate();
            
            BusinessService = new BusinessService(_dbContext);
            StateService = new StateService(_dbContext);
        }
        
        [TearDown]
        public virtual void TearDown()
        {
            _dbContext.Dispose();
            File.Delete(_dbPath);
        }
    }
}