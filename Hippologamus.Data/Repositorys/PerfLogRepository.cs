using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys
{
    public class PerfLogRepository : BaseRepository, IPerfLogRepository
    {
        public PerfLogRepository(HippologamusContext context, IAsyncPolicy retryPolicy)
            : base(context, retryPolicy)
        {
        }

        public async Task<List<PerfLog>> GetAll(PerfLogCollectionSearch perfLogDisplaySearch)
        {
            var query = _context.PerfLogs.AsQueryable();
            List<PerfLog> result = null;

            if (!string.IsNullOrEmpty(perfLogDisplaySearch.Assembly))
            {
                query = query.Where(x => x.Assembly == perfLogDisplaySearch.Assembly);
            }
            if (!string.IsNullOrEmpty(perfLogDisplaySearch.PerfItem))
            {
                query = query.Where(x => x.PerfItem == perfLogDisplaySearch.PerfItem);
            }
            if (!string.IsNullOrEmpty(perfLogDisplaySearch.RequestPath))
            {
                query = query.Where(x => x.RequestPath == perfLogDisplaySearch.RequestPath);
            }
            if (perfLogDisplaySearch.DateFrom != null)
            {
                query = query.Where(x => x.TimeStamp >= perfLogDisplaySearch.DateFrom);
            }
            if (perfLogDisplaySearch.DateTo != null)
            {
                query = query.Where(x => x.TimeStamp <= perfLogDisplaySearch.DateTo);
            }

            if (perfLogDisplaySearch.OrderBy == "TimeStamp")
            {
                if (perfLogDisplaySearch.OrderAscending)
                {
                    query = query.OrderBy(x => x.TimeStamp);
                }
                else
                {
                    query = query.OrderByDescending(x => x.TimeStamp);
                }
            }

            if (perfLogDisplaySearch.OrderBy == "MachineName")
            {
                if (perfLogDisplaySearch.OrderAscending)
                {
                    query = query.OrderBy(x => x.MachineName);
                }
                else
                {
                    query = query.OrderByDescending(x => x.MachineName);
                }
            }

            if (perfLogDisplaySearch.OrderBy == "ElapsedMilliseconds")
            {
                if (perfLogDisplaySearch.OrderAscending)
                {
                    query = query.OrderBy(x => x.ElapsedMilliseconds);
                }
                else
                {
                    query = query.OrderByDescending(x => x.ElapsedMilliseconds);
                }
            }

            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await query.ToListAsync();
            });
            return result;
        }

        public async Task<PerfLog> GetById(int perfLogId)
        {
            PerfLog result = null;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.PerfLogs.FirstOrDefaultAsync(x => x.Id == perfLogId);
            });
            return result;
        }

        public async Task<bool> Any(int id)
        {
            bool result = false;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.PerfLogs.AnyAsync(x => x.Id == id);
            });
            return result;
        }

        public async Task Delete(int id)
        {
            await _retryPolicy.ExecuteAsync(async () =>
            {
                var item = await _context.PerfLogs.FirstAsync(x => x.Id == id);
                _context.PerfLogs.Remove(item);
                await _context.SaveChangesAsync();
            });
        }
    }
}