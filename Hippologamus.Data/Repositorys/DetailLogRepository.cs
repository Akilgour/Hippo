using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys
{
    public class DetailLogRepository : BaseRepository, IDetailLogRepository
    {
        public DetailLogRepository(HippologamusContext context, IAsyncPolicy retryPolicy)
           : base(context, retryPolicy)
        {
        }

        public async Task<List<DetailLog>> GetAll()
        {
            List<DetailLog> result = null;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.DetailLogs.ToListAsync();
            });
            return result;
        }
    }
}