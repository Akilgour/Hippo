using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IPerfLogAssemblyManager
    {
        Task<List<PerfLogAssemblyCollection>> GetAll();
    }
}