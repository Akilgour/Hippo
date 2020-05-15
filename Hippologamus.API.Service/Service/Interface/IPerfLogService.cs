using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service.Interface
{
    public interface IPerfLogService
    {
        Task<List<PerfLog>> GetAll(PerfLogDisplaySearch perfLogDisplaySearch);
        Task<PerfLog> GetById(int perfLogId);
    }
}