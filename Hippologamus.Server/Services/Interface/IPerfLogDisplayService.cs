using Hippologamus.Shared.DTO;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services.Interface
{
    public interface IPerfLogDisplayService
    {
        Task<PerfLogCollectionResponce> PerfLogDisplaySearch(PerfLogCollectionSearch search);
        Task<PerfLogCollectionResponce> GetByLink(string link);
        Task DeleteById(int Id);
    }
}