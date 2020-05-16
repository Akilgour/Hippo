using AutoMapper;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.DTO.DTO;
using Hippologamus.DTO.Helpers;
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

        public async Task<PagedList<PerfLogDisplay>> GetAll(PerfLogDisplaySearch perfLogDisplaySearch)
        {
            var perfLogFromRepo = await _perfLogService.GetAll(perfLogDisplaySearch);
            var teams = _mapper.Map<List<PerfLogDisplay>>(perfLogFromRepo);
            var result = PagedList<PerfLogDisplay>.Create(teams, perfLogDisplaySearch.PageNumber, perfLogDisplaySearch.PageSize);
            return result;
        }

        public async Task<PerfLogDetails> GetById(int perfLogId)
        {
            return _mapper.Map<PerfLogDetails>(await _perfLogService.GetById(perfLogId));
        }
    }
}