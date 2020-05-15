using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys
{
    public class PerfLogPerformanceItemRepository : BaseRepository, IPerfLogPerformanceItemRepository
    {
        public PerfLogPerformanceItemRepository(HippologamusContext context, IAsyncPolicy retryPolicy)
         : base(context, retryPolicy)
        {
        }

        public async Task<List<PerfLogPerformanceItem>> GetByAssembly(string perfLogAssembly)
        {
            List<PerfLogPerformanceItem> result = null;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.PerfLogs
                  .Where(x => x.Assembly == perfLogAssembly)
                  .Select(m => new PerfLogPerformanceItem { Assembly = m.Assembly, PerformanceItem = m.PerfItem }).Distinct()
                  .OrderBy(x => x.PerformanceItem)
                  .ToListAsync();
            });
            return result;
        }
    }
}