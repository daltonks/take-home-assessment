using System;
using Microsoft.EntityFrameworkCore.Design;

namespace Coterie.Db
{
    // ReSharper disable once UnusedType.Global
    public class CoterieDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoterieDbContext>
    {
        public CoterieDbContext CreateDbContext(string[] args)
        {
            return CoterieDbContext.CreateSqliteContext("Filename=DesignTime.db3");
        }
    }
}