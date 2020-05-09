using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IPerflogManager
    {
        Task<List<PerfLogDisplay>> GetAll();
    }
}
