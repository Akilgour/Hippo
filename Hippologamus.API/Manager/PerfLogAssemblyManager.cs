using AutoMapper;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager
{
    public class PerfLogAssemblyManager : BaseManager, IPerfLogAssemblyManager
    {
        private readonly IPerfLogAssemblyService _perfLogAssemblyService;

        public PerfLogAssemblyManager(IPerfLogAssemblyService perfLogAssemblyService, IMapper mapper)
            : base(mapper)
        {
            _perfLogAssemblyService = perfLogAssemblyService;
        }

        public async Task<List<PerfLogAssemblyDisplay>> GetAll()
        {
            return _mapper.Map<List<PerfLogAssemblyDisplay>>(await _perfLogAssemblyService.GetAll());
        }
    }
}