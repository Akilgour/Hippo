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

        public DbSet<DetailLog> DetailLogs { get; set; }
        public DbSet<DetailLogComment> DetailLogComments { get; set; }
        public DbSet<PerfLog> PerfLogs { get; set; }
        public DbSet<UsageLog> UsageLogs { get; set; }
    }
}