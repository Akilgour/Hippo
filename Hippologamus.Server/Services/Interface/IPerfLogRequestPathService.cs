using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services.Interface
{
    public interface IPerfLogRequestPathService
    {
        Task<IEnumerable<PerfLogRequestPathCollection>> GetPerfLogRequestPaths(string perfLogAssembly);
    }
}