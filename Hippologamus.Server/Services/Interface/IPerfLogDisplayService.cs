using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services.Interface
{
    public interface IPerfLogDisplayService
    {
        Task<PerfLogDisplayRoot> PerfLogDisplaySearch(PerfLogDisplaySearch search);
    }
}
