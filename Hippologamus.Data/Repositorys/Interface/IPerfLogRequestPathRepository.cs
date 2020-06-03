using Hippologamus.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys.Interface
{
    public interface IPerfLogRequestPathRepository
    {
        Task<List<PerfLogPerfItem>> GetByAssembly(string perfLogAssembly);
    }
}