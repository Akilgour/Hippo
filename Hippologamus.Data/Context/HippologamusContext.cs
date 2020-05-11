using Hippologamus.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hippologamus.Data.Context
{
    public class HippologamusContext : DbContext
    {
        public HippologamusContext(DbContextOptions<HippologamusContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public HippologamusContext()
        {

        }

        public DbSet<DetailLog> DetailLogs { get; set; }
        public DbSet<DetailLogComment> DetailLogComments { get; set; }
        public DbSet<PerfLog> PerfLogs { get; set; }
        public DbSet<UsageLog> UsageLogs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Logging");
            }
        }
    }
}