using Coterie.Db.Tables;
using Microsoft.EntityFrameworkCore;

namespace Coterie.Db
{
    public class CoterieDbContext : DbContext
    {
        public static CoterieDbContext CreateSqliteContext(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<CoterieDbContext>();
            ConfigureSqlite(connectionString, builder);
            return new CoterieDbContext(builder.Options);
        }
        
        public static void ConfigureSqlite(string connectionString, DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

#if DEBUG
            builder.EnableDetailedErrors();
            builder.EnableSensitiveDataLogging();
#endif
        }
        
        public CoterieDbContext(DbContextOptions<CoterieDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(entity => {
                entity.HasKey(e => e.ShortName);
                entity.HasIndex(e => e.LongName);
                entity.Property(e => e.LongName).IsRequired();
            });
        }
    }
}