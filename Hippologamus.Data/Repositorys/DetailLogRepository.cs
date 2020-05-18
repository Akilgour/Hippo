using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<DetailLog>> GetAllErrors(ErrorLogDisplaySearch errorLogDisplaySearch)
        {
            var query = _context.DetailLogs.AsQueryable();
            List<DetailLog> result = null;

            if (!string.IsNullOrEmpty(errorLogDisplaySearch.Assembly))
            {
                query = query.Where(x => x.Assembly == errorLogDisplaySearch.Assembly);
            }
            if (!string.IsNullOrEmpty(errorLogDisplaySearch.RequestPath))
            {
                query = query.Where(x => x.RequestPath == errorLogDisplaySearch.RequestPath);
            }
            if (errorLogDisplaySearch.DateFrom != null)
            {
                query = query.Where(x => x.TimeStamp >= errorLogDisplaySearch.DateFrom);
            }
            if (errorLogDisplaySearch.DateTo != null)
            {
                query = query.Where(x => x.TimeStamp <= errorLogDisplaySearch.DateTo);
            }

            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await query.Where(x => x.Level == "Error").ToListAsync();
            });
            return result;
        }
    }
}