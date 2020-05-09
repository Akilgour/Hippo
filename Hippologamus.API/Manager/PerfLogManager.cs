using AutoMapper;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager
{
    public class PerfLogManager : BaseManager, IPerflogManager
    {
        private readonly IPerfLogService _perfLogService;

        public PerfLogManager(IPerfLogService perfLogService, IMapper mapper)
            : base(mapper)
        {
            _perfLogService = perfLogService;
        }

        public async Task<List<PerfLogDisplay>> GetAll()
        {
            return _mapper.Map<List<PerfLogDisplay>>(await _perfLogService.GetAll());
        }
    }
}