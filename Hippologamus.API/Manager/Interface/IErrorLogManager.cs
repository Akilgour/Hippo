using Hippologamus.DTO.DTO;
using Hippologamus.DTO.Helpers;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IErrorLogManager
    {
        Task<PagedList<ErrorLogCollection>> GetAllError(ErrorLogCollectionSearch errorLogDisplaySearch);
    }
}