using Hippologamus.DTO.DTO;
using Hippologamus.DTO.Helpers;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IPerflogManager
    {
        Task<PagedList<PerfLogDisplay>> GetAll(PerfLogDisplaySearch perfLogDisplaySearch);

        Task<PerfLogDetails> GetById(int perfLogId);
    }
}