using Hippologamus.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hippologamus.Data.Context
{
    public class HippologamusContext : DbContext
    {
        public DbSet<DetailLog> DetailLogs { get; set; }
        public DbSet<DetailLogComment> DetailLogComments { get; set; }
        public DbSet<PerfLog> PerfLogs { get; set; }
        public DbSet<UsageLog> UsageLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Logging");            
        }
    }
}