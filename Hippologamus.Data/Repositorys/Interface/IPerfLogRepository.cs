using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys.Interface
{
    public interface IPerfLogRepository
    {
        Task<List<PerfLog>> GetAll(PerfLogDisplaySearch perfLogDisplaySearch);
        Task<PerfLog> GetById(int perfLogId);
    }
}