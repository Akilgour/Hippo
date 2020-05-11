using Hippologamus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service.Interface
{
    public interface IPerfLogService
    {
        Task<List<PerfLog>> GetAll();
        Task<PerfLog> GetById(int perfLogId);
    }
}