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
    public class PerfLogAssemblyRepository : BaseRepository, IPerfLogAssemblyRepository
    {
        public PerfLogAssemblyRepository(HippologamusContext context, IAsyncPolicy retryPolicy)
            : base(context, retryPolicy)
        {
        }

        public async Task<List<PerfLogAssembly>> GetAll()
        {
            List<PerfLogAssembly> result = null;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.PerfLogs
                  .Select(c => c.Assembly).Distinct()
                  .Select(m => new PerfLogAssembly { Assembly = m }).OrderBy(x => x.Assembly)
                  .ToListAsync();
            });
            return result;
        }
    }
}