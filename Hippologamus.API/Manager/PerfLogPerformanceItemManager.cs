using AutoMapper;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager
{
    public class PerfLogPerformanceItemManager : BaseManager, IPerfLogPerformanceItemManager
    {
        private IPerfLogPerformanceItemService _perfLogPerformanceItemService;

        public PerfLogPerformanceItemManager(IPerfLogPerformanceItemService perfLogPerformanceItemService, IMapper mapper)
            : base(mapper)
        {
            _perfLogPerformanceItemService = perfLogPerformanceItemService;
        }

        public async Task<List<PerfLogPerformanceItemDisplay>> GetByAssembly(string perfLogAssembly)
        {
            return _mapper.Map<List<PerfLogPerformanceItemDisplay>>(await _perfLogPerformanceItemService.GetByAssembly(perfLogAssembly));
        }
    }
}