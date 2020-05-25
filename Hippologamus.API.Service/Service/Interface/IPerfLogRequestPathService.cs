using Hippologamus.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service.Interface
{
    public interface IPerfLogRequestPathService
    {
        Task<List<PerfLogRequestPath>> GetByAssembly(string perfLogAssembly);
    }
}