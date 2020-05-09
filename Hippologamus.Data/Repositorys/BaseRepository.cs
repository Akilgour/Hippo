using Hippologamus.Data.Context;

namespace Hippologamus.Data.Repositorys
{
    public class BaseRepository
    {
        protected readonly HippologamusContext _context;

        public BaseRepository(HippologamusContext context)
        {
            _context = context;
        }
    }
}