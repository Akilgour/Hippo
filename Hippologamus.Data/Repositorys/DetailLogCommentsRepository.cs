using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Polly;
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
    }
}