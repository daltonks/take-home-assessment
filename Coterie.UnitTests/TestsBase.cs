using System;
using Coterie.Db;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Coterie.UnitTests
{
    public class TestsBase
    {
        protected CoterieDbContext DbContext => _lazyDbContext.Value;

        private readonly Lazy<CoterieDbContext> _lazyDbContext = new(() => {
            var dbContext = CoterieDbContext.CreateSqliteContext("Data Source=:memory:");
            dbContext.Database.Migrate();
            return dbContext;
        });
        
        [TearDown]
        public virtual void TearDown()
        {
            if (_lazyDbContext.IsValueCreated)
            {
                _lazyDbContext.Value.Dispose();
            }
        }
    }
}