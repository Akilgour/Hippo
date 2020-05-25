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

        public async Task<List<PerfLogRequestPath>> GetByAssembly(string perfLogAssembly)
        {
            List<PerfLogRequestPath> result = null;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.PerfLogs
                  .Where(x => x.Assembly == perfLogAssembly)
                  .Select(m => new PerfLogRequestPath { Assembly = m.Assembly, RequestPath = m.RequestPath }).Distinct()
                  .OrderBy(x => x.RequestPath)
                  .ToListAsync();
            });
            return result;
        }
    }
}