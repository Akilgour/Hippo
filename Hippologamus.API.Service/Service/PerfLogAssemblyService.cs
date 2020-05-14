using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service
{
    public class PerfLogAssemblyService : IPerfLogAssemblyService
    {
        private readonly IPerfLogAssemblyRepository _perfLogAssemblyRepository;

        public PerfLogAssemblyService(IPerfLogAssemblyRepository perfLogAssemblyRepository)
        {
            _perfLogAssemblyRepository = perfLogAssemblyRepository;
        }

        public async Task<List<PerfLogAssembly>> GetAll()
        {
            return await _perfLogAssemblyRepository.GetAll();
        }
    }
}