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
    public class PerfLogRequestPathRepository : BaseRepository, IPerfLogRequestPathRepository
    {
        public PerfLogRequestPathRepository(HippologamusContext context, IAsyncPolicy retryPolicy)
            : base(context, retryPolicy)
        {
        }

        public async Task<List<PerfLogPerfItem>> GetByAssembly(string perfLogAssembly)
        {
            List<PerfLogPerfItem> result = null;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.PerfLogs
                  .Where(x => x.Assembly == perfLogAssembly)
                  .Select(x => new PerfLogPerfItem { Assembly = x.Assembly, PerfItem = x.PerfItem }).Distinct()
                  .OrderBy(x => x.PerfItem)
                  .ToListAsync();
            });
            return result;
        }
    }
}