using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IPerfLogPerfItemManager
    {
        Task<List<PerfLogPerfItemCollection>> GetByAssembly(string perfLogAssembly);
    }
}