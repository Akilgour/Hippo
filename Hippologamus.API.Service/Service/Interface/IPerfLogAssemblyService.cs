using Hippologamus.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service.Interface
{
    public interface IPerfLogAssemblyService
    {
        Task<List<PerfLogAssembly>> GetAll();
    }
}