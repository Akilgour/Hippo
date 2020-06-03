using Hippologamus.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service.Interface
{
    public interface IPerfLogPerfItemService
    {
        Task<List<PerfLogPerfItem>> GetByAssembly(string perfLogAssembly);
    }
}