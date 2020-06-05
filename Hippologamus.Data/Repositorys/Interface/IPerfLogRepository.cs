using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys.Interface
{
    public interface IPerfLogRepository
    {
        Task<List<PerfLog>> GetAll(PerfLogCollectionSearch perfLogDisplaySearch);
        Task<PerfLog> GetById(int perfLogId);
        Task<bool> Any(int id);
        Task Delete(int perfLogId);
    }
}