using Hippologamus.DTO.DTO;
using Hippologamus.DTO.Helpers;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IPerflogManager
    {
        Task<PagedList<PerfLogCollection>> GetAll(PerfLogCollectionSearch perfLogDisplaySearch);

        Task<PerfLogDetails> GetById(int perfLogId);

        Task<bool> Any(int perfLogId);

        Task Delete(int perfLogId);
    }
}