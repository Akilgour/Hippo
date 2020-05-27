using AutoMapper;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager
{
    public class PerfLogRequestPathManager : BaseManager, IPerfLogRequestPathManager
    {
        private IPerfLogRequestPathService _perfLogRequestPathService;

        public PerfLogRequestPathManager(IPerfLogRequestPathService perfLogRequestPathService, IMapper mapper)
            : base(mapper)
        {
            _perfLogRequestPathService = perfLogRequestPathService;
        }

        public async Task<List<PerfLogRequestPathCollection>> GetByAssembly(string perfLogAssembly)
        {
            return _mapper.Map<List<PerfLogRequestPathCollection>>(await _perfLogRequestPathService.GetByAssembly(perfLogAssembly));
        }
    }
}