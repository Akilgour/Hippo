using Hippologamus.Data.Context;
using Polly;

namespace Hippologamus.Data.Repositorys
{
    public class BaseRepository
    {
        protected readonly HippologamusContext _context;
        protected readonly IAsyncPolicy _retryPolicy;

        public BaseRepository(HippologamusContext context, IAsyncPolicy retryPolicy)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _retryPolicy = retryPolicy ?? throw new System.ArgumentNullException(nameof(retryPolicy));
        }
    }
}