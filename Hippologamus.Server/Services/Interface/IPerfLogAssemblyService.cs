using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services.Interface
{
    public interface IPerfLogAssemblyService
    {
        Task<IEnumerable<PerfLogAssemblyCollection>> GetAll();
    }
}
