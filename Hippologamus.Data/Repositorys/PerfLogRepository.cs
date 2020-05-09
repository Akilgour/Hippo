using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys
{
    public class PerfLogRepository : BaseRepository, IPerfLogRepository
    {
        public PerfLogRepository(HippologamusContext context)
            : base(context)
        {
        }

        public async Task<List<PerfLog>> GetAll()
        {
            List<PerfLog> result = null;
            result = await _context.PerfLogs.ToListAsync();
            return result;
        }
    }
}
