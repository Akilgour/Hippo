using Hippologamus.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IPerflogManager
    {
        Task<List<PerfLogDisplay>> GetAll(PerfLogDisplaySearch perfLogDisplaySearch);
        Task<PerfLogDetails> GetById(int perfLogId);
    }
}
