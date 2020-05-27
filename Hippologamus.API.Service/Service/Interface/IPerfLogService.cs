using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service.Interface
{
    public interface IPerfLogService
    {
        Task<List<PerfLog>> GetAll(PerfLogCollectionSearch perfLogDisplaySearch);
        Task<PerfLog> GetById(int perfLogId);
    }
}