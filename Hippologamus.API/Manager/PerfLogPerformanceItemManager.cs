using AutoMapper;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Shared.DTO;
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

        public async Task<List<PerfLogPerformanceItemCollection>> GetByAssembly(string perfLogAssembly)
        {
            return _mapper.Map<List<PerfLogPerformanceItemCollection>>(await _perfLogPerformanceItemService.GetByAssembly(perfLogAssembly));
        }
    }
}