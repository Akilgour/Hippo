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
    public class DetailLogCommentsRepository : BaseRepository, IDetailLogCommentsRepository
    {
        public DetailLogCommentsRepository(HippologamusContext context, IAsyncPolicy retryPolicy)
           : base(context, retryPolicy)
        {
        }

        public async Task CreateDetailLogComent(DetailLogComment detailLogComment)
        {
            await _retryPolicy.ExecuteAsync(async () =>
            {
                var addedEntity = _context.Add(detailLogComment);
                await _context.SaveChangesAsync();
            });
        }

        public async Task<List<DetailLogComment>> GetByDetailLogId(int detailLogId)
        {
            List<DetailLogComment> result = null;
            await _retryPolicy.ExecuteAsync(async () =>
            {
                result = await _context.DetailLogComments.Where(x => x.DetailLogId == detailLogId).ToListAsync();
            });
            return result;
        }
    }
}