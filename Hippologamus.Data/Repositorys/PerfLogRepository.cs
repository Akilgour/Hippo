using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys
{
    public class PerfLogRepository : BaseRepository, IPerfLogRepository
    {
        public PerfLogRepository(HippologamusContext context, IAsyncPolicy retryPolicy)
            : base(context, retryPolicy)
        {
        }

        public async Task<List<PerfLog>> GetAll()
        {
            List<PerfLog> result = null;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.PerfLogs.ToListAsync();
            });
            return result;
        }

        public async  Task<PerfLog> GetById(int perfLogId)
        {
            PerfLog result = null;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.PerfLogs.FirstAsync(x => x.Id == perfLogId);
            });
            return result;
        }
    }
}